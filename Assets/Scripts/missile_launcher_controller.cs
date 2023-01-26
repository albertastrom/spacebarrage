using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missile_launcher_controller : MonoBehaviour
{
    public GameObject missle;
    public GameObject defense;
    public GameObject portal; 

    public GameObject sender;
    public Transform aim;
    public GameMaster gm;

    public Selection mySelection; 

    new string tag;
 
    void Start()
    {
        tag = sender.gameObject.tag + "_Missile";
        
    
    }

    
    void Update()
    {
        mySelection = GameObject.FindGameObjectWithTag("Aim_Controller").GetComponent<aimcontroller>().projectileSelection;

        if (Input.GetKeyDown(KeyCode.Space) && gm.isRunning && !gm.isPaused)
        {
            if (mySelection == Selection.Missile)
            {
                Quaternion rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);
            
            
                GameObject missileClone = Instantiate(missle, aim.position, rot) as GameObject;
                missileClone.tag = tag;
            }

            // else if (aimcontroller.projectileSelection == Selection.Defense)
            // {

            // }

            else if (mySelection == Selection.Portal)
            {
                Quaternion rot = Quaternion.Euler(0, 0, aim.rotation.eulerAngles.z - 90);

                GameObject humanPortal = Instantiate(portal, aim.position, rot) as GameObject;
                humanPortal.tag = sender.tag + "_Portal";

            }
            
        }

    }
}
