using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class CreateRoom : PunBehaviour
{
    [SerializeField] private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public void Onclickroom()
    {
        RoomOptions roomOptions = new RoomOptions() {IsVisible = true, IsOpen = true, MaxPlayers = 4};
        
        if(PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
            print("create room succesfully sent");
        else
        {
            print("create room failed to sent");
        }
    }
    
    public override void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("create room failed : " + codeAndMessage[1]);
    }

    public override void OnCreatedRoom()
    {
        print("Room created succesfully");
    }
}
