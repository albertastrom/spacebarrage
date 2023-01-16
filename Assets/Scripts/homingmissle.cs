using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingmissle : MonoBehaviour
{
    public Transform target;

    public float speed = 5f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        
        target = GameObject.FindGameObjectWithTag("Alien").transform;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotationSpeed;

        rb.velocity = transform.up * speed;
        
    }
}
