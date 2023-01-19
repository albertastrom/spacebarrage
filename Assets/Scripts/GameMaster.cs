using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    // The game loop

    // Player 1 Display
    // Player one pick a trajectory
    // Player two Display
    // Player two pick a trajectory
    // Round begins - missiles are launched
    // 3 seconds later, missiles are frozen
    // Player one pick a trajectory
    // Player two pick a trajectory
    // Round begins - missiles are launched
    // 3 seconds later, missiles are frozen
    
    public bool isRunning;
    public bool isPaused = false;
    
    // Start is called before the first frame update
    void Start()
    {
       isRunning = true;
        

    }

    // Update is called once per frame
    void Update()
    {
        // run freeze missile function when "h" is pressed
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log(getMissileCount());
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            if(isPaused)
                unfreezeMissiles();
            else
                freezeMissiles();
        }

        // freeze all missiles after 2 seconds
        // if (Time.time > 2 && isRunning)
        // {
        //     freezeMissiles();
        //     // isRunning = false;
        // }
        
        
        




        

    
        
    }

    // return the number of missiles in the scene
    public int getMissileCount()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return 0;
        }
        return missiles.Length;
        
    }

    public void freezeMissiles()
    {
        // Debug.Log("Freezing missiles");
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return;
        }
        foreach (GameObject missile in missiles)
        {
            missile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        isPaused = true;
    }

    public void unfreezeMissiles()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return;
        }
        foreach (GameObject missile in missiles)
        {
            missile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        isPaused = false;
    }
}
