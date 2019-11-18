using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public string nombre;
    public string psw;
    public int puntuacion;
    public string color;
    public bool friend;

    public User(string n, string p)
    {
        nombre = n;
        psw = p;
        puntuacion = 0;
        color = "White";
        friend = false;
    }
}

[System.Serializable]
public class Question
{
    public string question;
    public string answerCorrect;
	public string answerA;
    public string answerB;
    public string answerC;
}

[System.Serializable]
public class BaseDatos
{
    public List<User> ListOfPlayers;
    public List<Question> ListOfNormalQuestions;
    public List<Question> ListOfFireQuestions;
}

public class Player
{
    public int tropas;
    public List<GameObject> listoftroups;
    public int aciertos;
    public int fallos;
    public int damage_done;
    public int damage_received;
    public Player()
    {
        tropas = aciertos = fallos = damage_done = damage_received = 0;
    }
    public void AddTroup(GameObject obj)
    {
        listoftroups.Add(obj);
    }
}