using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimcontroller : MonoBehaviour
{

    public float direction;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        rotation();
    }

    void rotation()
    {
        // if the left key is pressed, rotate left until 45 degrees has been reached
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (direction < 45)
            {
                direction += .05f;
            }
        }

        // if the right key is pressed, rotate right until 45 degrees has been reached
        else if (Input.GetKey(KeyCode.RightArrow))
        {
    
            if (direction > -45)
            {
                direction -= .050f;
            }
        }
        else
        {
            // stop rotating
            // direction = 0;
        }

        // set z rotation of the object by the direction
        transform.eulerAngles = new Vector3(0, 0, direction);
    }
}
