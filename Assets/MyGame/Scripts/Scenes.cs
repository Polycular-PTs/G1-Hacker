using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
   public string nameScene;
   public bool isGameOverScreen;

    private void Start()
    {
        if (isGameOverScreen)
        {
            nameScene = Progress.Instance.levels[Progress.Instance.currentLevel].loadSceneToTryAgain;
        }
        else
        {
            nameScene = Progress.Instance.levels[Progress.Instance.currentLevel].nextSceneAfterLogin;
        }
       
    }

    public void UpdateLevel()
    {
        Progress.Instance.currentLevel++;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nameScene); 
    }
}
