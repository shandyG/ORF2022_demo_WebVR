using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ActivateEmote : MonoBehaviourPunCallbacks
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ClickAndEmotion(string emote)
    {
        if (photonView.IsMine)
        {
            
            
            photonView.RPC(nameof(InstantiateEmote), RpcTarget.All, emote);
        }
    }

    [PunRPC]
    private void InstantiateEmote(string emote)
    {
        GameObject obj = (GameObject)Resources.Load(emote);
      
        Instantiate(obj, this.transform);

        
    }
}
