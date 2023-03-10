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

    new string tag;

    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        origin = GameObject.FindGameObjectWithTag("Human");
    
    }

    void Update()
    {

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
            Debug.Log("portal Destroyed - Out of Range");

        }

        distance = Vector2.Distance(origin.transform.position, gameObject.transform.position);

        if (origin.tag == "Human")
        {
            if (transform.position.x > -1 || transform.position.y > 4 || transform.position.y < -4)
            {
                GameObject newPortal = Instantiate(portal, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                tag = gameObject.tag;
                newPortal.tag = tag;
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag(tag));
            }
        }

        else if (origin.tag == "Alien")
        {
            if (transform.position.x < 1 || transform.position.y > 4 || transform.position.y < -4)
            {
                GameObject newPortal = Instantiate(portal, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                tag = gameObject.tag;
                newPortal.tag = tag;
                Destroy(gameObject);
                Destroy(GameObject.FindGameObjectWithTag(tag));
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = transform.up * speed;
        }
        
        if (Input.GetKeyUp(KeyCode.Space) && distance > 2)
        {
            GameObject newPortal = Instantiate(portal, gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            tag = gameObject.tag;
            newPortal.tag = tag;
            Destroy(gameObject);
            Destroy(GameObject.FindGameObjectWithTag(tag));
            
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
        

        
    }

    void onDestory()
    {
        // particle effect 
        // sound effect
        
    }
}
