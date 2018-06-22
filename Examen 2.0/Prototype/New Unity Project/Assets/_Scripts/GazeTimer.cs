using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GazeTimer : MonoBehaviour {

    public float myTime = 0f;
    public Transform radialProgress;

    public Transform myHand;
    public Transform theBall;

	void Start () {
        radialProgress.GetComponent<Image>().fillAmount = myTime;
	}
	
	void Update () {

        myTime += Time.deltaTime;
        radialProgress.GetComponent<Image>().fillAmount = myTime/2;

        if (myTime >= 2f)
        {
            GrabBall();
        }
	}

    public void Resetinator()
    {
        myTime = 0f;
        radialProgress.GetComponent<Image>().fillAmount = myTime;
    }

    public void GrabBall()
    {
        theBall.transform.position = new Vector3(myHand.transform.position.x , 0, myHand.transform.position.z);
    }
}
