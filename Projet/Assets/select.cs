using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
    public GameObject bloc;
    private GameObject bloc2;
    public GameObject player;
    private Vector3 tempos;

    public void clic()
    {
        bloc2 = Instantiate(bloc);
    }

    void Update()
    {
        tempos.z = player.transform.position.z + 200;

        tempos.x = Input.mousePosition.x;

        tempos.y = Input.mousePosition.y;

        bloc2.transform.position = tempos;
    }
}
