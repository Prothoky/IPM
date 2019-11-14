using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadeDatosHandler : MonoBehaviour
{
    public BaseDatos bd;
    public List<Player> listofplayers;
    public List<Player> listofplayersfriends;
    public List<Question> listofnormalquestions;
    public List<Question> listoffirequestions;
    public GameObject[] playerscores;
    public GameObject[] inputs;


    //Menus
    public GameObject Login_Fail;
    public GameObject Register_Success;
    public GameObject User_Existing;
    public GameObject UserDoesNotExist;
    public GameObject Add_Success;
    public GameObject Erase_Success;


    void Start()
    {
        string datosglobal = File.ReadAllText(Application.dataPath + "/Resources/Global.json");
        bd = JsonUtility.FromJson<BaseDatos>(datosglobal);
        listofplayers = bd.ListOfPlayers;
        listofnormalquestions = bd.ListOfNormalQuestions;
        listoffirequestions = bd.ListOfFireQuestions;
        OrdenarObj(); 
        SelectFriends();
        playerscores = GameObject.FindGameObjectsWithTag("Scores");
        inputs = GameObject.FindGameObjectsWithTag("Inputs");
        ShowFriends();
    }

    public void OrdenarObj()
    {
        Player obj = null;

        for (int a = 1; a < listofplayers.Count; a++)
        {
            for (int b = 0;b < listofplayers.Count; b++)
            {
                if (listofplayers[b].puntuacion < listofplayers[a].puntuacion)
                {
                    obj = listofplayers[a];
                    listofplayers[a] = listofplayers[b];
                    listofplayers[b] = obj;
                }
            }
        }

    }

    public void ShowFriends()
    {
        Text[] texts;
        for (int i = 0; i < playerscores.Length; i++){ 
            if (i < listofplayersfriends.Count){
                    texts = playerscores[i].GetComponentsInChildren<Text>();
                    texts[0].text = listofplayersfriends[i].nombre;
                    texts[1].text = listofplayersfriends[i].puntuacion.ToString();
                    playerscores[i].SetActive(true);
            }
            else
            {
                playerscores[i].SetActive(false);
            }
        }
    }

    public void ShowGlobal()
    {
        Text[] texts;
        for (int i = 0; i < playerscores.Length; i++)
        {
            playerscores[i].SetActive(true);
            texts = playerscores[i].GetComponentsInChildren<Text>();
            texts[0].text = listofplayers[i].nombre;
            texts[1].text = listofplayers[i].puntuacion.ToString();
        }
    }

    public void SelectFriends()
    {
        listofplayersfriends.Clear();
        foreach(Player p in listofplayers)
        {
            if (p.friend == true) listofplayersfriends.Add(p);
        }
    }

    public void RegisterUser()
    {
        bool exist = false;
        for (int i = 0; i < listofplayers.Count; i++)
        {
            if (listofplayers[i].nombre == inputs[0].GetComponentInChildren<Text>().text) {
                exist=true;
            }
        }
        if (exist)
        {
            User_Existing.SetActive(true);
        }
        else
        {
            SaveNewUser();
            Register_Success.SetActive(true);
        }
    }

    public void VerifyUser()
    {
        bool correct = false;
        for (int i = 0; i < listofplayers.Count; i++)
        {
            if (listofplayers[i].nombre == inputs[0].GetComponentInChildren<Text>().text && listofplayers[i].psw == inputs[1].GetComponentInChildren<Text>().text)
            {
                correct = true;
            }
        }
        if (correct)
        {

            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("StartScene");
        }
        else
        {
            Login_Fail.SetActive(true);
        }

    }
    public void SaveNewUser()
    {
        Player player = new Player(inputs[0].GetComponentInChildren<Text>().text, inputs[1].GetComponentInChildren<Text>().text);
        listofplayers.Add(player);
        UpdateJson();
    }

    public void AddFriend()
    {
        inputs = GameObject.FindGameObjectsWithTag("Inputs");
        bool modify = false;
        for (int i = 0; i < listofplayers.Count; i++)
        {
            if (listofplayers[i].nombre == inputs[0].GetComponentInChildren<Text>().text)
            {
                if (listofplayers[i].friend != true)
                {
                    listofplayers[i].friend = true;
                    modify = true;
                }
            }
        }
        if (modify)
        {
            UpdateJson();
            SelectFriends();
            ShowFriends();
            Add_Success.SetActive(true);
        }
        else
        {
            UserDoesNotExist.SetActive(true);
        }
    }

    public void EraseFriend()
    {
        inputs = GameObject.FindGameObjectsWithTag("Inputs");
        bool modify = false;
        for (int i = 0; i < listofplayers.Count; i++)
        {
            if (listofplayers[i].nombre == inputs[0].GetComponentInChildren<Text>().text)
            {
                if (listofplayers[i].friend != false)
                {
                    listofplayers[i].friend = false;
                    modify = true;
                }
            }
        }
        if (modify)
        {
            UpdateJson();
            SelectFriends();
            ShowFriends();
            Debug.Log("DONE");
            Erase_Success.SetActive(true);
        }
        else
        {
            UserDoesNotExist.SetActive(true);
        }
    }

    public void UpdateJson()
    {
        bd.ListOfPlayers = listofplayers;
        string json = JsonUtility.ToJson(bd, true);
        File.WriteAllText(Application.dataPath + "/Resources/Global.json", json);
    }
}