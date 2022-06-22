using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PhotonNetwork.LoadLevel("ConnectToServer");
    }
}
