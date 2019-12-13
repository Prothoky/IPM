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
        foreach(GameObject panel in Paneles)
        {
            if(panel.name != "TUTO_1")
            {
                panel.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTuto_1()
    {
        foreach (GameObject panel in Paneles)
        {
            if (panel.name != "TUTO_1")
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }

    public void ChangeTuto_2()
    {
        foreach (GameObject panel in Paneles)
        {
            if (panel.name != "TUTO_2")
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }

    public void ChangeTuto_3()
    {
        foreach (GameObject panel in Paneles)
        {
            if (panel.name != "TUTO_3")
            {
                panel.SetActive(false);
            }
            else
            {
                panel.SetActive(true);
            }
        }
    }

}
