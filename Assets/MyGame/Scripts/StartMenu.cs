using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject UiManager;
    public GameObject SettingsPanel;

    public void TutorialButton()
    {
        SceneManager.LoadScene("TUT");
    }
    
    public void StartButton()
    {
        SceneManager.LoadScene("Story");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
        UiManager.SetActive(false);

        Time.timeScale = 1;
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.SetActive(false);
            UiManager.SetActive(true);

            Time.timeScale = 0;
        }
    }
}
