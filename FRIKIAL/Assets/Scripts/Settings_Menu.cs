using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Settings_Menu : MonoBehaviour
{

    public void savesettings()
    {
        Debug.Log("Hace Cosas");
        backtomainmenu();
    }

    public void backtomainmenu()
    {
        string scenename = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(scenename);
    }

}