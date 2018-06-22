using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHeadRotation : MonoBehaviour {

    public float myTime = 0f;
    public Transform radialProgress;
    public GameObject PlayGame;
    public DataController dataController;
    public HeadRotation headRotation;
    public GameObject infoText;

    void Awake()
    {
        dataController = FindObjectOfType<DataController>();
        headRotation = FindObjectOfType<HeadRotation>();
    }

    void Update()
    {
        myTime += Time.deltaTime;
        radialProgress.GetComponent<Image>().fillAmount = myTime / 1;

        //displays infotext and enables the play button, also commits a new socre to the datacontroller
        if (myTime >= 1f)
        {
            PlayGame.SetActive(true);
            dataController.SubmitNewPlayerScore(headRotation.angle);
            infoText.SetActive(true);
            Resetinator();
        }
    }

    //resets fillcircle if player is not looking anymore
    public void Resetinator()
    {
        myTime = 0f;
        radialProgress.GetComponent<Image>().fillAmount = myTime;
    }
}
