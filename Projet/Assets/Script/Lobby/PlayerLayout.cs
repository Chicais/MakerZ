using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;

public class PlayerLayout : PunBehaviour
{
    [SerializeField] private GameObject _playerListingPrefab; 
    public GameObject PlayerListingPrefab => _playerListingPrefab;
    
    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    public List<PlayerListing> PlayerListing => _playerListings;

    
    public override void OnJoinedRoom()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        MainCanvasManager.Instance.CurrentRoomCanvas.transform.SetAsLastSibling(); // Fait bouger la scene en dessous de lobby pour le faire apparaitre au premier plan
        
        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;

        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }

    public override void OnPhotonPlayerConnected(PhotonPlayer photonPlayer)
    {
        PlayerJoinedRoom(photonPlayer);
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer photonPlayer)
    {
        PlayerLeftRoom(photonPlayer);
    }

    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
        if (photonPlayer == null)
            return;
        
        PlayerLeftRoom(photonPlayer);

        GameObject playerListingObj = Instantiate(PlayerListingPrefab);
        playerListingObj.transform.SetParent(transform, false);

        PlayerListing playerListing = playerListingObj.GetComponent<PlayerListing>();
        playerListing.ApplyPhotonPlayer(photonPlayer);

        PlayerListing.Add(playerListing);
    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)
    {
        int index = PlayerListing.FindIndex(x => x.PhotonPlayer == photonPlayer);
        if (index != -1)
        {
            Destroy(PlayerListing[index].gameObject);
            PlayerListing.RemoveAt(index);
        }
    }

    public void OnClickleaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
