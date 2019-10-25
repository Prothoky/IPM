using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
 
    void milibro(string optioname, bool b)
    {
        PlayerPrefs.SetString(optioname,b.ToString());
    }
    
}
