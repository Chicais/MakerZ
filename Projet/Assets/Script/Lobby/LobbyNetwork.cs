using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class LobbyNetwork : PunBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Connecting to server");
        PhotonNetwork.ConnectUsingSettings("0.0.0");
    }

    // Update is called once per frame
    public override void OnConnectedToMaster()
    {
        print("connected to server");
        PhotonNetwork.automaticallySyncScene = false;
        PhotonNetwork.playerName = PlayerNetwork.Instance.playername;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedLobby()
    {
        print("Joined lobby");

        if (!PhotonNetwork.inRoom)
            MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
    }
}
