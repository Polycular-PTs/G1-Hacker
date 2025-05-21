using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoginManager : MonoBehaviour
{
    public string HintText;
    public TMP_InputField passwordInput;
    public TextMeshProUGUI errorText;
    public Button infoButton;
    public TextMeshProUGUI hintText;

    public string correctPassword;
    private int attempts = 0;
    private int maxAttempts = 3;
    public string nameDesktop;

    public static int playerScore = 0; // <--- Punkte bleiben auch nach Szenenwechsel erhalten


    void Start()
    {
        infoButton.gameObject.SetActive(false);  // InfoButton ausblenden
        hintText.gameObject.SetActive(false);    // Hinweistext ausblenden
    }

    public void CheckPassword()
    {
        if (passwordInput.text == correctPassword)
        {
            errorText.text = "";
            SceneManager.LoadScene(nameDesktop);
        }
        else
        {
            attempts++;

            if (attempts == 2)
            {
                infoButton.gameObject.SetActive(true);  // InfoButton anzeigen
            }

            if (attempts >= maxAttempts)
            {
                SceneManager.LoadScene("GameOverScene");
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
        hintText.gameObject.SetActive(true); // Hinweistext anzeigen
        hintText.text = HintText;
    }

    public void CheckPasswordPoints()
    {
        if (passwordInput.text == correctPassword)
        {
            // Punkte basierend auf Versuch
            if (attempts == 0)
                playerScore = 3;
            else if (attempts == 1)
                playerScore = 2;
            else
                playerScore = 1;

            SceneManager.LoadScene("MainScene");
        }
        else
        {
            attempts++;
            
        }
    }
}