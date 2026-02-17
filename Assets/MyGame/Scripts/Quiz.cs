using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MultipleChoiceQuiz : MonoBehaviour
{
    

    public Button[] buttons;
    public TMP_Text headerText;
    public TMP_Text fehlerText;                  
    public Button tryAgainButton;                  
    public int[] richtigeAntworten;
    public AudioSource audioSource;
    public AudioClip correctAudio;
    public AudioClip wrongAudio;

    public List<Level> levels;
    public int currentLevel;

    private int richtigeGetroffen = 0;
    private bool antwortVerarbeitet = false;

    public string nextScene;

    void Start()
    {
        levels = Progress.Instance.levels;
        currentLevel = Progress.Instance.currentLevel;

        headerText.text = levels[currentLevel].quiz.header;
        richtigeAntworten = levels[currentLevel].quiz.rightAnswers;
        nextScene = levels[currentLevel].quiz.nextScene;

        foreach (var btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(btn));
        }

        for (int i = 0; i < buttons.Length; i++)
        {
            
            buttons[i].GetComponentInChildren<TMP_Text>().text = levels[currentLevel].quiz.answers[i];
            
        }

        tryAgainButton.gameObject.SetActive(false);
        tryAgainButton.onClick.AddListener(ResetFrage);
    }

    void OnButtonClick(Button clickedButton)
    {

        if (antwortVerarbeitet) return;

        int index = System.Array.IndexOf(buttons, clickedButton);

        if (System.Array.Exists(richtigeAntworten, element => element == index))
        {
            clickedButton.image.color = Color.green;
            clickedButton.interactable = false;
            richtigeGetroffen++;
            audioSource.PlayOneShot(correctAudio);

            if (richtigeGetroffen == richtigeAntworten.Length)
            {
                antwortVerarbeitet = true;
                StartCoroutine(SzeneNachDelayLaden());

            }
        }
        else
        {

            clickedButton.image.color = Color.red;
            fehlerText.text = "Try again";
            antwortVerarbeitet = true;
            audioSource.PlayOneShot(wrongAudio);
            DeaktiviereAlleAntworten();

        }
    }

    void DeaktiviereAlleAntworten()
    {

        foreach (Button btn in buttons)
        {
            btn.interactable = false;
            btn.gameObject.SetActive(false);  
        }

        tryAgainButton.gameObject.SetActive(true); 


    }

    void ResetFrage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator SzeneNachDelayLaden()

    {

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene); 
    }

}
