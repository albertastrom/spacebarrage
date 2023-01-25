using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal_collider : MonoBehaviour

{
private Transform alienPortalPosition;
private Transform humanPortalPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        {
            Debug.Log("collision");
            if (gameObject.tag == "Human_Portal")
            {
                alienPortalPosition = GameObject.FindGameObjectWithTag("Alien_Portal").transform;
                col.gameObject.transform.position = new Vector2(alienPortalPosition.position.x, alienPortalPosition.position.y); 
            }

            else if (gameObject.tag == "Human_Portal")
            {
                humanPortalPosition = GameObject.FindGameObjectWithTag("Human_Portal").transform;
                col.gameObject.transform.position = new Vector2(humanPortalPosition.position.x, humanPortalPosition.position.y); 
            }
        }
    }
}
