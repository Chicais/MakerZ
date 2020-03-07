using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvt : Photon.MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    private PhotonView _view;
    public Camera cam;
    public GameObject pivot;

    void Start()
    {
        _view = GetComponent<PhotonView>();
        
        print(GetComponent<PhotonView>());

        if (_view.isMine)
        {
            controller = GetComponent<CharacterController>();
        }
        else
        {
            cam.enabled = false;
            //Destroy(pivot);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_view.isMine)
            Mvt();
    }

    private void Mvt()
    {
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) +
                        (transform.right * Input.GetAxis("Horizontal"));
        moveDirection = moveDirection.normalized * moveSpeed;

        moveDirection.y = yStore;

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
}
