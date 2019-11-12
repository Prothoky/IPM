using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objeto
{
    public int id;
    public string nombre;
    public int puntuacion;
    public string color;
}

[System.Serializable]
public class BaseDatosObjeto
{
    public List<Objeto> BaseDatos;
}