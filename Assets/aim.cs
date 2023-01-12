using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aim : MonoBehaviour
{
    public float direction;
    public Transform transform;
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        // set initial direction to 0 - pointing straight ahead
        direction = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // check if left arrow key was pressed
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // rotate left if direction is not less than -45
            if (direction > -45)
            {
                direction -= .05f;
            }
            
        }
        // check if right arrow key was pressed
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            // rotate right if direction is not more than 45
            if (direction < 45)
            {
                direction += .050f;
            }
            
        }
        else
        {
            // stop rotating
            // direction = 0;
        }

        // set z rotation of the object by the direction
        transform.eulerAngles = new Vector3(0, 0, direction + 180);
        

    }
}
