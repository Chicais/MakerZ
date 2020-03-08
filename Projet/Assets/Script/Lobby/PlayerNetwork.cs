
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetwork : MonoBehaviour
{
    public static PlayerNetwork Instance;
    
    public string playername { get; private set; }

    private PhotonView photonView;
    private int PlayerInGame = 0;

    private void Awake()
    {
        Instance = this;
        photonView = GetComponent<PhotonView>();
        
        playername = "#" + Random.Range(1000, 9999);

        PhotonNetwork.sendRate = 40;

        PhotonNetwork.sendRateOnSerialize = 20;

        SceneManager.sceneLoaded += OnSceneFinishedLoading;
        
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game2")
        {
            if(PhotonNetwork.isMasterClient)
                MasterLoadedGame();
            else
            {
                NonMasterLoadedGame();
            }
        }
    }

    private void MasterLoadedGame()
    {
        photonView.RPC("RPC_GameIsLoadedForOther", PhotonTargets.MasterClient);
        photonView.RPC("RPC_LoadGameOthers", PhotonTargets.Others);
    }

    private void NonMasterLoadedGame()
    {
        photonView.RPC("RPC_GameIsLoadedForOther", PhotonTargets.MasterClient);
    }
    
    [PunRPC]
    private void RPC_LoadGameOthers()
    {
        PhotonNetwork.LoadLevel(2);
    }

    [PunRPC]
    private void RPC_GameIsLoadedForOther()
    {
        PlayerInGame++;
        if (PlayerInGame == PhotonNetwork.playerList.Length)
        {
            print("All players in game");
            photonView.RPC("RPC_CreatePlayer", PhotonTargets.All);
        }
    }

    [PunRPC]
    private void RPC_CreatePlayer()
    {
        float Randomvalue = Random.Range(0f, 5f);
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "NewPlayer"), Vector3.up * Randomvalue, Quaternion.identity, 0);
    }
}
