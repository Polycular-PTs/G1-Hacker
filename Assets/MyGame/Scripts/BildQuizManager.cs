using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class BildQuizManager : MonoBehaviour
{

    public LevelProgress level;

    public TMP_InputField inputField;
    //public TMP_Text feedbackText;
    public Image img;

    public string[] correctWord = new string[3];
    public string nextScene;
    public int maxTries = 3;
    private int triesLeft;
    public AudioSource audioSource;
    public AudioClip correctAudio;
    public AudioClip wrongAudio;

    public GameObject retryButton; 

    void Start()
    {
        correctWord = level.levels[level.currentLevel].bildQuiz.correctWords;
        nextScene = level.levels[level.currentLevel].bildQuiz.nextScene;
        //maxTries = level.levels[level.currentLevel].bildQuiz.maxTries;
        inputField.text = level.levels[level.currentLevel].bildQuiz.hint;
        img.sprite = level.levels[level.currentLevel].bildQuiz.img;

        triesLeft = int.MaxValue;
        //feedbackText.text = "";

        retryButton.SetActive(false); 
    }

    public void CheckWord()
    {
        string userInput = inputField.text.Trim();

        if (System.Array.Exists(correctWord, w =>
        w.Equals(userInput, System.StringComparison.OrdinalIgnoreCase)))
        {
            //feedbackText.text = "Richtig!";
            audioSource.PlayOneShot(correctAudio);
            Invoke("LoadWinScene", 1.5f);
        }
        else
        {
            triesLeft--;
            audioSource.PlayOneShot(wrongAudio);

            //if (triesLeft > 0)

            //{
            //    feedbackText.text = "Falsch! Noch " + triesLeft + " Versuche.";
            //}
            //else
            //{

            //    feedbackText.text = "Falsch! Keine Versuche mehr.";
            //    retryButton.SetActive(true);
            //    inputField.interactable = false;

            //}
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

