using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject MenuBox;
    public void StartButton()
    {
        SceneManager.LoadScene("1LevelPassword");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        MenuBox.gameObject.SetActive(true);
    }
}
