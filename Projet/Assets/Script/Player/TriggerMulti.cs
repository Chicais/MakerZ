using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMulti : MonoBehaviour
{
    private PhotonView PhotonView;

    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewPlayer"))
        {
            PhotonView.RPC("destroyObj", PhotonTargets.All);
        }
    }

    [PunRPC]

    private void destroyObj()
    {
        PhotonNetwork.Destroy(gameObject);
    }
}
