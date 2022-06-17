using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviourPunCallbacks
{
    public TMP_Text playerName;

    private Image backgroundImage;
    public Color highlightColor;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;
    //A: photon's version of a hashtable (array/list with names)
    ExitGames.Client.Photon.Hashtable playerProperties = new ExitGames.Client.Photon.Hashtable();
    public Image characterImage;
    public Sprite[] avatars;

    Player player;

    private void Awake()
    {
        backgroundImage = GetComponent<Image>();
    }
    //A: this method lets players go into room with their usernames
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
        player = _player;
        UpdatePlayerItem(player);
    }
    //this will only be done to local character (so player knows which is theirs)
    //game object will be highlighted and buttons activated
    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }

    public void OnClickLeftArrow()
    {
        if ((int)playerProperties["characterImage"] == 0)
        {
            playerProperties["characterImage"] = avatars.Length - 1;
        } else
        {
            playerProperties["characterImage"] = (int)playerProperties["characterImage"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public void OnClickRightArrow()
    {
        if ((int)playerProperties["characterImage"] == avatars.Length - 1)
        {
            playerProperties["characterImage"] = 0;
        }
        else
        {
            playerProperties["characterImage"] = (int)playerProperties["characterImage"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(playerProperties);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            UpdatePlayerItem(targetPlayer);
        }
    }

    void UpdatePlayerItem(Player player)
    {
        if (player.CustomProperties.ContainsKey("characterImage"))
        {
            characterImage.sprite = avatars[(int)player.CustomProperties["characterImage"]];
            playerProperties["characterImage"] = (int)player.CustomProperties["characterImage"];
        } else

        {
            playerProperties["characterImage"] = 0;
        }
    }
}
