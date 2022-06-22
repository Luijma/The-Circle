using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Photon.Pun;
using TMPro;

public class TimerCount : MonoBehaviour //PunCallbacks
{
    public float timeValue;
    public TMP_Text timeText;
    //public string levelToLoad;
    //private bool sceneLoading = false;

    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);

        /*if (PhotonNetwork.IsMasterClient && sceneLoading == false && timeValue == 0)
        {
            sceneLoading = true;
            Debug.Log("inside of photon network is master client if statement (generalChatTimer script)");
            PhotonNetwork.LoadLevel(levelToLoad);

        }*/
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}