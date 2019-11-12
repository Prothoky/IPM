using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BadeDatosHandler : MonoBehaviour
{
    public BaseDatosObjeto bdfriends;
    public BaseDatosObjeto bdglobal;
    public BaseDatosObjeto bdtemp;

    void Start()
    {
        string datosfriends = File.ReadAllText(Application.dataPath + "/Resources/Friends.json");
        string datosglobal = File.ReadAllText(Application.dataPath + "/Resources/Global.json");
        
        bdfriends = JsonUtility.FromJson<BaseDatosObjeto>(datosfriends);
        bdglobal = JsonUtility.FromJson<BaseDatosObjeto>(datosglobal);
    }

    public void OrdenarObj()
    {
        Objeto obj = null;
        for (int i = 1; i < bdfriends.BaseDatos.Count; i++)
        {
            for (int j = 0; j < bdfriends.BaseDatos.Count - 1; j++)
            {
                if (bdfriends.BaseDatos[j].puntuacion > bdfriends.BaseDatos[j + 1].puntuacion)
                {
                    obj = bdfriends.BaseDatos[j];
                }
                bdfriends.BaseDatos[j] = bdfriends.BaseDatos[j + 1];
                bdfriends.BaseDatos[j + 1] = obj;
            }
            //Debug.Log("Puntuación del Jugador: " + bdfriends.BaseDatos[i].nombre + " es de: " + bdfriends.BaseDatos[i].puntuacion);
        }

        obj = null;
        for (int i = 1; i < bdglobal.BaseDatos.Count; i++) {
            for (int j = 0; j < bdglobal.BaseDatos.Count - 1; j++) {
                if (bdglobal.BaseDatos[j].puntuacion > bdglobal.BaseDatos[j + 1].puntuacion)
                {
                    obj = bdglobal.BaseDatos[j];
                }
                bdglobal.BaseDatos[j] = bdglobal.BaseDatos[j + 1];
                bdglobal.BaseDatos[j + 1] = obj;
            }
            Debug.Log("Puntuación del Jugador: " + bdglobal.BaseDatos[i].nombre + " es de: " + bdglobal.BaseDatos[i].puntuacion);
        }
    }
}
