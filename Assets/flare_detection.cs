using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare_detection : MonoBehaviour
{

    Transform originalTarget;


    private float timeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (timeRemaining > 0)
        // {
        //     timeRemaining -= Time.deltaTime;
        // }
        // else
        // {
        //     // realign(missile, originalTarget);
            
        //     Debug.Log("5 second passed");
        // }
        

        
    }

    // on Collision

    // On trigger
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Human_Missile" || col.gameObject.tag == "Alien_Missile")
        {
            Debug.Log("Missile Detected - Enter");
            homing_missile_controller missile = col.gameObject.GetComponent<homing_missile_controller>();
            originalTarget = missile.target;
            missile.target = gameObject.transform;
            Debug.Log("Missile Target Changed" + missile.target.name);
        }
    }

    // on trigger exit
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Human_Missile" || col.gameObject.tag == "Alien_Missile")
        {
            Debug.Log("Missile Detected - Exit");
            homing_missile_controller missile = col.gameObject.GetComponent<homing_missile_controller>();
            // call realign function after 1 second has passed
           
            Debug.Log("Missile Realigning" + missile.target.name);
            Debug.Log(originalTarget.name);
            StartCoroutine(realign(missile, realignCallback));
            Debug.Log("Missile Realigned" + missile.target.name);
            
            
            
            
        }
    }
    

    // INSANE KNOWLEDGE HERE USING COROUTINES AND DELEGATES
    private void realignCallback(homing_missile_controller missile) {
        missile.target = originalTarget;
        Debug.Log("Missile target changed back to " + originalTarget.name);
    }

    IEnumerator realign(homing_missile_controller missile, Action<homing_missile_controller> callback) {
        yield return new WaitForSeconds(.8f);
        callback(missile);
    }


    

    
}
