using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    public bool useOffsetValue;
    
    public float rotateSpeed;

    public Transform pivot;

    public float maxViewAngle;

    public float minViewAngle;

    public bool invertY;
    
    private int test = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!useOffsetValue)
        {
            offset = target.position - transform.position; 
        }

        pivot.transform.position = target.transform.position;
        pivot.transform.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Get the x position of the mouse and rotate the target
        float horizontal = Input.GetAxis("Mouse X")*rotateSpeed;
        target.Rotate(0, horizontal, 0);

        //Get the y position of the mouse and rotate the pivot
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        //pivot.Rotate(-vertical,0,0);
        if (invertY)
        {
            pivot.Rotate(vertical,0,0);
        }
        else
        {
            pivot.Rotate(-vertical,0,0);
        }
        //Limit up/down
        if (pivot.rotation.eulerAngles.x > maxViewAngle && pivot.rotation.eulerAngles.x < 180f)
        {
            pivot.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
        }
        if (pivot.rotation.eulerAngles.x > 180f && pivot.rotation.eulerAngles.x < 360f+minViewAngle)
        {
            pivot.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
        }
        
        //Move the camera based on the current rotation of the target and the original offset
        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;
        
        Quaternion rotation = Quaternion.Euler(desiredXAngle,desiredYAngle,0);
        transform.position = target.position - (rotation * offset);
         
        //transform.position = target.position - offset;

        if (transform.position.y < target.position.y)
        {
            transform.position = new Vector3(transform.position.x,target.position.y - .5f, transform.position.z);
        }
        
        transform.LookAt(target);

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        /*if (Input.GetKey(KeyCode.Mouse0))
        {
            test++;
            if (test == 2) 
                Cursor.lockState = CursorLockMode.Locked;
            else
            {
                return;
            }
                
            test = test % 2;
        }*/
    }
}
