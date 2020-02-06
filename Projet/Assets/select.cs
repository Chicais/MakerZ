using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public GameObject bloc;
    private GameObject bloc2;
    public GameObject player;

    public void clic()
    {
        bloc2 = Instantiate(bloc);
        Screen.lockCursor = true;
    }

    void Update()
    {
        bloc2.transform.Translate(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"), player.transform.position.z + 50f);
    }
}
