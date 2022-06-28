using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using TMPro;

public class EliminationManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField messageInput;
    public GameObject waitBox;
    public GameObject sayGoodbyeBox;
    public GameObject safePlayerBox;
    Player eliminated;
    ExitGames.Client.Photon.Hashtable roomProperties = new ExitGames.Client.Photon.Hashtable();
    
    public void StartEliminationProcess(Player loser)
    {
        waitBox.SetActive(false);
        eliminated = loser;
        
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            if (player != loser)
            {
                if (player == PhotonNetwork.LocalPlayer)
                {
                    safePlayerBox.SetActive(true);
                }
            }
            else if (player == PhotonNetwork.LocalPlayer)
            {
                sayGoodbyeBox.SetActive(true);
            }
        }
    }
    public void OnClickSendMessage()
    {
        roomProperties["eliminatedMessage"] = messageInput.text;
        roomProperties["eliminatedNickname"] = eliminated.NickName;
        roomProperties["eliminatedImage"] = eliminated.CustomProperties["characterImage"];
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomProperties);
        
    }
    public void EjectLoser(Player loser)
    {
        if (loser == null)
        {
            Debug.Log("The player is NULL! something went wrong during FindLoser()");
        }
        else
        {
            if (PhotonNetwork.LocalPlayer == loser)
            {
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("StartMenu");
            }
        }
    }
    public void MoveToNextPhase()
    {
        // If only two players left, the game moves on to final phase
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 3)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                // If enough players for the game to continue, restart
                // loop
                PhotonNetwork.LoadLevel("Parting_Words");
            }
        }
        else
        {
            Debug.Log("Time to move on to final Phase !");
            // At the moment, two players are winners it seems
            // We'll need to work on this eventually but for now this works
            PhotonNetwork.LoadLevel("GameWinner");
        }

    }
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey("eliminatedMessage"))
        {
            Debug.Log(eliminated.NickName + " has been kicked!");
            EjectLoser(eliminated);
            MoveToNextPhase();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
