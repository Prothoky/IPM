using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    // Start is called before the first frame update

    public float time = 0.5f;
    private bool isMaxmap = false;

    public RectTransform bigMapPanel;
    
    IEnumerator Mover(Vector3 posInit,Vector3 posFin)
    {
        float elapsedtime = 0;
        while (elapsedtime < time)
        {
            bigMapPanel.position = Vector3.Lerp(posInit, posFin, (elapsedtime / time));
            elapsedtime += Time.deltaTime;
            yield return null;
            Debug.Log(bigMapPanel.position);
        }
        bigMapPanel.position = posFin;
        isMaxmap = !isMaxmap;
    }

    void MoverMenu(Vector3 posInit, Vector3 posFin)
    {
        StartCoroutine(Mover(posInit,posFin));
    }

    public void Button_map()
    {
        int signo = 1;
        float posFinal=1938;

        if (!isMaxmap)
        {
            signo = -1;
            posFinal = 0;
        }

        MoverMenu(bigMapPanel.position,new Vector3(bigMapPanel.position.x,signo*posFinal,0));
        
    }
            

}
