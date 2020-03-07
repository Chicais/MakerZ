using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyCanvas : MonoBehaviour
{

    [SerializeField] private RoomLayout _roomLayout;

    public RoomLayout RoomLayout => _roomLayout;

    public void OnClickJoinRoom(string roomname)
    {
        if (PhotonNetwork.JoinRoom(roomname)) // dit a Photon que tu rentres dans la room
        {
            return;
        }
        else
        {
            print("Join Room failed");
        }
    }
}
