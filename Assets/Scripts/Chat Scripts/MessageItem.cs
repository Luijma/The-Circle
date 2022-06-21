using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class MessageItem : MonoBehaviour
{
    public TMP_Text messageText;
    public Image profilePic;
    public string receiver = "public chat";
    public string sender = "public chat";
    public Sprite[] characters;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Implementing the Image code is harder so we'll have to work on that later
    public void SetMessageItemInfo(string _messageText, string senderUsername)
    {
        messageText.text = _messageText;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if(player.NickName == senderUsername)
            {
                if(player.CustomProperties.ContainsKey("characterImage"))
                {
                    int characterIndex = (int)player.CustomProperties["characterImage"];
                    profilePic.sprite = characters[characterIndex];
                }
            }
        }
        //profilePic = _profilePic;
    }
    
}
