using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject SettingsPanel;

    private void Start()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            SettingsPanel.SetActive(false);

            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        
        Time.timeScale = 1;
    }

    public void SettingsButton()
    {
        PausePanel.SetActive(false);
        SettingsPanel.SetActive(true);

    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
