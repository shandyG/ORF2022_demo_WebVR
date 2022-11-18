using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ChangeEmoting : MonoBehaviourPunCallbacks
{
    [SerializeField] Animator anim;
    //public GameObject emotePanel;

    // Start is called before the first frame update
    void Start()
    {
        if (!photonView.IsMine)
        {

            this.GetComponent<ChangeEmoting>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            //emotePanel.gameObject.SetActive(true);
            this.GetComponent<FPSController1>().DeactivateCursorLock();
            anim.SetBool("LongPress", true);

            //this.GetComponent<FPSController1>().enabled = false;

            //Cursor.lockState = CursorLockMode.None;

        }

        else
        {
            //emotePanel.gameObject.SetActive(false);
            anim.SetBool("LongPress", false);
            //this.GetComponent<FPSController1>().enabled = true;

            this.GetComponent<FPSController1>().ActivateCursorLock();
            
            //Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
