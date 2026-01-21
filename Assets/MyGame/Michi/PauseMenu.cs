using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Variables
    public GameObject PausePanel;
    public GameObject SettingsPanel;
    const string START_SCENE = "Start";

    private void Start()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }
        
    //Open Menu
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            SettingsPanel.SetActive(false);

            Time.timeScale = 0;
        }
    }

    //Resume
    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        
        Time.timeScale = 1;
    }

    //Settings
    public void SettingsButton()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);

    }

    //Main Menu
    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(START_SCENE);
    }
}
