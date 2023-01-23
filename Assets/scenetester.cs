using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scenetester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when l is pressed load battlefield scene
        if (Input.GetKeyDown(KeyCode.L))
        {
            // SceneManager.LoadScene("BattleField");
            UnityEngine.SceneManagement.SceneManager.LoadScene("BattleField");
        }
    }
}
