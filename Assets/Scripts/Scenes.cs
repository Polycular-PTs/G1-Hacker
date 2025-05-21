using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
   public string nameScene;
   public void NextLevel()
    {
        SceneManager.LoadScene(nameScene); 
    }
}
