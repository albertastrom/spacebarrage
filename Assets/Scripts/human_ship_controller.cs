using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class human_ship_controller : MonoBehaviour
{

    public GameMaster gm;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
