using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageItem : MonoBehaviour
{
    public TMP_Text messageText;
    public Image profilePic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Implementing the Image code is harder so we'll have to work on that later
    public void SetMessageItemInfo(string _messageText /* Image _profilePic */)
    {
        messageText.text = _messageText;
        //profilePic = _profilePic;
    }
    
}
