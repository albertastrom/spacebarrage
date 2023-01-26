using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homing_missile_controller : MonoBehaviour
{
    public bool teleported;
    public Rigidbody2D rb;

    public Transform target;

    GameMaster gm;
    Animator anim;

    public ParticleSystem ps;

    private float speed = 5f;
    private float rotationSpeed = 80f;

    // Start is called before the first frame update
    void Start()
    {
        teleported = false;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
        rb = GetComponent<Rigidbody2D>();
        // if tag is human missile then target alien ship
        // if tag is alien missile then target human ship
        if (gameObject.tag == "Human_Missile")
        {
            target = GameObject.FindGameObjectWithTag("Alien").transform;
        }
        else if (gameObject.tag == "Alien_Missile")
        {
            target = GameObject.FindGameObjectWithTag("Human").transform;
        }
        
        anim = GetComponent<Animator>();
        ps.Emit(1);
        ps.Play();
        
        

        
    }

   void Update()
    {

        if (transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 5 || transform.position.y < -5)
        {
            Destroy(gameObject);
            Debug.Log("Missile Destroyed - Out of Range");

        }

        if (gm.isPaused)
        {
            anim.speed=0;
            ps.Pause();
        }
        else
        {
            anim.speed=1;
            ps.Play();
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
