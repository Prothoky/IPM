using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close_Button_Script : MonoBehaviour
{

    public Button button;

    void Start()
    {
        Button  btn1 = button.GetComponent<Button>();  

        //Calls the TaskOnClick/TaskWithParameters method when you click the Button
        btn1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
        Application.Quit();
    }

    void TaskWithParameters(string message)
    {
        //Output this to console when the Button is clicked
        Debug.Log(message);
    }

}
