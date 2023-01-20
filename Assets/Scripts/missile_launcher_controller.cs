using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_launcher_controller : MonoBehaviour
{
    public GameObject missle;

    public GameObject sender;
    public Transform aim;
    public GameMaster gm;

    new string tag;

 
    void Start()
    {
        tag = sender.gameObject.tag + "_Missile";
        
    
    }

    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && gm.isRunning)
        {

            Quaternion rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);
            
            
            GameObject missileClone = Instantiate(missle, aim.position, rot) as GameObject;
            missileClone.tag = tag;
        }

        
        
    }
}
