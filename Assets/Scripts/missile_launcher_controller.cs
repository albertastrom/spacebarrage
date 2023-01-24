using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_launcher_controller : MonoBehaviour
{
    public GameObject missle;

    public GameObject sender;
    public Transform aim;
    public GameMaster gm;

    public bool selected;

    new string tag;

    Quaternion rot;

 
    void Start()
    {
        tag = sender.gameObject.tag + "_Missile";
        selected = false;
        rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);
    
    }

    
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space) && gm.isRunning && !gm.isPaused)
        {

            rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);
            
            selected = true;
            
        }

        

        
        
    }

    public void launchMissile()
    {
        Debug.Log("Missile launched");
        GameObject missileClone = Instantiate(missle, aim.position, rot) as GameObject;
        missileClone.tag = tag;
        selected = false;
    }
}
