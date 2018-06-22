using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class resetScore : MonoBehaviour
{

    public DataController dataController;
    public float myTime;
    public Transform radialProgress;

    void Awake()
    {
        dataController = FindObjectOfType<DataController>();
    }

    void Update()
    {
        myTime += Time.deltaTime;
        radialProgress.GetComponent<Image>().fillAmount = myTime / 1;

        //if the fillcircle is full the playerscore and the stored score will be reset
        if (myTime >= 1f)
        {
            dataController.ClearPlayerProgress();
            Resetinator();
        }
    }

    //resets filcircle if the player looks away
    public void Resetinator()
    {
        myTime = 0f;
        radialProgress.GetComponent<Image>().fillAmount = myTime;
    }
}
