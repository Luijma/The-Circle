using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class DmIconItem : MonoBehaviourPunCallbacks
{
    public Image characterImage;
    public Sprite[] characters;
    public TMP_Text userName;
    public Button dmButton;
    public Transform parent;
    public VotingManager votingManager;
    Player player;

    public void IconOnClick()
    {
        Player playerVoted = null;
        // Code for voting here
        foreach (Player _player in PhotonNetwork.PlayerList)
        {
            if (this.userName.text == _player.NickName)
            {
                playerVoted = _player;
                break;
            }
        }
        if (playerVoted == null)
        {
            playerVoted = null;
            Debug.Log("Player appeared as NULL during IconOnClick");
        }
        votingManager.TallyVote(playerVoted);
        votingManager.PlayerVoted(PhotonNetwork.LocalPlayer);
    }
    // Voting function for Influencer Election Mode
    public void InfluencerVoteOnClick()
    {

    }
    public void SetPlayerInfo(Player _player)
    {
        // Here is also where we'd set the background image later on

        player = _player;
        userName.text = _player.NickName;
        UpdateDmIconItem(player);
        // characterImage.sprite = characters[characterIndex];
    }
    private void UpdateDmIconItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("characterImage"))
        {
            int characterIndex = (int)player.CustomProperties["characterImage"];
            characterImage.sprite = characters[characterIndex];
        }
        else
        {
            Debug.Log("Custom Properties missing characterImage, using default");
            characterImage.sprite = characters[0];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            Debug.Log("player was evaluated as targetPlayer. Updating items");
            UpdateDmIconItem(targetPlayer);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}