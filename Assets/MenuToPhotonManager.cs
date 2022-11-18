using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class MenuToPhotonManager : MonoBehaviourPunCallbacks
{
    public GameObject FirstCamera;
    public InputField inputNickname;
    private string selectCharacterName = "Chara1";

    public void StartGame()
    {
        PhotonNetwork.NickName = inputNickname.text;
        PhotonNetwork.ConnectUsingSettings();
        FirstCamera.SetActive(false);
    }

    public void SelectChara(string CharaName)
    {
        selectCharacterName = CharaName;
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var position = new Vector3(-20f, 2f, -15f);
        PhotonNetwork.Instantiate(selectCharacterName, position, Quaternion.identity);
        Debug.Log(selectCharacterName);
    }
}