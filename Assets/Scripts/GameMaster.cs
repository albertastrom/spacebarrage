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

    public human_ship_controller human;
    public alien_ship_controller alien;
    
    bool alienIsAlive;
    bool humanIsAlive;
    
    // Start is called before the first frame update
    void Start()
    {
       isRunning = true;
    

    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive();

            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("Human missiles: " + getHumanMissileCount());
                Debug.Log("Alien missiles: " + getAlienMissileCount());
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                if(isPaused)
                {
                    unfreezeHumanMissiles();
                    unfreezeAlienMissiles();
                }
                    
                else
                {
                    freezeHumanMissiles();
                    freezeAlienMissiles();
                }  
                
            }
        }
        
        // in gm check if deads and then proceed to do a stage cleaning setting up for the new game
        else
        {
            // Destroy Ships? 
            // Animation
            // Change Scene to a winner scene 
            Debug.Log("Game Over");
            return;
        }

        // run freeze missile function when "h" is pressed
        

        // freeze all missiles after 2 seconds
        // if (Time.time > 2 && isRunning)
        // {
        //     freezeMissiles();
        //     // isRunning = false;
        // }
        
       
    }

    void alive()
    {
        alienIsAlive = alien.isAlive;
        humanIsAlive = human.isAlive;
        if (!alienIsAlive || !humanIsAlive)
        {
            isRunning = false;
        }
    }

    // return the number of human missiles in the scene
    public int getHumanMissileCount()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return 0;
        }
        return missiles.Length;
        
    }

    public int getAlienMissileCount()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Alien_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return 0;
        }
        return missiles.Length;
    }

    public void freezeHumanMissiles()
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

    public void freezeAlienMissiles()
    {
        // Debug.Log("Freezing missiles");
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Alien_Missile");
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

    public void unfreezeHumanMissiles()
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

    public void unfreezeAlienMissiles()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Alien_Missile");
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
