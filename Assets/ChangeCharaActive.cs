using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharaActive : MonoBehaviour
{
    public GameObject Chara1Panel;
    public GameObject Chara2Panel;
    public GameObject Chara3Panel;
    public GameObject Chara4Panel;

    // Start is called before the first frame update
    void Start()
    {
        
        //StartCoroutine(DelayCoroutine());
    }

    void OnEnable()
    {
        Chara1Panel.gameObject.SetActive(false);
        Chara2Panel.gameObject.SetActive(false);
        Chara3Panel.gameObject.SetActive(false);
        Chara4Panel.gameObject.SetActive(false);
        StartCoroutine(DelayCoroutine());
    }

    private IEnumerator DelayCoroutine()
    {

        yield return new WaitForSeconds(0.2f);

        Chara1Panel.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        Chara2Panel.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        Chara3Panel.gameObject.SetActive(true);

        yield return new WaitForSeconds(0.2f);

        Chara4Panel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
