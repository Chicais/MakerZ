using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    //public Rigidbody theRD;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

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
        float yStore = moveDirection.y;
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) +
                        (transform.right * Input.GetAxis("Horizontal"));
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

        
    }
}
