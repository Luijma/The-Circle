using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerItem : MonoBehaviour
{
    public TMP_Text playerName;

    private Image backgroundImage;
    public Color highlightColor;
    public GameObject leftArrowButton;
    public GameObject rightArrowButton;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
    }
    //A: this method lets players go into room with their usernames
    public void SetPlayerInfo(Player _player)
    {
        playerName.text = _player.NickName;
    }
    //this will only be done to local character (so player knows which is theirs)
    //game object will be highlighted and buttons activated
    public void ApplyLocalChanges()
    {
        backgroundImage.color = highlightColor;
        leftArrowButton.SetActive(true);
        rightArrowButton.SetActive(true);
    }
}
