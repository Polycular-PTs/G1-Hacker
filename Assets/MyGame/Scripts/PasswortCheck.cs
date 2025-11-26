using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class LoginManager : MonoBehaviour
{
    
    public TMP_InputField passwordInput;
    public TextMeshProUGUI errorText;
    public Button infoButton;

    public TextMeshProUGUI hintText;
    public string HintText;

    public string correctPassword;
    private int attempts = 0;
    private int maxAttempts = 3;
    public string gameOverSceneNumb;
    public string nextScene;
    public AudioSource audioSource;
    public AudioClip correctAudio;
    public AudioClip wrongAudio;



    void Start()
    {
        infoButton.gameObject.SetActive(false);  
        hintText.gameObject.SetActive(false);   
    }

    public void CheckPassword()
    {
        if (passwordInput.text == correctPassword)
        {
            errorText.text = "";
            audioSource.PlayOneShot(correctAudio);
            StartCoroutine(LoadAfterDelay());
          

        }
        else

        
        {
            attempts++;
            audioSource.PlayOneShot(wrongAudio);


            if (attempts == 2)
            {
            
                infoButton.gameObject.SetActive(true); 
            }

            if (attempts >= maxAttempts)
            {
                SceneManager.LoadScene(gameOverSceneNumb);
            }
            else

            {

                int remaining = maxAttempts - attempts;
                errorText.text = "Falsches Passwort! Noch " + remaining + " Versuch(e).";
            }


        }


    }



    public void ShowHint()
    {
        hintText.gameObject.SetActive(true); 
        hintText.text = HintText;
    }

    private IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(nextScene);
    }

}

