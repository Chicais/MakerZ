
using UnityEngine;

public class DestroyOthers : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

}
