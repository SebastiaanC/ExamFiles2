using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadRotation : MonoBehaviour {

    public Transform target;
    public float angle;

    public GameObject text;
    public TextMesh highscoreText;
    public DataController dataController;

    void Awake()
    {
        dataController = FindObjectOfType<DataController>();
    }
    

    private void Update()
    {
        angle = Vector3.Angle(transform.position, target.position);

        //gives current head rotation
        text.GetComponent<TextMesh>().text = "Rotatie Hoofd: " + angle;

        //sets highscore text to highest measure in head rotation
        highscoreText.text = "Hoogste meting: " + dataController.GetHighestScore();
    }
}
