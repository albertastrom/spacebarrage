using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_ship_controller : MonoBehaviour
{

    public GameMaster gm;
    int health;
    Animator anim;

    public bool isAlive;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        health = 3;
        isAlive = true;
        
    }


    void Update()
    {
        isDead();
        
        // if (gm.isPaused && gm.phase != "p1" && gm.phase != "p2") - this line would allow for the animation to keep going in the missile paused phases 
        if (gm.isPaused)
        {
            anim.speed=0;
        }
        else
        {
            anim.speed=1;
        }


        // {
        //     anim.SetBool("isRunning", true);
        // }
        // else
        // {
        //     anim.SetBool("isRunning", false);
        // }
        
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Alien_Missile")
        {
            Destroy(col.gameObject);
            health -= 1;
            Debug.Log("Human ship hit by alien missile");
        }
        
    }

    // in gm check if deads and then proceed to do a stage cleaning setting up for the new game


    void isDead()
    {
        if (health <= 0)
        {
            isAlive = false;

            // Destroy(gameObject);
            // // destroy all missiles
            // GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
            // missiles += GameObject.FindGameObjectsWithTag("Alien_Missile");
            // foreach (GameObject missile in missiles)
            // {
            //     Destroy(missile);
            // }
            // // stop game
            // gm.isRunning = false;
        }
    }
    
}
