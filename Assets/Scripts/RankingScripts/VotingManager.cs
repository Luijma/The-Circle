using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class VotingManager : MonoBehaviourPunCallbacks
{
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    ExitGames.Client.Photon.Hashtable roomProperties = new ExitGames.Client.Photon.Hashtable();
    public bool voteCheck = false;
    public GameObject waitBox;
    public GameObject votingIconContainer;
    public void PrepareRoomInfo()
    {
        roomProperties["everyoneVoted"] = "false";
        playerProperties["hasVoted"] = "false";
        playerProperties["votesAgainstMe"] = 0;
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
        PhotonNetwork.CurrentRoom.SetCustomProperties(roomProperties);
    }
    public void PlayerVoted(Player votingPlayer)
    {
        playerProperties["hasVoted"] = "true";
        votingPlayer.SetCustomProperties(playerProperties);
        votingIconContainer.SetActive(false);
        waitBox.SetActive(true);

    }
    public void FindLoser()
    {
        int most = 0;
        Player loser = null;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            Debug.Log("Player: " + player.NickName + " Vote total: ");
            if ((int)player.CustomProperties["votesAgainstMe"] > most)
            {
                most = (int)player.CustomProperties["votesAgainstMe"];
                loser = player;
            }
        }
        EjectLoser(loser);
        // If only two players left, the game moves on to final phase
        if (PhotonNetwork.CurrentRoom.PlayerCount >= 3)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel("Group_Chat");
            }
        }
        else
        {
            Debug.Log("Time to move on to final Phase !");
        }
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
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (changedProps.ContainsKey("hasVoted"))
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                if ((string)player.CustomProperties["hasVoted"] == "true")
                {
                    voteCheck = true;
                }
                else
                {
                    voteCheck = false;
                    break;
                }

            }
            if (voteCheck)
            {
                roomProperties["everyoneVoted"] = "true";
                PhotonNetwork.CurrentRoom.SetCustomProperties(roomProperties);
                // FindLoser();
            }
        }
    }
    public void TallyVote(Player targetPlayer)
    {
        ExitGames.Client.Photon.Hashtable voteCount = new ExitGames.Client.Photon.Hashtable();
        voteCount["votesAgainstMe"] = (int)targetPlayer.CustomProperties["votesAgainstMe"] + 1;
        Debug.Log(targetPlayer.NickName + "Received one vote! Total: " + voteCount["votesAgainstMe"]);
        targetPlayer.SetCustomProperties(voteCount);
    }
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey("everyoneVoted"))
        {
            if ((string)propertiesThatChanged["everyoneVoted"] == "true")
            {
                FindLoser();
            }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        PrepareRoomInfo();
    }

    // Update is called once per frame
    void Update()
    {

    }
}