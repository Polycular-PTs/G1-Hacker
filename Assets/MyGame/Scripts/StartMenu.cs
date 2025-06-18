using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject MenuBox;
    public void StartButton()
    {
        SceneManager.LoadScene("1LevelPasswort");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MenuButton()
    {
        MenuBox.gameObject.SetActive(true);
    }
    public void CloseMenuButton()
    {
        MenuBox.gameObject.SetActive(false);
    }
}
