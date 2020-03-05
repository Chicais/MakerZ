using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float Speed = 2F;
    private Animator Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Speed * Time.deltaTime);
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Speed * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Anim.SetBool("isWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetBool("isJump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Anim.SetBool("isJump", false);
        }
    }
}
