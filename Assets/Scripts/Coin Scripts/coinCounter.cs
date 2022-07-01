using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class coinCounter : MonoBehaviourPunCallbacks
{
    public TMP_Text coinText;
    public static int coinAmount;
    private bool sceneLoading = false;
    public LevelLoader levelLoader;

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinAmount.ToString();

        if (/*PhotonNetwork.IsMasterClient && */ sceneLoading == false && coinAmount == 30)
        {
            sceneLoading = true;
            levelLoader.LoadNextLevel();

        }
    }
}