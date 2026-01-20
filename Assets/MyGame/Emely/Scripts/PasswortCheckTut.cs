using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class PasswortCheckerTut : MonoBehaviour
{
    public TMP_InputField passwordInputField;
    public GameObject[] objectsToHide;
    public TMP_Text infoMessageText;
    public TMP_Text finalMessageText;
    public TMP_Text hintMessageText;           
    public string correctPassword = "1234";

    public float infoTextDisplayDuration = 4f;
    public string nextScene = "NextScene";
    
    public float hintTextDisplayDuration = 3f; 

    private bool canContinue = false;

    public void OnLoginButtonPressed()
    {
        if (passwordInputField.text == correctPassword)
        {
            StartCoroutine(ShowSuccessMessageAndFinishTutorial());
        }
        else
        {
            Debug.Log("Falsches Passwort!");
            passwordInputField.text = "";
        }
    }

    private IEnumerator ShowSuccessMessageAndFinishTutorial()
    {
        // passwort korrekt
        infoMessageText.text = "Passwort korrekt!";
        infoMessageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(infoTextDisplayDuration);
        infoMessageText.gameObject.SetActive(false);

        // objs ausblenden
        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }

        //refactoring!!
        finalMessageText.text = "Tutorial beendet! Drücke eine Taste, um fortzufahren!";
        finalMessageText.gameObject.SetActive(true);
        canContinue = true;

        Debug.Log("Final-Text angezeigt. Warten auf Tastendruck.");
    }

    private void Update()
    {
        if (canContinue && Input.anyKeyDown)
        {
            canContinue = false;
            SceneManager.LoadScene(nextScene);
        }
    }

    

    public void OnHintButtonPressed()
    {
        StartCoroutine(ShowHint());
    }


    private IEnumerator ShowHint()
    {
        hintMessageText.text = "Zahlen im Namen!";
        hintMessageText.gameObject.SetActive(true);

        yield return new WaitForSeconds(hintTextDisplayDuration);
        hintMessageText.gameObject.SetActive(false);
  
    }
}

