using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_collider : MonoBehaviour

{
    private bool teleported;
    private GameObject missile;
    private homing_missile_controller homing_missile_controller;
    private Transform alienPortalPosition;
    private Transform humanPortalPosition;

    void OnCollisionEnter2D(Collision2D col)
    {
        {
            missile = col.gameObject;
            homing_missile_controller = missile.GetComponent<homing_missile_controller>();
            teleported = homing_missile_controller.teleported;

            if (gameObject.tag == "Human_Portal" && !teleported)
            {
                alienPortalPosition = GameObject.FindGameObjectWithTag("Alien_Portal").transform;
                missile.transform.position = new Vector2(alienPortalPosition.position.x, alienPortalPosition.position.y); 
                homing_missile_controller.teleported = true;

                if (missile.tag == "Alien_Missile")
                {
                    homing_missile_controller.target = GameObject.FindGameObjectWithTag("Alien").transform;
                    homing_missile_controller.transform.Rotate(0, 0, 180);
                }
            }

            else if (gameObject.tag == "Alien_Portal" && !teleported)
            {
                humanPortalPosition = GameObject.FindGameObjectWithTag("Human_Portal").transform;
                missile.transform.position = new Vector2(humanPortalPosition.position.x, humanPortalPosition.position.y); 
                homing_missile_controller.teleported = true;

                if (missile.tag == "Human_Missile")
                {
                    homing_missile_controller.target = GameObject.FindGameObjectWithTag("Human").transform;
                    homing_missile_controller.transform.Rotate(0, 0, 180);
                }
            }
        }
    }
}
