using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winText;

    public GameObject loseText;
    
    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NewPlayer"))
        {
            winText.SetActive(true);
        }
        else
        {
            if (other.gameObject.name=="AI")
            {
                loseText.SetActive(true);
            }
        }
    }
        
}
