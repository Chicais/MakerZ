using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class RoomLayout : PunBehaviour
{
    [SerializeField] private GameObject _roomListingPrefab;

    public GameObject RoomListingPrefab => _roomListingPrefab;
    
    private List<RoomListing> _roomListingsButtons = new List<RoomListing>();

    public List<RoomListing> RoomListingsButtons => _roomListingsButtons;

    public override void OnReceivedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        foreach (RoomInfo room in rooms)
        {
            RoomReceived(room);
        }
        
        RemoveOldRooms();
    }

    private void RoomReceived(RoomInfo room)
    {
        int index = RoomListingsButtons.FindIndex(x => x.RoomName == room.Name);

        if (index == -1)
        {
            if (room.IsVisible && room.PlayerCount < room.MaxPlayers)
            {
                GameObject roomListingObj = Instantiate(RoomListingPrefab);
                roomListingObj.transform.SetParent(transform, false);

                RoomListing roomlisting = roomListingObj.GetComponent<RoomListing>();
                RoomListingsButtons.Add(roomlisting);

                index = RoomListingsButtons.Count - 1;
            }
        }

        if (index != -1)
        {
            RoomListing roomListing = RoomListingsButtons[index];
            roomListing.SetRoomNametext(room.Name);
            roomListing.Updated = true;
        }
    }

    private void RemoveOldRooms ()
    {
        List<RoomListing> removeRooms = new List<RoomListing>();

        foreach (RoomListing roomListing in RoomListingsButtons)
        {
            if (!roomListing.Updated)
                removeRooms.Add(roomListing);
            else
            {
                roomListing.Updated = false;
            }
        }

        foreach (RoomListing roomListing in removeRooms)
        {
            GameObject roomListingObj = roomListing.gameObject;
            RoomListingsButtons.Remove(roomListing);
            Destroy(roomListingObj);
        }
    }
}
