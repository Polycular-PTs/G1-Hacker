using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2PostManager : MonoBehaviour
{
    public GameObject postPanel1;

    public void Start()
    {
        postPanel1.SetActive(false);
       
    }
    public void ShowPost1()
    { postPanel1.SetActive(true); }

    public void HidePost1()
    { postPanel1.SetActive(false); }

   
}
