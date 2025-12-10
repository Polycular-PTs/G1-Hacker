
using UnityEngine.UI;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Text textFeld;         
    public string[] texte;
    private int aktuellerIndex = 0;
    private bool fertig = false;
    public GameObject szeneObj;
    public GameObject[] bilder;

    void Start()
    {
        if (texte.Length > 0)
        {
            textFeld.text = texte[0];
        }
    }

    void Update()

    {
        if (fertig) return;

       
        if (Input.anyKeyDown)
        {
            
            aktuellerIndex++;

            
            if (aktuellerIndex >= texte.Length)
            {
                BeendeTutorial();
                return;
            }
            textFeld.text = texte[aktuellerIndex];
        }
    }

    void BeendeTutorial()
    {
        fertig = true;

        
        if (textFeld != null)
            Destroy(textFeld.gameObject);

        if (szeneObj != null)
            Destroy(szeneObj);

        AktiviereBilder();
    }

    void AktiviereBilder()
    {
        foreach (GameObject bild in bilder)
        {
            if (bild != null)
                bild.SetActive(true);
        }
  
    }
}

