using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Goodbye_Handler : MonoBehaviour
{
    Transform messageBox;
    public Sprite[] characters;
    public GoodbyeMessage goodbyeMessage;
    // Start is called before the first frame update
    void Start()
    {
        string message = (string)PhotonNetwork.CurrentRoom.CustomProperties["eliminatedNickname"];
        message = message + "\n" + (string)PhotonNetwork.CurrentRoom.CustomProperties["eliminatedMessage"];

        int characterIndex = (int)PhotonNetwork.CurrentRoom.CustomProperties["eliminatedImage"];
        goodbyeMessage.profilePicture.sprite = characters[characterIndex];
        goodbyeMessage.messageText.text = message;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
