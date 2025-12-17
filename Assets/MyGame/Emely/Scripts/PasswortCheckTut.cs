using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class PasswortCheckerTut : MonoBehaviour
{
    public TMP_InputField passwordInput;
    public GameObject[] objs;
    public TMP_Text infoText;
    public TMP_Text finalText;
    public TMP_Text hintText;           
    public string korrektesPasswort = "1234";

    public float infoDisplayTime = 4f;
    public string nextSceneName = "NextScene";
    
    public float hintDisplayTime = 3f; 

    private bool canPressKey = false;

    public void OnLoginButtonPressed()
    {
        if (passwordInput.text == korrektesPasswort)
        {
            StartCoroutine(ShowInfoHideObjectsAndShowFinal());
        }
        else
        {
            Debug.Log("Falsches Passwort!");
            passwordInput.text = "";
        }
    }

    private IEnumerator ShowInfoHideObjectsAndShowFinal()
    {
        // passwort korrekt
        infoText.text = "Passwort korrekt!";
        infoText.gameObject.SetActive(true);

        yield return new WaitForSeconds(infoDisplayTime);
        infoText.gameObject.SetActive(false);

        // objs ausblenden
        foreach (GameObject obj in objs)
        {
            obj.SetActive(false);
        }

        //refactoring!!
        finalText.text = "Tutorial beendet! Drücke eine Taste, um fortzufahren!";
        finalText.gameObject.SetActive(true);
        canPressKey = true;

        Debug.Log("Final-Text angezeigt. Warten auf Tastendruck.");
    }

    private void Update()
    {
        if (canPressKey && Input.anyKeyDown)
        {
            canPressKey = false;
            SceneManager.LoadScene(nextSceneName);
        }
    }

    

    public void OnHintButtonPressed()
    {
        StartCoroutine(ShowHint());
    }


    private IEnumerator ShowHint()
    {
        hintText.text = "Zahlen im Namen!";
        hintText.gameObject.SetActive(true);

        yield return new WaitForSeconds(hintDisplayTime);
        hintText.gameObject.SetActive(false);
  
    }
}

