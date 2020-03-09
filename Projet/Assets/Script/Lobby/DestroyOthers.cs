using System.Collections;
using UnityEngine;

public class DestroyOthers : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);

        /*if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(this);
        }*/
            
    }
}
