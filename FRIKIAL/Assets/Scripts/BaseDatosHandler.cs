﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using LitJson;


public class BaseDatosHandler : MonoBehaviour
{
    public BaseDatos bd;
    public List<User> listofplayers;
    public List<User> listofplayersfriends;
    public List<Question> listofnormalquestions;
    public List<Question> listoffirequestions;
    public GameObject[] playerscores;
    public GameObject[] inputs;
    public GameObject[] answers;
    public GameObject question;
    public List<int> questionsshowed;
    public List<int> questionsfireshowed;
    private int nq;
    public int gamemode = 0;
    private bool hardq = false;
    private bool creating = false;
    private int firetime = 0;

    //Menus
    public GameObject UserDoesNotExist;
    public GameObject Register_Success;
    public GameObject User_Existing;
    public GameObject UserNotFound;
    public GameObject PassworIncorrect;
    public GameObject Add_Success;
    public GameObject Erase_Success;
    public GameObject PreguntaDificl;
    public GameObject You_Win;
    public GameObject You_Loose;
    public GameObject FIRE;
    //Juego
    public GameObject panelCORRECT;
    public GameObject backgroundCORRECT;
    public GameObject panelWRONG;
    public GameObject backgroundWRONG;
    public List<Player> listofP;
    public Player P1 = new Player();
    public Player P2 = new Player();
    public Player P3 = new Player();
    public Player P4 = new Player();

    //Naves

    private GameObject BigPanel;
    private Vector3 maxenemyrandomspaceBig = new Vector3(1000, 3500, 0);
    private Vector3 minenemyrandomspaceBig = new Vector3(100,3000,0);
    private Vector3 minalyrandomspaceBig = new Vector3(100, 2300, 0);
    private Vector3 maxalyrandomspaceBig = new Vector3(1000, 2800, 0);


    //private Vector3 minenemyrandomspaceSmall = new Vector3(600, 1150, 0);
    //private Vector3 maxenemyrandomspaceSmall = new Vector3(1000, 1575, 0);
    //private Vector3 maxalyrandomspaceSmall = new Vector3(500, 1575, 0);
    //private Vector3 minalyrandomspaceSmall = new Vector3(75, 1150, 0);

    private GameObject enemyspaceship;
    private GameObject alyspaceship;

    void Start()
    {
        //string datosglobal = File.ReadAllText(Application.dataPath + "/Resources/Global.json");
        //File.WriteAllText(Application.dataPath + "/Resources/texto.txt", datosglobal);
        //bd = JsonUtility.FromJson<BaseDatos>(datosglobal);

        J datosglobal = new J();
        bd = JsonUtility.FromJson<BaseDatos>(J.s);
        listofplayers = bd.ListOfPlayers;
        listofnormalquestions = bd.ListOfNormalQuestions;
        listoffirequestions = bd.ListOfFireQuestions;
        creating = true;

        if (SceneManager.GetActiveScene().name == "LoginScene") {
            inputs = GameObject.FindGameObjectsWithTag("Inputs");
            
        }
        if (SceneManager.GetActiveScene().name == "Friends" || SceneManager.GetActiveScene().name == "Ranking")
        {
            OrdenarObj(); 
            SelectFriends();
            playerscores = GameObject.FindGameObjectsWithTag("Scores");
            inputs = GameObject.FindGameObjectsWithTag("Inputs");
            ShowFriends();
        }

        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            creating = false;
            PreguntaDificl.SetActive(false);
            You_Loose.SetActive(false);
            You_Win.SetActive(false);
            FIRE.SetActive(false);
            P1 = new Player();
            P2 = new Player();
           
            if (gamemode == 1)
            {
                P3 = new Player();
                P4 = new Player();
            }

            enemyspaceship = GameObject.FindGameObjectWithTag("Enemy");
            enemyspaceship.SetActive(false);
            alyspaceship= GameObject.FindGameObjectWithTag("Aly");
            alyspaceship.SetActive(false);

            BigPanel = GameObject.FindGameObjectWithTag("MaxMap");

            ShowQuestion();
            panelCORRECT = GameObject.FindGameObjectWithTag("CORRECT");
            backgroundCORRECT = GameObject.FindGameObjectWithTag("BGCORRECT");
            panelWRONG = GameObject.FindGameObjectWithTag("WRONG");
            backgroundWRONG = GameObject.FindGameObjectWithTag("BGWRONG");
            ClosePanel();
            
        }


    }

    public void OrdenarObj()
    {
        User obj = null;

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
        if(SceneManager.GetActiveScene().name == "Ranking")
        {
            GameObject[] labels = GameObject.FindGameObjectsWithTag("Lab");
            //labels[1].GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Labs/PestañaAmigosHab.png");
            //labels[0].GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Labs/PestañaGlobalDis.png");
            
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
        if (SceneManager.GetActiveScene().name == "Ranking")
        {
            GameObject[] labels = GameObject.FindGameObjectsWithTag("Lab");
            //labels[1].GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Labs/PestañaAmigosDis.png");
            //labels[0].GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Labs/pestañaGlobalHab.png");

        }
    }

    public void SelectFriends()
    {
        listofplayersfriends.Clear();
        foreach(User p in listofplayers)
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
        bool usercorrect = false;
        bool passwordcorrect = false;
        for (int i = 0; i < listofplayers.Count; i++)
        {
            if (listofplayers[i].nombre == inputs[0].GetComponentInChildren<Text>().text)
            {
                usercorrect = true;
            }
            if(listofplayers[i].psw == inputs[1].GetComponentInChildren<Text>().text)
            {
                passwordcorrect = true;
            }
        }
        if (usercorrect && passwordcorrect)
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("StartScene");
        }
        else if (!usercorrect)
        {
            UserDoesNotExist.SetActive(true);
        }
        else
        {
            PassworIncorrect.SetActive(true);
        }

    }
    public void SaveNewUser()
    {
        User player = new User(inputs[0].GetComponentInChildren<Text>().text, inputs[1].GetComponentInChildren<Text>().text);
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
        //string json = JsonUtility.ToJson(bd, true);
        //File.WriteAllText(Application.dataPath + "/Resources/Global.json", json);
    }

    public void ShowQuestion()
    {
        question = GameObject.FindGameObjectWithTag("Question");
        answers = GameObject.FindGameObjectsWithTag("Answers");

        int[] options = new int[4];

        int index = Random.Range(0, 4);
        for (int i = 0; i < 4; i++)
        {
            options[i] = index;
            if (index < 3) index++; else index = 0;
        }
        if (questionsshowed.Count != listofnormalquestions.Count)
        {
            if (firetime>2)
            {
                PreguntaDificl.SetActive(true);
                do { nq = Random.Range(0, listoffirequestions.Count); }
                while (questionsfireshowed.Contains(nq));
                questionsfireshowed.Add(nq);

                answers[options[0]].GetComponentInChildren<Text>().text = listoffirequestions[nq].answerA;
                answers[options[1]].GetComponentInChildren<Text>().text = listoffirequestions[nq].answerB;
                answers[options[2]].GetComponentInChildren<Text>().text = listoffirequestions[nq].answerC;
                answers[options[3]].GetComponentInChildren<Text>().text = listoffirequestions[nq].answerCorrect;

                question.GetComponent<Text>().text = listoffirequestions[nq].question;
                firetime = 0;
                hardq = true;
            }
            else
            {
                PreguntaDificl.SetActive(false);
                do { nq = Random.Range(0, listofnormalquestions.Count); }
                while (questionsshowed.Contains(nq));
                questionsshowed.Add(nq);

                answers[options[0]].GetComponentInChildren<Text>().text = listofnormalquestions[nq].answerA;
                answers[options[1]].GetComponentInChildren<Text>().text = listofnormalquestions[nq].answerB;
                answers[options[2]].GetComponentInChildren<Text>().text = listofnormalquestions[nq].answerC;
                answers[options[3]].GetComponentInChildren<Text>().text = listofnormalquestions[nq].answerCorrect;

                question.GetComponent<Text>().text = listofnormalquestions[nq].question;

            }

        }
        else
        {
            Debug.Log("FIN DE BD DE PREGUNTAS");

            PreguntaDificl.SetActive(true);
            answers[options[0]].GetComponentInChildren<Text>().text = listofnormalquestions[0].answerA;
            answers[options[1]].GetComponentInChildren<Text>().text = listofnormalquestions[0].answerB;
            answers[options[2]].GetComponentInChildren<Text>().text = listofnormalquestions[0].answerC;
            answers[options[3]].GetComponentInChildren<Text>().text = listofnormalquestions[0].answerCorrect;

            question.GetComponent<Text>().text = listofnormalquestions[0].question;
            nq = 0;
            hardq = true;
        }
    }

    public void CheckAnswer(Button button)
    {
        if (nq < listoffirequestions.Count && button.GetComponentInChildren<Text>().text == listoffirequestions[nq].answerCorrect) {

            ShowCorrect(button);
        }
        else if(button.GetComponentInChildren<Text>().text == listofnormalquestions[nq].answerCorrect)
        {
            ShowCorrect(button);
        }
        else
        {
            P1.fallos++;
            //button.GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Buttons/GameplayRespuestaErronea.png");
            panelWRONG.SetActive(true);
            backgroundWRONG.SetActive(true);
            if (hardq)
            {
                hardq = false;
                FIRE.SetActive(false);
                PreguntaDificl.SetActive(false);
                firetime = 0;
            }
            ShowQuestion();
        }
        StartCoroutine("Limpiar",button);
    }

    public void ShowCorrect(Button button)
    {
        P1.aciertos++;
        P1.tropas++;
        firetime++;
        panelCORRECT.SetActive(true);
        backgroundCORRECT.SetActive(true);
        //button.GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Buttons/GameplayRespuestaCorrecta.png");
        Addspaceship();
        if (hardq)
        {
            ActivateFireMode();
        }
        else
        {
            ShowQuestion();
        }

    }

    public void Addspaceship()
    {
        Drawship("aly");
        UpdateCounters();
    }

    public void ActivateFireMode()
    {
        foreach(GameObject b in answers)
        {
            b.GetComponent<Button>().interactable = false;
        }
        question.SetActive(false);
        FIRE.SetActive(true);
    }

    public void Fire()
    {
        int daño = 0;
        daño = P1.tropas;
        P2.tropas -= daño;
        P1.damage_done += daño;
        if (P2.tropas <= 0)
        {
            You_Win.SetActive(true);
            ShowStats();
        }
        else
        {
            for(int i = 0; i < daño; i++)
            {
                GameObject.FindGameObjectWithTag("EnemyMax").SetActive(false);
            }
            foreach (GameObject b in answers)
            {
                b.GetComponent<Button>().interactable = true;
            }
            question.SetActive(true);
            FIRE.SetActive(false);
            PreguntaDificl.SetActive(false);
            hardq = false;
            //Debug.Log("Entra");
            ShowQuestion();
        }
    }

    public void ShowStats()
    {
        GameObject[] stats = GameObject.FindGameObjectsWithTag("Stats");
        stats[0].GetComponentInChildren<Text>().text = P1.aciertos.ToString();
        stats[1].GetComponentInChildren<Text>().text = P1.fallos.ToString();
        stats[2].GetComponentInChildren<Text>().text = P1.damage_done.ToString();
        stats[3].GetComponentInChildren<Text>().text = P1.damage_received.ToString();
    }

    public void ClosePanel()
    {
        panelCORRECT.SetActive(false);
        backgroundCORRECT.SetActive(false);
        panelWRONG.SetActive(false);
        backgroundWRONG.SetActive(false);
    }

    IEnumerator Limpiar(Button button)
    {
        yield return new WaitForSeconds(1);
        //button.GetComponent<Image>().sprite = Resources.Load<Sprite>(   Application.streamingAssetsPath + "/Buttons/GameplayRespuesta.png");
        ClosePanel();
    }

    IEnumerator IA()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            creating = true;
            yield return new WaitForSeconds(3);
            P2.tropas++;
            UpdateCounters();
            Drawship("enemy");
            creating = false;
        }
    }

    void Drawship(string ente)
    {
        GameObject nave;
        if (ente == "aly")
        {
            Vector3 spacepointmax = new Vector3(Random.Range(BigPanel.transform.position.x +100, BigPanel.transform.position.x + 1000), Random.Range(BigPanel.transform.position.y + 350, BigPanel.transform.position.y + 850), 0);
            nave = Instantiate(alyspaceship, spacepointmax, transform.rotation,BigPanel.transform);
            nave.SetActive(true);
            nave.transform.Rotate(new Vector3(0, 0, 90));
        }
        else if(ente == "enemy"){

            Vector3 spacepointmax = new Vector3(Random.Range(BigPanel.transform.position.x +100 , BigPanel.transform.position.x + 1000), Random.Range(BigPanel.transform.position.y + 1000, BigPanel.transform.position.y + 1550), 0);
            nave = Instantiate(enemyspaceship, spacepointmax, transform.rotation, BigPanel.transform);
            nave.SetActive(true);
            nave.transform.Rotate(new Vector3(0, 0, -90));
            nave.tag = "EnemyMax";
        }
        else
        {
            Debug.Log("WTF THIS SHOULD NOT HAPPEN");
        }
    }

    void UpdateCounters()
    {
        GameObject[] Counters = GameObject.FindGameObjectsWithTag("Counter");
        foreach (GameObject counter in Counters)
        {
            if (counter.name == "ACounter")
            {
                counter.GetComponent<Text>().text = P1.tropas.ToString();
            }
            if (counter.name == "ECounter")
            {
                counter.GetComponent<Text>().text = P2.tropas.ToString();
            }
        }
    }

    void Update()
    {
        if(!creating)
        StartCoroutine("IA");
    }

}