using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
}
