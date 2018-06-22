using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    private PlayerProgress playerProgress;

    void Awake()
    {
        DontDestroyOnLoad(this);
        LoadPlayerProgress();
    }

    //can be called to save headrotation to PlayerPrefs
    public void SubmitNewPlayerScore(float newScore)
    {
        if(newScore > playerProgress.headRotation)
        {
            playerProgress.headRotation = newScore;
            SavePlayerProgress();
        }
    }

    //can be called to get the headrotation
    public float GetHighestScore()
    {
        return playerProgress.headRotation;
    }

    //loads the headrotation if it exists
    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("highestScore"))
        {
            playerProgress.headRotation = PlayerPrefs.GetFloat("highestScore");
        }
    }

    //saves the headrotation to playerprefs
    private void SavePlayerProgress()
    {
        PlayerPrefs.SetFloat("highestScore",playerProgress.headRotation);
    }

    public void ClearPlayerProgress()
    {
        PlayerPrefs.SetFloat("highestScore",0);
        playerProgress.headRotation = 0;
    }
}
