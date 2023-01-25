using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal_Controller : MonoBehaviour
{
    public GameObject portal;
    private GameObject origin;
    private Rigidbody2D rb;

    GameMaster gm;

    private float speed = 5f;
    private float distance = 5f;

    new string tag;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        origin = GameObject.FindGameObjectWithTag(gameObject.tag);
    
    }

   void Update()
    {

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
            Debug.Log("Missile Destroyed - Out of Range");

        }

        // if (gm.isPaused) 
        // {
        //     anim.speed=0;
        //     ps.Pause();
        // }
        // else
        // {
        //     anim.speed=1;
        //     ps.Play();
        // }
        
    }

    void FixedUpdate()
    {
        float distanceTraveled = Vector2.Distance(rb.position, origin.transform.position);

        if (distanceTraveled < distance)
        {
            rb.velocity = transform.up * speed;
        }

        else
        {

            GameObject newPortal = Instantiate(portal, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            tag = gameObject.tag + "_Portal";
            newPortal.tag = tag;
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag(tag));
            
        }
        
    }

    void onDestory()
    {
        // particle effect 
        // sound effect
        
    }
}
