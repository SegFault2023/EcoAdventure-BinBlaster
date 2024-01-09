using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public GameObject connectedScreen;
    public GameObject diconnectedScreen;

    public void OnClick_ConnectBtn()
    {
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        diconnectedScreen.SetActive(true);
    }
    public override void OnJoinedLobby()
    {
        if(diconnectedScreen.activeSelf)
            diconnectedScreen.SetActive(false);

        connectedScreen.SetActive(true);
    }



}
