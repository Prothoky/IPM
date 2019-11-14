using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string nombre;
    public string psw;
    public int puntuacion;
    public string color;
    public bool friend;

    public Player(string n, string p)
    {
        nombre = n;
        psw = p;
        puntuacion = 0;
        color = "White";
        friend = false;
    }
}

public class Question
{
    public int id;
    public string question;			
    public string answerCorrect;
	public string answerA;
    public string answerB;
    public string answerC;
}


[System.Serializable]
public class BaseDatos
{
    public List<Player> ListOfPlayers;
    public List<Question> ListOfNormalQuestions;
    public List<Question> ListOfFireQuestions;
}