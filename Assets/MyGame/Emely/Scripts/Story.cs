using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryLevel : MonoBehaviour
{
    public GameObject[] storySlides;
    public string nextScene;
    private int currentSlideIndex = 0;

    void Start()
    {
        for (int i = 0; i < storySlides.Length; i++)
            storySlides[i].SetActive(i == 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentSlideIndex < storySlides.Length - 1)
        {
            storySlides[currentSlideIndex].SetActive(false);
            currentSlideIndex++;
            storySlides[currentSlideIndex].SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentSlideIndex > 0)
        {
            storySlides[currentSlideIndex].SetActive(false);
            currentSlideIndex--;
            storySlides[currentSlideIndex].SetActive(true);
        }

        if (currentSlideIndex == storySlides.Length - 1 && Input.anyKeyDown)
        {
            SceneManager.LoadScene(nextScene);
       
        }
    }
}
