using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MultipleChoiceQuiz : MonoBehaviour
{
    public Button[] buttons;                        
    public TMP_Text fehlerText;                  
    public Button tryAgainButton;                  
    public int[] richtigeAntworten;
    public AudioSource audioSource;
    public AudioClip correctAudio;
    public AudioClip wrongAudio;
   


    private int richtigeGetroffen = 0;
    private bool antwortVerarbeitet = false;

    public string nextScene;

    void Start()
    {
        foreach (Button btn in buttons)
        {
            btn.onClick.AddListener(() => OnButtonClick(btn));


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
        richtigeGetroffen = 0;
        antwortVerarbeitet = false;
        fehlerText.text = "";

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;
            buttons[i].gameObject.SetActive(true);

            buttons[i].image.color = Color.white; 
        }

        tryAgainButton.gameObject.SetActive(false);
    }

    IEnumerator SzeneNachDelayLaden()

    {

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene); 
    }

}
