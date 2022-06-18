using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class DmIconItem : MonoBehaviour
{
    public Image characterImage;
    public Sprite[] characters;
    public TMP_Text userName;
    public Button dmButton;

    public void IconOnClick()
    {
    }
    public void SetPlayerInfo(Player _player)
    {
        // Here is also where we'd set the background image later on
        userName.text = _player.NickName;
        int characterIndex = (int)_player.CustomProperties["characterImage"];
        characterImage.sprite = characters[characterIndex];
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
