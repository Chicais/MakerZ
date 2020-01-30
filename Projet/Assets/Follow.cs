
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject prefab;

    public Transform cam;

    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = prefab.transform.position + offset;
    }
}
