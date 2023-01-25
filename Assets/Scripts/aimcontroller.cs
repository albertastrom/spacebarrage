using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Selection
    {
        Missile = 1,
        Defense = 2,
        Portal = 3
    }

public class aimcontroller : MonoBehaviour
{

    public float direction;
    public float speed = 5f;
    public Selection projectileSelection = Selection.Missile;

    // Start is called before the first frame update
    void Start()
    {
        direction = 0;
    }

    
    void FixedUpdate()
    {
        rotation();
        selection();
        // mouseRotate();
    }

    void rotation()
    {
        // if the left key is pressed, rotate left until 45 degrees has been reached
        if (Input.GetKey(KeyCode.W))
        {
            if (direction < 90)
            {
                direction += 1f;
            }
        }

        // if the right key is pressed, rotate right until 45 degrees has been reached
        else if (Input.GetKey(KeyCode.S))
        {
    
            if (direction > -90)
            {
                direction -= 1f;
            }
        }
        

        // set z rotation of the object by the direction
        transform.eulerAngles = new Vector3(0, 0, direction);
    }

    //seleciton of missile, defense, or portal, rotating through using a and d keys
    void selection()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            int mySelection = (int) projectileSelection;

            if (mySelection > 1)
            {
                mySelection -= 1;
            }

            else if (mySelection == 1)
            {
                mySelection = 3;
            }

            projectileSelection = (Selection) mySelection;
            Debug.Log(mySelection);
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
            int mySelection = (int) projectileSelection;

            if (mySelection < 3)
            {
                mySelection += 1;
            }

            else if (mySelection == 3)
            {
                mySelection = 1;
            }

            projectileSelection = (Selection) mySelection;
            Debug.Log(mySelection);

        }
    }

    void mouseRotate()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }

    public Selection getSelection()
    {
        return projectileSelection;
    }
}
