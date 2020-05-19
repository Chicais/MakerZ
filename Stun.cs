using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Stun : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce = 10f;
    private bool hasPlayer = false;
    private bool isCarried = false;
    private bool touched = false;
    public GameObject p;
    
    // Start is called before the first frame update
    void Start()
    {
        p = ClosestPlayer();
        if (p!=null)
        {
            player = p.transform;
            playerCam = p.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(gameObject.transform.position, player.position);

        if (distance<=2.5f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && Input.GetKey(KeyCode.E))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = playerCam;
            isCarried = true;
        }

        if (isCarried)
        {
            if (touched)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isCarried = false;
                touched = false;
            }

            if (Input.GetMouseButton(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isCarried = false;
                GetComponent<Rigidbody>().AddForce(player.forward*throwForce);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                GetComponent< Rigidbody>().isKinematic = false;
                transform.parent = null;
                isCarried = false;
            }
        }
        /*
        if (transform.position.x<=-100)
        {
            Destroy(gameObject);
        }
        */
    }

    void OnTriggerEnter()
    {
        if (isCarried)
        {
            touched = true;
        }
    }

    GameObject ClosestPlayer()
    {
        GameObject[] allPlayer = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = allPlayer[0];
        float closestDistance = Vector3.Distance(gameObject.transform.position, closest.transform.position);
        foreach (GameObject pl in allPlayer)
        {
            float distance = Vector3.Distance(gameObject.transform.position, pl.transform.position);
            if (distance<closestDistance)
            {
                closestDistance = distance;
                closest = pl;
            }
        }
        
        return closest;
    }
}
