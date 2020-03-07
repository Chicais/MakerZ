using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    /*public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public GameObject Finish;
    public GameObject Character;
    public bool isSpeedBoosted = false;
    public bool isJumpBoosted = false;
    public float currentTime = 0f;
    public float startingTime = 10f;*/
    public Transform target;
    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        /*if (isSpeedBoosted)
        {
            moveSpeed = 30f;
            currentTime -= 1 * Time.deltaTime;
            if (currentTime <= 0)
            {
                moveSpeed = 10f;
                isSpeedBoosted = false;
            }
        }
        
        if (isJumpBoosted)
        {
            jumpForce = 12f;
            currentTime -= 1 * Time.deltaTime;
            if (currentTime <= 0)
            {
                jumpForce = 8f;
                isJumpBoosted = false;
            }
        }
        
        Character.transform.position = Finish.transform.position;*/
    }
    
    /*public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currentTime = startingTime;
            isSpeedBoosted = true;
        }
        
        if (other.gameObject.CompareTag("Jump Boost"))
        {
            currentTime = startingTime;
            isJumpBoosted = true;
        }
        
        
    }*/
}
