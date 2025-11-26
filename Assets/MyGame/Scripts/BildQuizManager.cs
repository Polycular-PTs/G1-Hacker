using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BildQuizManager : MonoBehaviour
{

    public TMP_InputField inputField;
    public TMP_Text feedbackText;

    public string[] correctWord = new string[3];
    public string nextScene;
    public int maxTries = 3;
    private int triesLeft;

    public GameObject retryButton; 

    void Start()
    {
        triesLeft = maxTries;
        feedbackText.text = "";

        retryButton.SetActive(false); 
    }

    public void CheckWord()
    {
        string userInput = inputField.text.Trim();

        if (System.Array.Exists(correctWord, w =>
        w.Equals(userInput, System.StringComparison.OrdinalIgnoreCase)))
        {
            feedbackText.text = "Richtig!";
            Invoke("LoadWinScene", 1.5f);
        }
        else
        {
            triesLeft--;

            if (triesLeft > 0)

            {
                feedbackText.text = "Falsch! Noch " + triesLeft + " Versuche.";
            }
            else
            {

                feedbackText.text = "Falsch! Keine Versuche mehr.";
                retryButton.SetActive(true);
                inputField.interactable = false;

            }
        }
    }

    void LoadWinScene()
    {
        SceneManager.LoadScene(nextScene);

    }

    public void Retry()

    {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

