using UnityEngine;

public class PostManager : MonoBehaviour
{
    public GameObject postPanel1;
    public GameObject postPanel2;
    public GameObject postPanel3;
    public GameObject postPanel4;

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
        postPanel1.SetActive(false);
        postPanel2.SetActive(false);
        postPanel3.SetActive(false);
        postPanel4.SetActive(false);
    }

    public void ShowPost1()
    {
        postPanel1.SetActive(true);
    }

    public void ShowPost2()
    {
        postPanel2.SetActive(true);
    }

    public void ShowPost3()
    {
        postPanel3.SetActive(true);
    }

    public void ShowPost4()
    {
        postPanel4.SetActive(true);
    }

    public void HidePost1()
    {
        postPanel1.SetActive(false);
    }

    public void HidePost2()
    {
        postPanel2.SetActive(false);
    }

    public void HidePost3()
    {
        postPanel3.SetActive(false);
    }

    public void HidePost4()
    {
        postPanel4.SetActive(false);
    }
}