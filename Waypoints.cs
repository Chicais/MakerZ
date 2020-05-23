using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    public Transform player;
    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            Transform tr = transform.GetChild(i);
            points[i] = tr;
        }
        SortWithDistance(points);
    }
    
    public static void Swap(ref Transform lhs, ref Transform rhs)
    {
        var tmp = lhs;
        lhs = rhs;
        rhs = tmp;
    }
    
    public void SortWithDistance(Transform[] arr)
    {
        float distance = Vector3.Distance(player.position, arr[0].position);
        var n = arr.Length;
        if (n <= 1)
        {
            return;
        }
        while (n != 0)
        {
            var new_n = 0;
            for (var i = 1; i < n; i++)
            {
                if (Vector3.Distance(player.position, arr[i-1].position) <= Vector3.Distance(player.position, arr[i].position))
                    continue;
                Swap(ref arr[i - 1], ref arr[i]);
                new_n = i;
            }
            n = new_n;
        }
    }
}
