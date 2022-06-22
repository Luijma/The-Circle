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
            // Currently its >= to still assign someone for a tie
            // Later on we will need to remove the >= and add a mechanic as tiebreakers
            if ((int)player.CustomProperties["votesAgainstMe"] >= most)
            {
                most = (int)player.CustomProperties["votesAgainstMe"];
                loser = player;
            }
        }
        EjectLoser(loser);
    }
    public void EjectLoser(Player loser)
    {
        if (loser == null)
        {
            Debug.Log("The player is NULL! something went wrong during FindLoser()");
        }
        else
        {
            if(PhotonNetwork.LocalPlayer == loser)
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
            foreach(Player player in PhotonNetwork.PlayerList)
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
                FindLoser();
            }
        }
    }
    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable propertiesThatChanged)
    {
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
