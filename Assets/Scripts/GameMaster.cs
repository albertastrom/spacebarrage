using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    // The game loop

    // Player 1 Display
    // Player one pick a trajectory
    // Player two Display
    // Player two pick a trajectory
    // Round begins - missiles are launched
    // 3 seconds later, missiles are frozen
    // Player one pick a trajectory
    // Player two pick a trajectory
    // Round begins - missiles are launched
    // 3 seconds later, missiles are frozen
    
    static string phase;
    public bool isRunning;
    public bool isPaused;

    public human_ship_controller human;
    public alien_ship_controller alien;
    
    bool alienIsAlive;
    bool humanIsAlive;

    public GameObject canvas;    
    GameObject turnScreen;
    GameObject UI;
    GameObject P1Aim;
    
    // Start is called before the first frame update
    void Start()
    {
        UI = canvas.transform.Find("UI").gameObject;
        phase = "p1 prompt";
        p1();
        isRunning = true;
        isPaused = true;
    
    }

    // Update is called once per frame
    void Update()
    {
        // if phase is p1 prompt, if space is pressed, disable turn screen
        if (phase == "p1 prompt")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                turnScreen.SetActive(false);
                isPaused = false;
                phase = "p1 pre";
                p1();
            }
        }

        if (isRunning)
        {
            alive();

            if (Input.GetKeyDown(KeyCode.H))
            {
                Debug.Log("Human missiles: " + getHumanMissileCount());
                Debug.Log("Alien missiles: " + getAlienMissileCount());
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                if(isPaused)
                {
                    unfreezeHumanMissiles();
                    unfreezeAlienMissiles();
                }
                    
                else
                {
                    freezeHumanMissiles();
                    freezeAlienMissiles();
                }  
            }
        }
        
        // in gm check if deads and then proceed to do a stage cleaning setting up for the new game
        else
        {
            // Destroy Ships? 
            // Animation
            // Change Scene to a winner scene 
            // Debug.Log("Game Over");
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
            return;
        }

        // run freeze missile function when "h" is pressed
        

        // freeze all missiles after 2 seconds
        // if (Time.time > 2 && isRunning)
        // {
        //     freezeMissiles();
        //     // isRunning = false;
        // }
        
       
    }

    // player one phase 
    void p1()
    {
        if (phase == "p1 prompt")
        {
            turnScreen = canvas.transform.Find("Turn Screen").gameObject;
            GameObject text = turnScreen.transform.Find("Player 1 Prompt").gameObject;
            turnScreen.SetActive(true);
            text.SetActive(true);
        }

        if (phase == "p1 pre")
        {
            GameObject p1UI = UI.transform.Find("Player1").gameObject;
            p1UI.SetActive(true);
            // load the aim controller for player 1
            P1Aim = GameObject.Find("HumanAimController").gameObject;
            P1Aim.SetActive(true);
            phase = "p1";
        }

        if (phase == "p1")
        {
            
        }
        
        // Turn on turn screen and player 1 prompt ui items 
    
        // pause game state 
        // turn on player 1 ui

        // wait for ready to be pressed
        // disable turn screen for player 1
        // unpause game state
        

        
    }

    void alive()
    {
        alienIsAlive = alien.isAlive;
        humanIsAlive = human.isAlive;
        if (!alienIsAlive || !humanIsAlive)
        {
            isRunning = false;
        }
    }

   
    public int getHumanMissileCount()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return 0;
        }
        return missiles.Length;
        
    }

    public int getAlienMissileCount()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Alien_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return 0;
        }
        return missiles.Length;
    }

    public void freezeHumanMissiles()
    {
        // Debug.Log("Freezing missiles");
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return;
        }
        foreach (GameObject missile in missiles)
        {
            missile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        isPaused = true;
    }

    public void freezeAlienMissiles()
    {
        // Debug.Log("Freezing missiles");
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Alien_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return;
        }
        foreach (GameObject missile in missiles)
        {
            missile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        isPaused = true;
    }

    public void unfreezeHumanMissiles()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Human_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return;
        }
        foreach (GameObject missile in missiles)
        {
            missile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        isPaused = false;
    }

    public void unfreezeAlienMissiles()
    {
        GameObject[] missiles = GameObject.FindGameObjectsWithTag("Alien_Missile");
        // if missiles have been destroyed, return 0
        if (missiles == null)
        {
            return;
        }
        foreach (GameObject missile in missiles)
        {
            missile.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        isPaused = false;
    }
}
