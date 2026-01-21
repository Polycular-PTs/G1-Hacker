using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject MenuBox;

    public GameObject SettingsPanel;

    private void Start()
    {
        SettingsPanel.SetActive(false);
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("TUT");
    }
    
    public void StartButton()
    {
        SceneManager.LoadScene("1LevelPasswort");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void SettingsButton()
    {
        SettingsPanel.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SettingsPanel.SetActive(false);

            Time.timeScale = 0;
        }
    }
}
