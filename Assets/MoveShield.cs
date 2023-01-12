using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShield : MonoBehaviour
{
    public float shieldX;
    public float shieldY;
    public float shieldDirection;

    // Start is called before the first frame update
    void Start()
    {
        shieldX = 0;
        shieldY = 0;
        shieldDirection = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // check if left arrow key was pressed
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // move shield left if x greater than -5
            if (shieldX > -5)
            {
                shieldX -= (float) 0.01;
            }
            
        }
        
        // check if right arrow key was pressed
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            // move shield right if x less than 5
            if (shieldX < 5)
            {
                shieldX += (float) 0.01;
            }
            
        }

        //check if up arrow was pressed
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            // move shield up if y is less than 5
            if (shieldY < 5)
            {
                shieldY += (float) 0.01;
            }
            
        }

        //check if down arrow is pressed
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // move shield down if y greater than -5
            if (shieldY > -5)
            {
                shieldY -= (float) 0.01;
            }
            
        }

        //check to see if A is pressed
        else if (Input.GetKey(KeyCode.A))
        {
            //rotate spaceship left 
            shieldDirection -= 1;
        }

        //check to see if D is pressed
        else if (Input.GetKey(KeyCode.D))
        {
            //rotate spaceship right
            shieldDirection += 1;
        }

        else if (Input.GetKey(KeyCode.R))
        {
            shieldDirection = 0;
            shieldX = 0;
            shieldY = 0;
        }
    }
}
