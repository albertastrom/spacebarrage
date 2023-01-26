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
    
    public string phase;
    public bool isRunning;
    public bool isPaused;

    public human_ship_controller human;
    public alien_ship_controller alien;

    public missile_launcher_controller humanMissileLauncher;
    public missile_launcher_controller alienMissileLauncher;
    
    bool alienIsAlive;
    bool humanIsAlive;

    public GameObject canvas;    
    GameObject turnScreen;
    GameObject UI;
    GameObject P1Aim;
    GameObject P2Aim;

    private Button humanButton;
    private Button alienButton;

    private Button battleButton;
    private GameObject battleView;

    
    
    // Start is called before the first frame update
    void Start()
    {
        UI = canvas.transform.Find("UI").gameObject;
        humanButton = UI.transform.Find("Player1").gameObject.transform.Find("Player 1 Ready").gameObject.GetComponent<Button>();
        alienButton = UI.transform.Find("Player2").gameObject.transform.Find("Player 2 Ready").gameObject.GetComponent<Button>();
        battleButton = UI.transform.Find("BattleView").gameObject.transform.Find("Battle Ready").gameObject.GetComponent<Button>();

        battleView = UI.transform.Find("BattleView").gameObject;
        battleView.SetActive(false);
        

        battleButton.interactable = false;


        P1Aim = GameObject.Find("HumanAimController").gameObject;
        P2Aim = GameObject.Find("AlienAimController").gameObject;
        
        P1Aim.SetActive(false);
        P2Aim.SetActive(false);
        phase = "p1 prompt";
        phaseHandler();
        isRunning = true;
        pause();
    
    }

    // Update is called once per frame
    void Update()
    {
        // if phase is p1 prompt, if space is pressed, disable turn screen
        if (phase == "p1 pre" || phase == "p2 pre")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                phaseHandler();
            }
        }
        if (phase == "p1")
        {
            if (humanMissileLauncher.selected)
            {
                phaseHandler();
            }
        }
        if (phase == "p2")
        {
            if (alienMissileLauncher.selected)
            {
                phaseHandler();
            }
        }

        p1UIController();
        p2UIController();
        battleUIController();


        // if (phase == "p2")
        // {
        //     if (alienMissileLauncher.selected)
        //     {
        //         phaseHandler();
        //     }
        // }

        if (isRunning)
        {
            alive();

            buttonHandler();



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

            if (isPaused)
            {
                freezeAlienMissiles();
                freezeHumanMissiles();
                freezeAlienFlares();
                freezeHumanFlares();
            }
            else
            {
                unfreezeAlienMissiles();
                unfreezeHumanMissiles();
                unfreezeAlienFlares();
                unfreezeHumanFlares();
            }

            // if y is pressed, phase handler is called
            if (Input.GetKeyDown(KeyCode.Y))
            {
                phaseHandler();
            }
        }
        
        // in gm check if deads and then proceed to do a stage cleaning setting up for the new game
        else
        {
            // Destroy Ships? 
            // Animation
            // Change Scene to a winner scene 
            // Debug.Log("Game Over");
            if (human.isAlive)
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver - Alien");
            else
                UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver - Human");
            return;
        }

        
       
    }

    void buttonHandler()
    {
        if (humanMissileLauncher.angle)
            humanButton.interactable = true;
        else
            humanButton.interactable = false;

        if (alienMissileLauncher.angle)
            alienButton.interactable = true;
        else
            alienButton.interactable = false;
    }

    // player one phase 
    void phaseHandler()
    {
        // Player 1 Pre Outloop 
        if (phase == "p1 prompt")
        {
            Debug.Log("PLAYER ONE PRE PHASE OUT");
            turnScreen = canvas.transform.Find("Turn Screen").gameObject;
            GameObject text = turnScreen.transform.Find("Player 1 Prompt").gameObject;
            turnScreen.SetActive(true);
            text.SetActive(true);
            phase = "p1 pre";
        }

        // Player 1 Phase
        else if (phase == "p1 pre")
        {
            Debug.Log("PLAYER ONE PHASE");
            pause();
            GameObject text = turnScreen.transform.Find("Player 1 Prompt").gameObject;
            text.SetActive(false);
            turnScreen.SetActive(false);
            // isPaused = false;
            GameObject p1UI = UI.transform.Find("Player1").gameObject;
            p1UI.SetActive(true);
            P1Aim.SetActive(true);
            phase = "p1";
        }

        // Player 2 Pre Phase
        else if (phase == "p1")
        {
            Debug.Log("PLAYER TWO PRE PHASE");
            // pause game
            pause();
            GameObject p1UI = UI.transform.Find("Player1").gameObject;
            p1UI.SetActive(false);
            P1Aim.SetActive(false);
            GameObject text = turnScreen.transform.Find("Player 2 Prompt").gameObject;
            turnScreen.SetActive(true);
            text.SetActive(true);
            phase = "p2 pre";
            
        }

        // Player 2 Phase
        else if (phase == "p2 pre")
        {
            Debug.Log("PLAYER TWO PHASE");
            pause();
            GameObject text = turnScreen.transform.Find("Player 2 Prompt").gameObject;
            text.SetActive(false);
            turnScreen.SetActive(false);
            // isPaused = false;
            GameObject p2UI = UI.transform.Find("Player2").gameObject;
            p2UI.SetActive(true);
            P2Aim.SetActive(true);
            phase = "p2";
        }

        // Battle Phase
        else if (phase == "p2")
        {
            // pause game
            unpause();
            GameObject p2UI = UI.transform.Find("Player2").gameObject;
            p2UI.SetActive(false);
            P2Aim.SetActive(false);
            
            // This is where the unified missile launch function will be called
            // missileLaunch();
            // The UI will be the multiplayer UI
            Debug.Log("Battle");
            phase = "battle";
            // humanMissileLauncher.launchMissile();
            // alienMissileLauncher.launchMissile();

            if (humanMissileLauncher.getEquipment() == "flare")
            {
                Debug.Log("Flare Launched - Human");
                humanMissileLauncher.launchFlare();
            }
            if (humanMissileLauncher.getEquipment() == "missile")
            {
                Debug.Log("Missile Launched - Human");
                humanMissileLauncher.launchMissile();
            }
            if (humanMissileLauncher.getEquipment() == "portal")
            {
                Debug.Log("Portal Launched - Human");
                humanMissileLauncher.launchPortal();
            }
            if (alienMissileLauncher.getEquipment() == "flare")
            {
                Debug.Log("Flare Launched - Alien");
                alienMissileLauncher.launchFlare();
            }
            if (alienMissileLauncher.getEquipment() == "missile")
            {
                Debug.Log("Missile Launched - Alien");
                alienMissileLauncher.launchMissile();
            }
            if (alienMissileLauncher.getEquipment() == "portal")
            {
                Debug.Log("Portal Launched - Alien");
                alienMissileLauncher.launchPortal();
            }

            Debug.Log(humanMissileLauncher.getEquipment());
            Debug.Log(alienMissileLauncher.getEquipment());
            // wait two seconds and then call the phase handler

            // enable the battle gui 
            battleView.SetActive(true);
            Invoke("pause", .6f);

            // enable button here 
            battleButton.interactable = true;
            // Invoke("phaseHandler", 3f); // this should be changed to waiting for the ready/continue button to be pressed in the gui 
            
        }
        // P1 Pre Phase in loop
        else if (phase == "battle")
        {
            Debug.Log("PLAYER ONE PRE PHASE");
            battleView.SetActive(false);
            battleButton.interactable = false;
            pause();
            GameObject text = turnScreen.transform.Find("Player 1 Prompt").gameObject;
            turnScreen.SetActive(true);
            text.SetActive(true);
            phase = "p1 pre";
        }
        

        
    }

    public void ready()
    {
        phaseHandler();
    }

    void battleUIController()
    {
        int humanHealth = human.health;
        int humanShield = human.shield;
        int alienHealth = alien.health;
        int alienShield = alien.shield;

        GameObject humanShipStatus = UI.transform.Find("BattleView").gameObject.transform.Find("P1 Ship Status").gameObject;
        Text humanHealthBar = humanShipStatus.transform.Find("P1 Health").gameObject.GetComponent<Text>();
        Text humanShieldBar = humanShipStatus.transform.Find("P1 Shield").gameObject.GetComponent<Text>();

        GameObject alienShipStatus = UI.transform.Find("BattleView").gameObject.transform.Find("P2 Ship Status").gameObject;
        Text alienHealthBar = alienShipStatus.transform.Find("P2 Health").gameObject.GetComponent<Text>();
        Text alienShieldBar = alienShipStatus.transform.Find("P2 Shield").gameObject.GetComponent<Text>();

        humanHealthBar.text = "<color=#ef233c>HP</color> " + humanHealth + "/2";
        humanShieldBar.text = "<color=#90E0EF>SP</color> " + humanShield + "/3";

        alienHealthBar.text = "<color=#ef233c>HP</color> " + alienHealth + "/2";
        alienShieldBar.text = "<color=#90E0EF>SP</color> " + alienShield + "/3";

    }

    void p1UIController()
    {
        int humanHealth = human.health;
        int humanShield = human.shield;
        

        GameObject humanShipStatus = UI.transform.Find("Player1").gameObject.transform.Find("P1 Ship Status").gameObject;
        Text humanHealthBar = humanShipStatus.transform.Find("P1 Health").gameObject.GetComponent<Text>();
        Text humanShieldBar = humanShipStatus.transform.Find("P1 Shield").gameObject.GetComponent<Text>();
        Text humanEquipment = humanShipStatus.transform.Find("P1 Equipment").gameObject.transform.Find("P1 Equip").gameObject.GetComponent<Text>();

        humanHealthBar.text = "<color=#ef233c>HP</color> " + humanHealth + "/2";
        humanShieldBar.text = "<color=#90E0EF>SP</color> " + humanShield + "/3";
        
        string equip;
        equip = FirstLetterToUpper(humanMissileLauncher.getEquipment());
        if (equip == "Missile")
        {
            equip = "<color=#FB3640>Missile</color>";
        }

        if (equip == "Flare")
        {
            equip = "<color=#247BA0>Flare</color>";
        }

        if (equip == "Portal")
        {
            equip = "<color=#E2E2E2>Portal</color>";
        }
        humanEquipment.text = equip;
    
    }

    void p2UIController()
    {
        int alienHealth = alien.health;
        int alienShield = alien.shield;
        

        GameObject alienShipStatus = UI.transform.Find("Player2").gameObject.transform.Find("P2 Ship Status").gameObject;
        Text alienHealthBar = alienShipStatus.transform.Find("P2 Health").gameObject.GetComponent<Text>();
        Text alienShieldBar = alienShipStatus.transform.Find("P2 Shield").gameObject.GetComponent<Text>();
        Text alienEquipment = alienShipStatus.transform.Find("P2 Equipment").gameObject.transform.Find("P2 Equip").gameObject.GetComponent<Text>();

        alienHealthBar.text = "<color=#ef233c>HP</color> " + alienHealth + "/2";
        alienShieldBar.text = "<color=#90E0EF>SP</color> " + alienShield + "/3";
        string equip;
        equip = FirstLetterToUpper(alienMissileLauncher.getEquipment());
        if (equip == "Missile")
        {
            equip = "<color=#FB3640>Missile</color>";
        }

        if (equip == "Flare")
        {
            equip = "<color=#247BA0>Flare</color>";
        }

        if (equip == "Portal")
        {
            equip = "<color=#E2E2E2>Portal</color>";
        }

        alienEquipment.text = equip;

        
        // Captialize the first letter of the equipment string



    }

    public string FirstLetterToUpper(string str)
    {
        if (str == null)
            return null;

        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
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

    public void freezeHumanFlares()
    {
        // Debug.Log("Freezing missiles");
        GameObject[] flares = GameObject.FindGameObjectsWithTag("Human_Flare");
        // if missiles have been destroyed, return 0
        if (flares == null)
        {
            return;
        }
        foreach (GameObject flare in flares)
        {
            flare.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        isPaused = true;
    }

    public void freezeAlienFlares()
    {
        // Debug.Log("Freezing missiles");
        GameObject[] flares = GameObject.FindGameObjectsWithTag("Alien_Flare");
        // if missiles have been destroyed, return 0
        if (flares == null)
        {
            return;
        }
        foreach (GameObject flare in flares)
        {
            flare.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
        isPaused = true;
    }

    public void unfreezeHumanFlares()
    {
        GameObject[] flares = GameObject.FindGameObjectsWithTag("Human_Flare");
        // if missiles have been destroyed, return 0
        if (flares == null)
        {
            return;
        }
        foreach (GameObject flare in flares)
        {
            flare.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            flare.GetComponent<Rigidbody2D>().velocity = transform.up * 3;
        
        }
        isPaused = false;
    }

    public void unfreezeAlienFlares()
    {
        GameObject[] flares = GameObject.FindGameObjectsWithTag("Alien_Flare");
        // if missiles have been destroyed, return 0
        if (flares == null)
        {
            return;
        }
        foreach (GameObject flare in flares)
        {
            flare.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
        isPaused = false;
    }
    

    public void pause()
    {
        isPaused = true;
    }

    public void unpause()
    {
        isPaused = false;
    }
}


