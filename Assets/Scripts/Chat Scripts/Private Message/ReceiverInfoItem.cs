using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ReceiverInfoItem : MonoBehaviour
{
    // Start is called before the first frame update
    public Image BGImage;
    public Image backgroundColor;
    public Image CharacterImage;
    public TMP_Text userName;
    public Sprite[] characters;
    public string receiver;

    public void SetReceiverInfo(Player _player)
    {
        userName.text = _player.NickName;
        int characterIndex = (int)_player.CustomProperties["characterImage"];
        CharacterImage.sprite = characters[characterIndex];
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
