using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flare_controller : MonoBehaviour
{

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 3;
        
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
}
