using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missile_controller : MonoBehaviour
{
    private Rigidbody2D rb;

    private Transform target;

    GameMaster gm;
    Animator anim;

    private float speed = 5f;
    private float rotationSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Alien").transform;
        anim = GetComponent<Animator>();
        

        
    }

   void Update()
    {

        if (transform.position.x > 10)
        {
            Destroy(gameObject);
            Debug.Log("Missile Destroyed - Out of Range");

        }

        if (gm.isPaused)
        {
            anim.speed=0;
        }
        else
        {
            anim.speed=1;
        }
        
    }

    void FixedUpdate()
    {

        Vector2 direction = (Vector2)target.position - rb.position;

        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotationSpeed;

        rb.velocity = transform.up * speed;
    }

    void onDestory()
    {
        // particle effect 
        // sound effect
        
    }
}
