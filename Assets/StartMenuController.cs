using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour
{
    public GameObject TitleMenu;
    public GameObject CharaMenu;
    public GameObject NameMenu;
    public GameObject BackButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChangeCharaMenu()
    {
        BackButton.gameObject.SetActive(true);
        TitleMenu.gameObject.SetActive(false);
        CharaMenu.gameObject.SetActive(true);
    }

    public void ChangeNameMenu()
    {
        StartCoroutine(DelayCoroutine(2, () =>
        {
            CharaMenu.gameObject.SetActive(false);
            NameMenu.gameObject.SetActive(true);
        }));
    }

    public void BackToPrevScreen()
    {
        
            if (CharaMenu.activeSelf)
            {
                BackButton.gameObject.SetActive(false);
                TitleMenu.gameObject.SetActive(true);
                CharaMenu.gameObject.SetActive(false);
            }

            else if (NameMenu.activeSelf)
            {
                CharaMenu.gameObject.SetActive(true);
                NameMenu.gameObject.SetActive(false);
            }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
