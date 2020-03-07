
using UnityEngine;

public class CurrentRoomCanvas : MonoBehaviour
{
    public void OnClicStartSync() // Les joueurs peuvent rejoindre après le lancement
    {
        PhotonNetwork.LoadLevel(2);
    }

    public void OnClicStartDelay()
    {
        if (!PhotonNetwork.isMasterClient)
            return;
        PhotonNetwork.room.IsOpen = false;
        PhotonNetwork.room.IsVisible = false;
        PhotonNetwork.LoadLevel(2);
    }
}
