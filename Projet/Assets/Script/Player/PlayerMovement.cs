using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Photon.MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;
    
    private Animator Animator;
    private static readonly int IsJump = Animator.StringToHash("isJump");
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Animator = transform.GetChild(0).GetComponent<Animator>();

        print(Animator);
    }

    // Update is called once per frame
    void Update()
    {
        
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
                
                Animator.SetBool("isJump", true);
                print("up space " + IsJump);
            }
        }
        

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale*Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Animator.SetBool("isWalking", true);
            print("down uparrow " + IsWalking);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Animator.SetBool("isWalking", false);
            print("up up arrow " + IsWalking);
        }

        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            Animator.SetBool("isJump", true);
        }*/
        
        if (Input.GetButtonDown("Jump"))
        {
            Animator.SetBool("isJump", false);
            print("down space " + IsJump);
        }
    }
}
