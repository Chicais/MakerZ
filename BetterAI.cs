﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class  BetterAI : MonoBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
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
    private Vector3 moveDirection = Vector3.zero;
    private int waypointIndex = 0;
    public CharacterController controller;
    public bool jump;
    public Vector3 respawnPoint;

    public bool jumpOnce;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
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
                isCountdown = false;
            }
        }
        
        
        
        if (isSpeedBoosted)
        {
            moveSpeed = 15f;
            currentTimeSpeed -= 1 * Time.deltaTime;
            if (currentTimeSpeed <= 0)
            {
                moveSpeed = 10f;
                isSpeedBoosted = false;
            }
        }
        
        if (isJumpBoosted)
        {
            jumpForce = 150f;
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
            jumpForce = 0f;
            currentTimeStunned -= 1 * Time.deltaTime;
            if (currentTimeStunned <= 0)
            {
                if (isSpeedBoosted)
                {
                    moveSpeed = 15f;
                }
                else
                {
                    moveSpeed = 10f;
                }

                if (isJumpBoosted)
                {
                    jumpForce = 12f;
                }
                else
                {
                    jumpForce = 8f;
                }
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
        
        
        LookAt();
        Chase();
    }

    void LookAt()
    {
        var rotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation,rotation,10*Time.deltaTime);
        transform.rotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);

    }

    void Chase()
    {
        moveDirection = transform.forward;
        moveDirection *= moveSpeed;
        moveDirection.y = 0;
        
        if (target.gameObject.CompareTag("Slow") || target.gameObject.CompareTag("Stun"))
        {
            if (Vector3.Distance(transform.position,target.position)<=5f && controller.isGrounded)
            {
                Jump();
            }
                
            if (Math.Abs(target.transform.position.x - transform.position.x) < 3f &&
                Math.Abs(target.transform.position.z - transform.position.z) < 3f)
            {
                GetNextWaypoint();
            }
        }

        if (target.gameObject.CompareTag("Block"))
        {
            if (Math.Abs(target.transform.position.x - transform.position.x) < 2f &&
                Math.Abs(target.transform.position.z - transform.position.z) < 2f)
            {
                GetNextWaypoint();
            }
        }
        
        if (Math.Abs(target.transform.position.x - transform.position.x) < 1f &&
            Math.Abs(target.transform.position.z - transform.position.z) < 1f)
        {
            if (Vector3.Distance(transform.position,target.position)>2f)
            {
                moveSpeed = 1f;
            }
        }
        
        
        if (Vector3.Distance(transform.position,target.position)<=2f)
        {
            if (target.gameObject.CompareTag("Finish"))
            {
                moveSpeed = 0f;
            }
            else
            {
                if (isSpeedBoosted)
                {
                    moveSpeed = 12f;
                }
                else
                {
                    moveSpeed = 8f;
                }
                GetNextWaypoint();
            }
        }

        if (controller.isGrounded)
        {
            jumpOnce = true;
            if (jump)
            {
                Jump();
                jump = false;
            }
        }
        else
        {
            if (!Physics.Raycast(transform.position,-transform.up,20f)&&jumpOnce)
            {
                Jump();
                jumpOnce = false;
            }
        }
        
        
        if (Input.GetKeyDown(KeyCode.K))
        {
           Jump();
        }
        
        
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravity*Time.deltaTime);
        //moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex>=Waypoints.points.Length-1)
        {
            moveSpeed = 0f;
            jumpForce = 0f;
        }
        else
        {
            waypointIndex++;
            target = Waypoints.points[waypointIndex];
        }
    }

    private void Jump()
    {
        moveDirection.y = jumpForce;
    }
    
    private void OnTriggerEnter(Collider other)
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

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Math.Abs(hit.normal.y)<0.5)
        {
            jump = true;
        }
    }
}
