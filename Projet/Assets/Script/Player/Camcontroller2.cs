
using System.IO;
using UnityEngine;


public class Camcontroller2 : Photon.MonoBehaviour
{
    public Transform player2;
    public Vector3 offset;
    public bool useOffsetValue;
    public float rotateSpeed;
    public Transform pivot2;
    public float maxViewAngle;
    public float minViewAngle;
    public bool invertY;
    
    //private PhotonView _view;
    
    // Start is called before the first frame update
    void Start()
    {

        if (!useOffsetValue)
        {
            offset = player2.position - transform.position; 
        }

        pivot2.transform.parent = player2.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if(_view.isMine)
        {
            float horizontal = Input.GetAxis("Mouse X")*rotateSpeed;
            player2.Rotate(0, horizontal, 0);

            //Get the y position of the mouse and rotate the pivot
            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            //pivot.Rotate(-vertical,0,0);
            if (invertY)
            {
                pivot2.Rotate(vertical,0,0);
            }
            else
            {
                pivot2.Rotate(-vertical,0,0);
            }
            //Limit up/down
            if (pivot2.rotation.eulerAngles.x > maxViewAngle && pivot2.rotation.eulerAngles.x < 180f)
            {
                pivot2.rotation = Quaternion.Euler(maxViewAngle, 0, 0);
            }
            if (pivot2.rotation.eulerAngles.x > 180f && pivot2.rotation.eulerAngles.x < 360f+minViewAngle)
            {
                pivot2.rotation = Quaternion.Euler(360f + minViewAngle, 0, 0);
            }
        
            //Move the camera based on the current rotation of the target and the original offset
            float desiredYAngle = player2.eulerAngles.y;
            float desiredXAngle = pivot2.eulerAngles.x;
        
            Quaternion rotation = Quaternion.Euler(desiredXAngle,desiredYAngle,0);
            transform.position = player2.position - (rotation * offset);
         
            //transform.position = target.position - offset;

            if (transform.position.y < player2.position.y)
            {
                transform.position = new Vector3(transform.position.x,player2.position.y - .5f, transform.position.z);
            }
        
            transform.LookAt(player2);
        }
    }
}
