using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_mvt : MonoBehaviour
{
    public GameObject cam;
    public float mvt = 2f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("z"))
        {
            cam.transform.Translate(Vector3.forward * Time.deltaTime * mvt);
        }
        if (Input.GetKey("d"))
        {
            cam.transform.Translate(Vector3.right * Time.deltaTime * mvt);
        }
        if (Input.GetKey("q"))
        {
            cam.transform.Translate(Vector3.left * Time.deltaTime * mvt);
        }
        if (Input.GetKey("s"))
        {
            cam.transform.Translate(Vector3.back * Time.deltaTime * mvt);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            cam.transform.Rotate(Vector3.left * Time.deltaTime * mvt);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            cam.transform.Rotate(Vector3.right * Time.deltaTime * mvt);
        }
    }
}
