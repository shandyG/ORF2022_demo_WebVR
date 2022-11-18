﻿using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;



    public class FPSController1 : MonoBehaviourPunCallbacks
    {
        float x, z;
        float speed = 0.1f;

        public GameObject cam;
        Quaternion cameraRot, characterRot;
        float Xsensityvity = 3f, Ysensityvity = 3f;

        bool cursorLock = true;

        private Animator animator;
        private Rigidbody rb;

        private bool isJumping = false;


    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

        // Start is called before the first frame update
        void Start()
        {
            cameraRot = cam.transform.localRotation;
            characterRot = transform.localRotation;

            
            animator = GetComponent<Animator>();
            rb = GetComponent<Rigidbody>(); 

            
        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.IsMine)
            {
                float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
                float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

            if (cursorLock)
            {
                cameraRot *= Quaternion.Euler(-yRot, 0, 0);
                characterRot *= Quaternion.Euler(0, xRot, 0);

                //Updateの中で作成した関数を呼ぶ
                cameraRot = ClampRotation(cameraRot);

                cam.transform.localRotation = cameraRot;
                transform.localRotation = characterRot;

            }
            UpdateCursorLock();
            }

        }

        private void FixedUpdate()
        {
        
            if (photonView.IsMine)
            {
                x = 0;
                z = 0;

                x = Input.GetAxisRaw("Horizontal") * speed;
                z = Input.GetAxisRaw("Vertical") * speed;




                //transform.position += new Vector3(x,0,z);

                //transform.position += cam.transform.forward * z + cam.transform.right * x;
                //rb.Move(transform.position += cam.transform.forward * z + cam.transform.right * x);
                var input = cam.transform.forward * z + cam.transform.right * x;

                if (input.magnitude > 0.01f)
                {
                    transform.position += cam.transform.forward * z + cam.transform.right * x;
                    animator.SetBool("is_walking", true);
                }
                else
                {
                    animator.SetBool("is_walking", false);
                }



            }
        
        }

    public void ActivateCursorLock()
        {
            cursorLock = true;
        }

    public void DeactivateCursorLock()
        {
            cursorLock = false;
        
    }

    public void UpdateCursorLock()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLock = false;
            }
            else if (Input.GetMouseButton(1))
            {
                cursorLock = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.velocity = Vector3.up * 4;
                isJumping = true;
        }

        if (cursorLock)
            {
                Cursor.lockState = CursorLockMode.Locked;
        }
            else if (!cursorLock)
            {
                Cursor.lockState = CursorLockMode.None;
        }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floor"))
            {
                isJumping = false;
            }
        }

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
        {
            //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1f;

            float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

            angleX = Mathf.Clamp(angleX, minX, maxX);

            q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

            return q;
        }


    }