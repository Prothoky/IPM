using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertasLogin : MonoBehaviour
{

    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    public void ClosePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(false);
        }
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }
}
