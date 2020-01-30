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
                rb.transform.Translate(Vector3.forward * Time.deltaTime * mvt);
            }
            if (Input.GetKey("d"))
            {
                rb.transform.Translate(Vector3.right * Time.deltaTime * mvt);
            }
            if (Input.GetKey("q"))
            {
                rb.transform.Translate(Vector3.left * Time.deltaTime * mvt);
            }
            if (Input.GetKey("s"))
            {
                rb.transform.Translate(Vector3.back * Time.deltaTime * mvt);
            }
        }
    }
}
