using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
   public string nameScene;
    public LevelProgress levels;
    public bool isGameOverScreen;

    private void Start()
    {
        if (isGameOverScreen)
        {
            nameScene = levels.levels[levels.currentLevel].loadSceneToTryAgain;
        }
        else
        {
            nameScene = levels.levels[levels.currentLevel].nextSceneAfterLogin;
        }
       
    }

    public void UpdateLevel()
    {
        levels.currentLevel++;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nameScene); 
    }
}
