using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    GameObject[] Paneles;
    // Start is called before the first frame update
    void Start()
    {
        Paneles = GameObject.FindGameObjectsWithTag("TUTO");
        Paneles[1].SetActive(false);
        Paneles[2].SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTuto_1()
    {
        Paneles[0].SetActive(true);
        Paneles[1].SetActive(false);
        Paneles[2].SetActive(false);
    }

    public void ChangeTuto_2()
    {
        Paneles[1].SetActive(true);
        Paneles[0].SetActive(false);
        Paneles[2].SetActive(false);
    }

    public void ChangeTuto_3()
    {
        Paneles[2].SetActive(true);
        Paneles[0].SetActive(false);
        Paneles[1].SetActive(false);
    }

}
