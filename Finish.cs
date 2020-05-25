using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject winText;
    public static bool winner = false;
    public GameObject loseText;
    public static bool respawn = false;
    public static List<float> times = new List<float>();
    public static List<GameObject> GameObjects = new List<GameObject>();
    public static bool moreRespawn = false;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        loseText.SetActive(false);
        foreach (Transform transform in Waypoints.points)
        {
            if (transform.gameObject.CompareTag("Checkpoint")|| transform.gameObject.CompareTag("Jump Boost") || transform.gameObject.CompareTag("Invincible") || transform.gameObject.CompareTag("Stun"))
            {
                times.Add(3f);
                GameObjects.Add(transform.gameObject);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            for (int i = 0; i < times.Count; i++)
            {
                if (times[i]>0f)
                {
                    times[i] -= 1*Time.deltaTime;
                }

                if (times[i]<=0f)
                {
                    GameObjects[i].SetActive(true);
                    if (!moreRespawn)
                    {
                        respawn = false;
                    }
                }
            }
        }
        
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (!winner)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                winText.SetActive(true);
                winner = true;
            }
            else
            {
                if (other.gameObject.CompareTag("AI"))
                {
                    loseText.SetActive(true);
                    winner = true;
                }
            }
        }
        
    }

    public static void Respawn(GameObject gameObject)
    {
        int i = 0;
        if (respawn)
        {
            moreRespawn = true;
        }
        else
        {
            moreRespawn = false;
        }
        respawn = true;
        foreach (GameObject gameObjects in GameObjects)
        {
            if (ReferenceEquals(gameObject,gameObjects))
            {
                times[i] = 3f;
            }
            else
            {
                i++;
            }
        }
    }

        
}
