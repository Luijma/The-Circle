using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class LeaveMatch : MonoBehaviour
{
    public void OnClick_LeaveMatch()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("StartMenu");
    }
}
