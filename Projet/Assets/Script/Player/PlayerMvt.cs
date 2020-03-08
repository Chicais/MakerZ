using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;

public class PlayerMvt : Photon.MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    public bool isSpeedBoosted = false;
    public bool isJumpBoosted = false;
    public float currentTime = 0f;
    public float startingTime = 10f;

    private PhotonView _view;
    public Camera cam;

    private Animator Animator;

    private Quaternion TargetRotation;
    private Vector3 TargetPosition;

    void Start()
    {
        _view = GetComponent<PhotonView>();
        
        print(GetComponent<PhotonView>());

        if (_view.isMine)
        {
            controller = GetComponent<CharacterController>();
            Animator = transform.GetChild(0).GetComponent<Animator>();
        }
        else
        {
            cam.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_view.isMine)
        {
            Mvt();
            Anim();
        }
        else
        {
            SmoothMove();
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            TargetPosition = (Vector3) stream.ReceiveNext();
            TargetRotation = (Quaternion) stream.ReceiveNext();
        }
    }

    private void SmoothMove()
    {
        transform.position = Vector3.Lerp(transform.position, TargetPosition, 0.25f);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, TargetRotation, 500 * Time.deltaTime);
    }

    private void Mvt()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) +
                        (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;

        moveDirection.y = yStore;
        
        if (isSpeedBoosted)
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

        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void Anim()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Animator.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Animator.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetBool("isJump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Animator.SetBool("isJump", false);
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            currentTime = startingTime;
            isSpeedBoosted = true;
        }
        
        /*if (other.gameObject.CompareTag("Jump Boost"))
        {
            currentTime = startingTime;
            isJumpBoosted = true;
        }*/
    }
}
