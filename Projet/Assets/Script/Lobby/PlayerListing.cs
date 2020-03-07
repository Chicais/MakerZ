
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour
{
    public PhotonPlayer PhotonPlayer { get; private set; }
    
    [SerializeField] private Text _playerName;

    public Text PlayerName => _playerName;

    public void ApplyPhotonPlayer(PhotonPlayer photonPlayer)
    {
        PhotonPlayer = photonPlayer;
        PlayerName.text = photonPlayer.NickName;
    }
}
