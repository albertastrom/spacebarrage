using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_spawner : MonoBehaviour
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
            // Debug.Log(gm.isRunning);
            // offset aim's rotation by -90 degrees

            Quaternion rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z + 90);
            
            
            // spawn a missle
            GameObject clone = Instantiate(missle, aim.position, rot) as GameObject;
            clone.tag = "Alien_Missile";
        }

        // destroy missle after 5 seconds
        
        
    }
}