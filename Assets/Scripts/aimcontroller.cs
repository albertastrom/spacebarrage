using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimcontroller : MonoBehaviour
{

    public float direction;
    public float speed = 5f;

    public GameObject sender;


    // Start is called before the first frame update
    void Start()
    {
        if (sender.tag == "Human")
        {
            direction = 0;
        }
        else if (sender.tag == "Alien")
        {
            direction = -180;
        }
        
    }

    
    void FixedUpdate()
    {
        // if human
        if (sender.tag == "Human")
        {
            rotation();
        }
        
        else if (sender.tag == "Alien")
        {
            alienRotation();
        }
        
    }


    void rotation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (direction < 45)
            {
                direction += 1f;
            }
        }

        // if the right key is pressed, rotate right until 45 degrees has been reached
        else if (Input.GetKey(KeyCode.S))
        {
    
            if (direction > -45)
            {
                direction -= 1f;
            }
        }

        

        // set z rotation of the object by the direction
        transform.eulerAngles = new Vector3(0, 0, direction);
    }

    // write the same function as above but all directions are reversed for the alien
    void alienRotation()
    {
        // if the left key is pressed, rotate left until 45 degrees has been reached
        if (Input.GetKey(KeyCode.W))
        {
            if (direction > -225)
            {
                direction -= 1f;
            }
        }

        // if the right key is pressed, rotate right until 45 degrees has been reached
        else if (Input.GetKey(KeyCode.S))
        {
    
            if (direction < -135)
            {
                direction += 1f;
            }
        }

        

        // set z rotation of the object by the direction
        transform.eulerAngles = new Vector3(0, 0, direction);
    }

    void mouseRotate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
