using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_launcher_controller : MonoBehaviour
{
    public GameObject missle;

    public GameObject flare;

    public GameObject sender;

    public aimcontroller aim_controller;
    public Transform aim;
    public GameMaster gm;

    public bool selected;

    new string tag;

    Quaternion rot;
    
    public bool angle;


 
    void Start()
    {
        // tag = sender.gameObject.tag + "_Missile";
        selected = false;
        rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);
        angle = false;
    
    }

    
    void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.Space) && gm.isRunning && (gm.phase == "p1" || gm.phase == "p2") )
        {

            rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);
            
            // this should be the spot that spaws the indicator showing where the missile is going to go
            angle = true;
        }

        

        

        
        
    }

    public void ready()
    {
        Debug.Log("Missile ready");
        if (angle)
        {   
            selected = true;
        }
            
    }

    public string getEquipment()
    {
        return aim_controller.getEquipment();
    }

    public void launchMissile()
    {
        Debug.Log("Missile launched");
        GameObject missileClone = Instantiate(missle, aim.position, rot) as GameObject;
        missileClone.tag = sender.gameObject.tag + "_Missile";
        selected = false;
        angle = false; 
    }

    public void launchFlare()
    {
        Debug.Log("Flare launched");
        GameObject flareClone = Instantiate(flare, aim.position, rot) as GameObject;
        flareClone.tag = sender.gameObject.tag + "_Flare";
        selected = false;
        angle = false; 
    }
}
