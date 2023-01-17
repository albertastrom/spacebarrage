using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target_collision : MonoBehaviour
{
    public int health;

    public GameMaster gm;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        isDead();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Human_Missile")
        {
            Destroy(col.gameObject);
            health -= 1;
        }
        Debug.Log("OnCollisionEnter2D");
    }

    void isDead()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            // destroy all missiles
            GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
            foreach (GameObject missile in missiles)
            {
                Destroy(missile);
            }
            // stop game
            gm.isRunning = false;
        }
    }
}
