using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare_controller : MonoBehaviour
{

    public Rigidbody2D rb;

    public GameObject sender;
    public GameObject flareDetection;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
            Debug.Log("Flare Destroyed - Out of Range");

        }

        
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * 3;
    }

    // on Collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Human_Missile" || col.gameObject.tag == "Alien_Missile")
        {
            
            Destroy(col.gameObject);
            Destroy(gameObject);
            Debug.Log("Flare Destroyed - Missile Collision");
        }
    }

    


}
