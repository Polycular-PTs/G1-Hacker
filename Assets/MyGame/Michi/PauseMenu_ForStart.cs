using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu_ForStart : MonoBehaviour
{
    //Variables
    public GameObject SettingsPanel;
        
    //Open Menu
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.SetActive(false);

            Time.timeScale = 0;
        }
    }
    
    //Settings
    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);

    }    
}
