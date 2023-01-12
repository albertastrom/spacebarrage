using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject missle;
    public Transform aim;
    // Start is called before the first frame update
    void Start()
    {
        // print transform.position
        Debug.Log(transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {

        // when spacebar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // spawn a missle
            Instantiate(missle, new Vector3(0, -3.25f, 0), aim.rotation);
        }

        // destroy missle after 5 seconds
        
        
    }
}
