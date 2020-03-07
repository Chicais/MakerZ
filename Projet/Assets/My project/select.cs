using System;
using System.Collections;
using System.Collections.Generic;
// NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.Serialization;

public class select : MonoBehaviour
{
    public GameObject bloc;
    public GameObject abc;
    private GameObject bloc2;
    
    

    public void Clic()
    {
        bloc2 = Instantiate(bloc);
        Screen.lockCursor = true;
    }

    void Update()
    {
        //bloc2.transform.Translate( Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"),0);

        if (Input.GetMouseButtonDown(0))
        {
            bloc2 = Instantiate(abc);
        }
    }
}
