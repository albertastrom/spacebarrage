using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_ship_controller : MonoBehaviour
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
        if (col.gameObject.tag == "Human_Missile")
        {
            Destroy(col.gameObject);
            health -= 1;
            Debug.Log("Alien ship hit by human missile");
        }
        
    }

    


    void isDead()
    {
        if (health <= 0)
            isAlive = false;
    }

}
