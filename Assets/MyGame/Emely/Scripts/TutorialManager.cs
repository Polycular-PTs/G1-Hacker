
using UnityEngine.UI;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Text tutorialTextfeld;         
    public string[] tutorialTexte;
    private int currentIndex = 0;
    private bool isFinished = false;
    public GameObject sceneObj;
    public GameObject[] imagesToActivate;

    void Start()
    {
        if (tutorialTexte.Length > 0)
        {
            tutorialTextfeld.text = tutorialTexte[0];
        }
    }

    void Update()

    {
        if (isFinished) return;

       
        if (Input.anyKeyDown)
        {
            
            currentIndex++;

            
            if (currentIndex >= tutorialTexte.Length)
            {
                FinishTutorial();
                return;
            }
            tutorialTextfeld.text = tutorialTexte[currentIndex];
        }
    }

    void FinishTutorial()
    {
        isFinished = true;

        
        if (tutorialTextfeld != null)
            Destroy(tutorialTextfeld.gameObject);

        if (sceneObj != null)
            Destroy(sceneObj);

        ActivateImages();
    }

    void ActivateImages()
    {
        foreach (GameObject image in imagesToActivate)
        {
            if (image != null)
                image.SetActive(true);
        }
  
    }
}

