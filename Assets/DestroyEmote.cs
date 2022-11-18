using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEmote : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(DestroyEmoteObject), 5f);
    }

    // Update is called once per frame
    void DestroyEmoteObject()
    {
        Destroy(this.gameObject);
    }

    private void OnDestroy()
    {
        
        CancelInvoke();
    }
}
