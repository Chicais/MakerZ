using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DDOLmanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print(GameObject.FindGameObjectsWithTag("DDOL").Length);
        
        if (GameObject.FindGameObjectsWithTag("DDOL").Length > 1)
        {
            PhotonNetwork.Destroy(GameObject.FindGameObjectsWithTag("DDOL")[0].transform.GetChild(0).GetComponent<PhotonView>());
            Destroy(GameObject.FindGameObjectsWithTag("DDOL")[0]);
        }
    }
}
