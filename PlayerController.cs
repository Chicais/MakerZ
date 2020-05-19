using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRD;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public bool isSpeedBoosted = false;
    public bool isJumpBoosted = false;
    public bool isInvicible = false;
    public bool isSlowed = false;
    public bool isStunned = false;
    public bool isCountdown = true;
    public bool stopTimer = true;
    public float currentTimeSpeed = 0f;
    public float currentTimeJump = 0f;
    public float currentTimeSlow = 0f;
    public float currentTimeStunned = 0f;
    public float currentTimeInvincible = 0f;
    public float startingTime = 3f;
    public Text speedText;
    public Text jumpText;
    public Text slowText;
    public Text stunText;
    public Text invincibleText;
    public Text countdown;
    public Text timer;
    public float time;
    public float minuteTimer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //theRD = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //theRD = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRD.velocity.y, Input.GetAxis("Vertical")*moveSpeed);
        /*if (Input.GetButtonDown("Jump"))
         {
            theRD = new Vector3(theRD.velocity.x,jumpForce,theRD.velocity.z);
         }
         */
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y,Input.GetAxis("Vertical")*moveSpeed);

        if (!stopTimer)
        {
            time +=1*Time.deltaTime;
            timer.text = minuteTimer.ToString("0")+":"+time.ToString("0");
            if (time>=59.5f)
            {
                minuteTimer += 1;
                time = 0;
            }

            if (time>0 && time<9.5f)
            {
                timer.text = minuteTimer.ToString("0")+":0"+time.ToString("0");
            }
        }

        if (isCountdown)
        {
            moveSpeed = 0f;
            countdown.enabled = true;
            countdown.text = startingTime.ToString("0");
            startingTime -= 1 * Time.deltaTime;
            if (startingTime<=-1)
            {
                countdown.enabled = false;
                isCountdown = false;
            }
            if (startingTime<=0)
            {
                countdown.text = "GO!";
                moveSpeed = 10f;
                stopTimer = false;
            }
        }

        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) +
                        (transform.right * Input.GetAxis("Horizontal"));
        if (isSpeedBoosted)
        {
            moveSpeed = 15f;
            currentTimeSpeed -= 1 * Time.deltaTime;
            speedText.text = "Speed : " + currentTimeSpeed.ToString("0");
            if (currentTimeSpeed <= 0)
            {
                moveSpeed = 10f;
                isSpeedBoosted = false;
            }
        }

        if (isSlowed)
        {
            moveSpeed = 7f;
            currentTimeSlow -= 1 * Time.deltaTime;
            slowText.text = "Slowed : " + currentTimeSlow.ToString("0");
            if (currentTimeSlow <= 0)
            {
                moveSpeed = 10f;
                isSlowed = false;
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
            isSlowed = false;
            isStunned = false;
            currentTimeSlow = 0f;
            currentTimeStunned = 0f;
            currentTimeInvincible -= 1 * Time.deltaTime;
            invincibleText.text = "Invincible : " + currentTimeInvincible.ToString("0");
            if (currentTimeInvincible <= 0)
            {
                isInvicible = false;
            }
        }
        
        if (isStunned)
        {
            moveSpeed = 0f;
            jumpForce = 0f;
            currentTimeStunned -= 1 * Time.deltaTime;
            stunText.text = "Stunned : " + currentTimeStunned.ToString("0");
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
        
        if (isJumpBoosted)
        {
            jumpForce = 12f;
            currentTimeJump -= 1 * Time.deltaTime;
            jumpText.text = "Jump Boosted : " + currentTimeJump.ToString("0");
            if (currentTimeJump <= 0)
            {
                jumpForce = 8f;
                isJumpBoosted = false;
            }
        }
        
        moveDirection = moveDirection.normalized * moveSpeed ;
   
        moveDirection.y = yStore;
        
        if(controller.isGrounded)
        {
            moveDirection.y=0f;
            if(Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }
        

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale*Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
        slowText.enabled = isSlowed;
        speedText.enabled = isSpeedBoosted;
        jumpText.enabled = isJumpBoosted;
        stunText.enabled = isStunned;
        invincibleText.enabled = isInvicible;

        
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

        if (other.gameObject.CompareTag("Finish"))
        {
            stopTimer = true;
        }
    }

}
