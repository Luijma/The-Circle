using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GroupChatIcon : MonoBehaviourPunCallbacks
{
    public Image characterImage;
    public Sprite[] characters;
    //public TMP_Text userName;
    Player player;

    public void SetPlayerInfo(Player _player)
    {
        // Here is also where we'd set the background image later on

        player = _player;
        // userName.text = _player.NickName;
        UpdateIconItem(player);
        // characterImage.sprite = characters[characterIndex];
    }
    private void UpdateIconItem(Player player)
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
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (player == targetPlayer)
        {
            Debug.Log("player was evaluated as targetPlayer. Updating items");
            UpdateIconItem(targetPlayer);
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
