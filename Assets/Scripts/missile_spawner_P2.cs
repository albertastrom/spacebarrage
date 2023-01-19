using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_spawner_P2 : MonoBehaviour
{
    public GameObject missle;
    public Transform aim;
    public GameMaster gm;
 
    void Start()
    {
    

        
    }

    // Update is called once per frame
    void Update()
    {
        
        // when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Return) && gm.isRunning)
        {
            Debug.Log(gm.isRunning);
            // offset aim's rotation by -90 degrees
            aim.Rotate(0, 0, 90);
            
            // spawn a missle
            GameObject clone = Instantiate(missle, aim.position, aim.rotation) as GameObject;
            clone.tag = "Alien_Missile";
        }

        // destroy missle after 5 seconds
        
        
    }
}