using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InstanciateCam : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Main Camera"), Vector3.up * 1, Quaternion.identity, 0);
    }

}
