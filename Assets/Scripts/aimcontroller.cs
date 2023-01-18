using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimcontroller : MonoBehaviour
{

    public float direction;
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    
    void FixedUpdate()
    {
        rotation();
        // mouseRotate();
    }

    void rotation()
    {
        // if the left key is pressed, rotate left until 45 degrees has been reached
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (direction < 45)
            {
                direction += 1f;
            }
        }

        // if the right key is pressed, rotate right until 45 degrees has been reached
        else if (Input.GetKey(KeyCode.RightArrow))
        {
    
            if (direction > -45)
            {
                direction -= 1f;
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
