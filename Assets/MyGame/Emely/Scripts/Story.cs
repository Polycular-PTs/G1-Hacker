using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryLevel : MonoBehaviour
{
    public GameObject[] slides;
    public string nextSceneName;
    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < slides.Length; i++)
            slides[i].SetActive(i == 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentIndex < slides.Length - 1)
        {
            slides[currentIndex].SetActive(false);
            currentIndex++;
            slides[currentIndex].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentIndex > 0)
        {
            slides[currentIndex].SetActive(false);
            currentIndex--;
            slides[currentIndex].SetActive(true);
        }

        if (currentIndex == slides.Length - 1 && Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextSceneName);
       
        }
    }
}
