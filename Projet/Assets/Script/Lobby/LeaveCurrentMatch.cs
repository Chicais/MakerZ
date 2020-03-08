using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveCurrentMatch : MonoBehaviour
{
    public void OnclicLeaveMatch()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel(1);
    }

    public void OnclicLeaveMulti()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }

    public void OnclicLeaveSolo()
    {
        SceneManager.LoadScene(0);
    }
}
