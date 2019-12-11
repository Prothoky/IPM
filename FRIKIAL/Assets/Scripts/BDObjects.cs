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

public class J
{
    public static string s;
    public J()
    {
        s = "{\"ListOfPlayers\": [{\"nombre\": \"Player1\",\"psw\": \"\",\"puntuacion\": 1000,\"color\": \"Red\",\"friend\": true}],\"ListOfNormalQuestions\": [{\"question\": \"En la película Alien, ¿Qué úmero de pasajero era el alien? \",\"answerCorrect\": \"El octavo\",\"answerA\": \"El sexto\",\"answerB\": \"El noveno\",\"answerC\": \"El séptimo\"},{\"question\": \"¿Cómo se lama l mono de Overwatch?\",\"answerCorrect\": \"Winston\",\"answerA\": \"Harambe\",\"answerB\": \"Kong\",\"answerC\": \"Gorilla\"},{\"question\": \"¿Cómo se apellida Naruto?\",\"answerCorrect\": \"Uzumaki\",\"answerA\": \"Uchiha\",\"answerB\": \"Shippuden\",\"answerC\": \"Yasuo\"},{\"question\": \"¿Cuántas formas tiene Udyr? Campeón del League of Legends\",\"answerCorrect\": \"4\",\"answerA\": \"3\",\"answerB\": \"2\",\"answerC\": \"1\"},{\"question\": \"¿Cuántos hijos tiene Darth Vader?\",\"answerCorrect\": \"Dos\",\"answerA\": \"Uno\",\"answerB\": \"Ninguno\",\"answerC\": \"Cuatro\"},{\"question\": \"¿Cómo se llama la familia protagonista de Tekken?\",\"answerCorrect\": \"Mishima\",\"answerA\": \"Kazuya\",\"answerB\": \"Katakana\",\"answerC\": \"Nohara\"},{\"question\": \"¿Qué juego de los siguientes no es de From Software?\",\"answerCorrect\": \"NioH\",\"answerA\": \"Bloodborne\",\"answerB\": \"Demon’s ouls\",\"answerC\": \"Dark Souls\"},{\"question\": \"¿Cuál de estos personajes no sale en Super Smash Bros Brawl?\",\"answerCorrect\": \"Naruto\",\"answerA\": \"Toon Link\",\"answerB\": \"Mario\",\"answerC\": \"Bowser\"},{\"question\": \"¿Cuál de estos personajes no sale en Heroes of the Storm?\",\"answerCorrect\": \"Sonic\",\"answerA\": \"Abathur\",\"answerB\": \"Dva\",\"answerC\": \"Zeratul\"},{\"question\": \"¿Cuál de estos personajes no pertenece a League of Legends?\",\"answerCorrect\": \"Abathur\",\"answerA\": \"Maestro Yi\",\"answerB\": \"Vayne\",\"answerC\": \"Yasuo\"},{\"question\": \"¿Quién fué el ganador del mundial de League of Legends 2019?\",\"answerCorrect\": \"FunPlus Phoenix\",\"answerA\": \"Invictus Gaming\",\"answerB\": \"SKT\",\"answerC\": \"G2\"},{\"question\": \"¿Cuántos hoyos tiene en total el Wii Golf?\",\"answerCorrect\": \"9\",\"answerA\": \"12\",\"answerB\": \"5\",\"answerC\": \"3\"},{\"question\": \"¿Quién es el diseñador the Death Stranding?\",\"answerCorrect\": \"Kojima\",\"answerA\": \"Miyamoto\",\"answerB\": \"Nagasaki\",\"answerC\": \"Toshiba\"},{\"question\": \"¿Qué arma utiliza Jax en League of Legends? \",\"answerCorrect\": \"Una farola\",\"answerA\": \"Un escudo\",\"answerB\": \"Shuriken\",\"answerC\": \"Una hoz\"},{\"question\": \"¿Quién escribió la saga La Fundación?\",\"answerCorrect\": \"Isaac Asimov\",\"answerA\": \"Isaac Peral\",\"answerB\": \"George Orwell\",\"answerC\": \"Markus Persson\"},{\"question\": \"¿Cuál de los siguientes no es un pokemon?\",\"answerCorrect\": \"Michu\",\"answerA\": \"Raichu\",\"answerB\": \"Pikachu\",\"answerC\": \"Meowtwo\"},{\"question\": \"¿Cuál es la profesión de Han Solo?\",\"answerCorrect\": \"Contrabandista\",\"answerA\": \"Soldado\",\"answerB\": \"Cazarrecompensas\",\"answerC\": \"Chatarrero\"},{\"question\": \"¿Con cuántas ‘y’ se escribe el planeta donde habitan los wookies?\",\"answerCorrect\": \"Kashyyyk\",\"answerA\": \"Kashyyk\",\"answerB\": \"Kashyk\",\"answerC\": \"Kashyyyyk\"},{\"question\": \"¿Dónde se encuentra el consejo jedi?\",\"answerCorrect\": \"Coruscant\",\"answerA\": \"Utapau\",\"answerB\": \"Mustafar\",\"answerC\": \"Yoshi\"}],\"ListOfFireQuestions\": [{\"question\": \"¿Cómo se llama el quinto maestro Hokage?\",\"answerCorrect\": \"Tsunade\",\"answerA\": \"Orochimaru\",\"answerB\": \"Akamaru\",\"answerC\": \"Shinji\"},{\"question\": \"¿Cuántos Ángeles hay en total en Evangelion?\",\"answerCorrect\": \"18\",\"answerA\": \"17\",\"answerB\": \"10\",\"answerC\": \"20\"},{\"question\": \"¿Cuál de wstos personajes no pertenece a League of Legends?\",\"answerCorrect\": \"Cuauhtémoc\",\"answerA\": \"Maestro Yi\",\"answerB\": \"Yasuo\",\"answerC\": \"Vayne\"},{\"question\": \"¿Quién escribió la saga La Fundación?\",\"answerCorrect\": \"Isaac Asimov\",\"answerA\": \"Isaac Peral\",\"answerB\": \"George Orwell\",\"answerC\": \"George linton\"},{\"question\": \"¿Qué juego de los siguientes no es de From Software?\",\"answerCorrect\": \"NioH\",\"answerA\": \"Dark Souls\",\"answerB\": \"Bloodborne\",\"answerC\": \"Demon’s Souls\"},{\"question\": \"¿Quién fué el ganador del mundial de League of Legends 2019?\",\"answerCorrect\": \"FunPlus Phoenix\",\"answerA\": \"InvictusGaming\",\"answerB\": \"SKT\",\"answerC\": \"G2\"},{\"question\": \"¿Quién es el diseñador the Death Stranding?\",\"answerCorrect\": \"Kojima\",\"answerA\": \"Toshiba\",\"answerB\": \"Fujitsu\",\"answerC\": \"Yatekomo\"},{\"question\": \"¿Qué arma tiliza Jax en League of Legends?\",\"answerCorrect\": \"Una farola\",\"answerA\": \"Un escudo\",\"answerB\": \"Una daga\",\"answerC\": \"Una hoz\"},{\"question\": \"¿Cuál de estos ersonajes no sale en Heroes of the Storm?\",\"answerCorrect\": \"Sonic\",\"answerA\": \"Dva\",\"answerB\": \"Zeratul\",\"answerC\": \"Abathur\"},{\"question\": \"¿Cuál de estos personajes no sale en Super Smash Bros Brawl?\",\"answerCorrect\": \"Naruto\",\"answerA\": \"Bowser\",\"answerB\": \"Toon Link\",\"answerC\": \"Mario\"}]}";
    }
}
