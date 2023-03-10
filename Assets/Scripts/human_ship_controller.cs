using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_ship_controller : MonoBehaviour
{

    public GameMaster gm;

    public int shield;
    public int health;
    Animator anim;

    public shield_controller myShield;


    public bool isAlive;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        shield = 3;
        health = 2;
        isAlive = true;

        
        
    }


    void Update()
    {
        isDead();
        shield = myShield.getShield();
        
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
        if (col.gameObject.tag == "Alien_Missile" && shield <= 0)
        {
            Destroy(col.gameObject);
            health -= 1;
            Debug.Log("Human ship hit by alien missile" + shield);
            AudioManager.instance.Play("Explosion");
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
