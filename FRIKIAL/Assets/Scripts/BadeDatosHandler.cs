using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BadeDatosHandler : MonoBehaviour
{
    public BaseDatos bdglobal;
    public List<Player> listofplayers;
    public List<Player> listofplayersfriends;
    public GameObject[] playerscores;
    public GameObject[] inputs;
    public List<Question> listofnormalquestions;
    public List<Question> listoffirequestions;


    //Menus
    public GameObject Login_Fail;
    public GameObject Register_Success;
    public GameObject User_Existing;


    void Start()
    {
        string datosglobal = File.ReadAllText(Application.dataPath + "/Resources/Global.json");
        bdglobal = JsonUtility.FromJson<BaseDatos>(datosglobal);
        listofplayers = bdglobal.ListOfPlayers;
        listofnormalquestions = bdglobal.ListOfNormalQuestions;
        listoffirequestions = bdglobal.ListOfFireQuestions;
        OrdenarObj(); 
        SelectFriends();
        playerscores = GameObject.FindGameObjectsWithTag("Scores");
        inputs = GameObject.FindGameObjectsWithTag("Inputs");

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
        
        Debug.Log(listofplayersfriends.Count);

        for (int i = 0; i < playerscores.Length; i++){ 
            if (i < listofplayersfriends.Count){
                    texts = playerscores[i].GetComponentsInChildren<Text>();
                    texts[0].text = listofplayersfriends[i].nombre;
                    texts[1].text = listofplayersfriends[i].puntuacion.ToString();
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
        Debug.Log(playerscores.Length);
        for (int i = 0; i < playerscores.Length; i++)
        {
            playerscores[i].SetActive(true);
            texts = playerscores[i].GetComponentsInChildren<UnityEngine.UI.Text>();
            texts[0].text = listofplayers[i].nombre;
            texts[1].text = listofplayers[i].puntuacion.ToString();
        }
    }

    public void SelectFriends()
    {
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
        Debug.Log(exist);
        if (exist)
        {
            User_Existing.SetActive(true);
        }
        else
        {
            Debug.Log("GO");
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
        bdglobal.ListOfPlayers = listofplayers;
        string json = JsonUtility.ToJson(bdglobal,true);
        File.WriteAllText(Application.dataPath + "/Resources/Global.json",json);
    }
}