using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
public class UIhandler : MonoBehaviourPunCallbacks
{

    public TMP_InputField createRoomTF;
    public TMP_InputField joinRoomTF;

    public void OnClick_JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinRoomTF.text, null);
    }
    public void OnClick_CreateRoom()
    {
        PhotonNetwork.CreateRoom(createRoomTF.text, new RoomOptions { MaxPlayers = 2 }, null);
        print("create joined Sucess");
    }

    public override void OnJoinedRoom()
    {
        print("Room joined Sucess");
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("Room Failed " + returnCode + " Message " + message);
    }
}