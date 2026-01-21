using UnityEngine;

public class PostManager : MonoBehaviour
{
    public GameObject[] postPanels; //#18, #19

    void Start()
    {
        HideAllPosts();
    }

    public void ReturnButton()
    {
        HideAllPosts();
    }

    void HideAllPosts()
    {
        for (int i = 0; i < postPanels.Length; i++)
        {
            postPanels[i].SetActive(false);
        }
    }

    public void ShowPost(int postNumber)
    {
        HideAllPosts();
        postPanels[postNumber].SetActive(true);
    }
}