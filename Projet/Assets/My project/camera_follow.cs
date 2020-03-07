using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public GameObject CameraPrefab;
    public Transform player;
    private GameObject cam;
    public Vector3 offset;
    private PhotonView view;
    
    void Start()
    {
        cam = Instantiate( CameraPrefab ) ;
        view = GetComponent<PhotonView> ();
        if (!view.isMine)
        {
            Destroy(cam);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (view.isMine)
        {
            cam.transform.position = player.position + offset;
            cam.transform.LookAt(player);
        }
    }
}
