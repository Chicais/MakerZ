using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishMulti : MonoBehaviour
{
    /*public GameObject winText;
    public GameObject loseText;
    private PhotonView PhotonView;
    private GameObject winner;
    
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        PhotonView = GetComponent<PhotonView>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewPlayer"))
        {
            winner = other.gameObject;
            PhotonView.RPC("Win" , PhotonTargets.winner);
        }
        else
        {
            if (other.gameObject.name=="AI")
            {
                loseText.SetActive(true);
            }
        }
    }

    [PunRPC]

    private void Win()
    {
        winText.SetActive(true);
    }

    private void Lose()
    {
        loseText.SetActive(true);
    }*/
}
