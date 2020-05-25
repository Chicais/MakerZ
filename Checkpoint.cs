using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool destroy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy)
        {
            gameObject.SetActive(false);
            Finish.Respawn(gameObject);
            destroy = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player" || other.gameObject.name=="AI")
        {
            if (!gameObject.CompareTag("Slow"))
            {
                destroy = true;
            }
            
        }
    }
    
}
