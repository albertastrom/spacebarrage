using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    
    public bool isRunning;
    
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
}
