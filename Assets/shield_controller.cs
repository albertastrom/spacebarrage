using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_controller : MonoBehaviour
{

    int shield;


    GameMaster gm;
    public GameObject parentShip;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        anim = GetComponent<Animator>();
        shield = 3; 
    }

    // Update is called once per frame
    void Update()
    {
        alive();
        if (gm.isPaused)
        {
            anim.speed=0;
        }
        else
        {
            anim.speed=1;
        }
        
    }

    // collider
    void OnCollisionEnter2D(Collision2D col)
    {
        

        if ((col.gameObject.tag == "Alien_Missile" && parentShip.tag == "Human") || (col.gameObject.tag == "Human_Missile" && parentShip.tag == "Alien"))
        {
            Destroy(col.gameObject);
            shield -= 1;
            Debug.Log("Shield hit");
            AudioManager.instance.Play("Deflect");
        }

        if ((col.gameObject.tag == "Human_Flare" && parentShip.tag == "Alien") || (col.gameObject.tag == "Alien_Flare" && parentShip.tag == "Human"))
        {
            Destroy(col.gameObject);
            Debug.Log("Flare Destroyed - Shield");
        }
    }

    public int getShield()
    {
        return shield;
        
    }

    void alive()
    {
        if (shield == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
