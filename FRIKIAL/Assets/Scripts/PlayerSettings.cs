using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSettings : MonoBehaviour
{
 
    void changeplayersettings(string optioname, bool b)
    {
        PlayerPrefs.SetString(optioname,b.ToString());
    }
    
    void update()
    {
        if(GameObject.Find("Toogle_Sound_Yes").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Sound_No").GetComponent<Toggle>().isOn = false;
        else if(GameObject.Find("Toogle_Sound_No").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Sound_Yes").GetComponent<Toggle>().isOn = false;

        if (GameObject.Find("Toogle_Voz_Assistant_Yes").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Voz_Assistant_No").GetComponent<Toggle>().isOn = false;
        else if (GameObject.Find("Toogle_Voz_Assistant_No").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Voz_Assistant_Yes").GetComponent<Toggle>().isOn = false;

        if (GameObject.Find("Toogle_Daltonic_Yes").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Daltonic_No").GetComponent<Toggle>().isOn = false;
        else if (GameObject.Find("Toogle_Daltonic_No").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Daltonic_Yes").GetComponent<Toggle>().isOn = false;

        if (GameObject.Find("Toogle_Vibration_Yes").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Vibration_No").GetComponent<Toggle>().isOn = false;
        else if (GameObject.Find("Toogle_Vibration_No").GetComponent<Toggle>().isOn) GameObject.Find("Toogle_Vibration_Yes").GetComponent<Toggle>().isOn = false;
    }

}
