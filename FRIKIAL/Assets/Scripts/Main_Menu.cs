using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.SetString ("lastLoadedScene", SceneManager.GetActiveScene ().name);
    }

    public void changemenuscene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

    public void popupregister()
    {
        GameObject.Find("Register Success").SetActive(true);
    }

    public void registerfail()
    {
        GameObject.Find("User Existing").SetActive(true);
    }

    public void closeregisterfail()
    {
        GameObject.Find("User Existing").SetActive(false);
    }
    public void closeloginfail()
    {
        GameObject.Find("Login Fail").SetActive(false);
    }

    public void closeapp()
    {
    #if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
}
