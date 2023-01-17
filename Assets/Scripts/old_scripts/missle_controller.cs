using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missle_controller : MonoBehaviour
{ 
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // scale down the missle to 90%
        transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

        // set velocity of the missle to in the direction it is facing
        rb.velocity = transform.up * 5;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
        
    }
}
