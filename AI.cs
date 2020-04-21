using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class AI : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public bool isSpeedBoosted = false;
    public bool isJumpBoosted = false;
    public bool isInvicible = false;
    public bool isSlowed = false;
    public bool isStunned = false;
    public bool isCountdown = true;
    public float currentTimeSpeed = 0f;
    public float currentTimeJump = 0f;
    public float currentTimeSlow = 0f;
    public float currentTimeStunned = 0f;
    public float currentTimeInvincible = 0f;
    public float startingTime = 3f;
    public Transform target;
    private int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = Waypoints.points[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (isCountdown)
        {
            moveSpeed = 0f;
            startingTime -= 1 * Time.deltaTime;
            if (startingTime<=0)
            {
                moveSpeed = 10f;
            }
        }
        Vector3 direction = target.position - this.transform.position;
        
        //float yStore = direction.y;
        
        //direction = direction.normalized * moveSpeed ;
   
        //direction.y = yStore;
        
        
        //if(Input.GetButtonDown("Jump"))
        //{
        //   direction.y = jumpForce;
        //}
        
        //float y = transform.position.y+(Physics.gravity.y * gravityScale*Time.deltaTime);

        if (Vector3.Distance(transform.position,target.position)<=0.2f)
        {
            GetNextWaypoint();
        }
	    /*direction.y = 0;
	
	    this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
					Quaternion.LookRotation(direction),0.1f);
	    if(direction.magnitude > 5)
	    {
		    this.transform.Translate(0,0,0.05f);
	    }*/
        
        if (isSpeedBoosted)
        {
            moveSpeed = 30f;
            currentTimeSpeed -= 1 * Time.deltaTime;
            if (currentTimeSpeed <= 0)
            {
                moveSpeed = 10f;
                isSpeedBoosted = false;
            }
        }
        
        if (isJumpBoosted)
        {
            jumpForce = 12f;
            currentTimeJump -= 1 * Time.deltaTime;
            if (currentTimeJump <= 0)
            {
                jumpForce = 8f;
                isJumpBoosted = false;
            }
        }
        
        if (isStunned)
        {
            moveSpeed = 0f;
            currentTimeStunned -= 1 * Time.deltaTime;
            if (currentTimeStunned <= 0)
            {
                moveSpeed = 10;
                isStunned = false;
            }
        }
        
        if (isInvicible)
        {
            if (isSpeedBoosted)
            {
                moveSpeed = 15f;
            }
            else
            {
                moveSpeed = 10f;
            }
            currentTimeSlow = 0f;
            currentTimeStunned = 0f;
            isSlowed = false;
            isStunned = false;
            currentTimeInvincible -= 1 * Time.deltaTime;
            if (currentTimeInvincible <= 0)
            {
                isInvicible = false;
            }
        }
        
        if (isSlowed)
        {
            moveSpeed = 7f;
            currentTimeSlow -= 1 * Time.deltaTime;
            if (currentTimeSlow <= 0)
            {
                moveSpeed = 10f;
                isSlowed = false;
            }
        }
        
        transform.Translate(direction.normalized* moveSpeed * Time.deltaTime,Space.World);
        

    }

    private void GetNextWaypoint()
    {
        if (waypointIndex>=Waypoints.points.Length-1)
        {
            moveSpeed = 0f;
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currentTimeSpeed = 10f;
            isSpeedBoosted = true;
        }
        
        if (other.gameObject.CompareTag("Jump Boost"))
        {
            currentTimeJump = 10f;
            isJumpBoosted = true;
        }
        if (other.gameObject.CompareTag("Slow"))
        {
            currentTimeSlow = 5f;
            isSlowed = true;
        }
        if (other.gameObject.CompareTag("Invincible"))
        {
            currentTimeInvincible = 10f;
            isInvicible = true;
        }
        if (other.gameObject.CompareTag("Stun"))
        {
            currentTimeStunned = 5f;
            isStunned = true;
        }
        
    }
}
