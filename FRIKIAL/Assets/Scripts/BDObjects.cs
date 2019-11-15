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