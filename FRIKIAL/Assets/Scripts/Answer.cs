using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour
{

    public GameObject ImageC;
    public GameObject ImageW;

    private void Start()
    {
        ImageC = GameObject.Find("CORRECT");
        ImageW = GameObject.Find("CORRECT");
        CloseImage(ImageC);
        CloseImage(ImageW);
    }

    public void checkAnswer(string answer)
    {
        if (answer == "B")
        {
            OpenImage(ImageC);
            CloseImage(ImageW);
        }
        else
        {
            OpenImage(ImageW);
            CloseImage(ImageC);
        }
    }
    
    public void OpenImage(GameObject Image)
    {
        if(Image != null)
        {
            Image.SetActive(true);
        }
    }

    public void CloseImage(GameObject Image)
    {
            Image.SetActive(false);
    }

}
