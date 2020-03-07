using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Renderer theRend;
    public Material cpOff;
    public Material cpOn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*public void CheckpointOn()
    {
        theRend.material = cpOn;
    }*/
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            //CheckpointOn();
            Destroy(gameObject);
        }
    }
}
