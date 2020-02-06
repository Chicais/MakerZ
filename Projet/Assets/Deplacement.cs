using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{

    public Rigidbody rb;
    private PhotonView view;

    public float mvt = 1f;

    void Start()
    {
        view = GetComponent<PhotonView> ();
    }
    
    void Update()
    {
        if (view.isMine)
        {
            if (Input.GetKey("z"))
            {
                rb.AddForce(Vector3.forward * mvt);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(Vector3.right * mvt);
            }
            if (Input.GetKey("q"))
            {
                rb.AddForce(Vector3.left * mvt);
            }
            if (Input.GetKey("s"))
            {
                rb.AddForce(Vector3.back * mvt);
            }
        }
    }
}
