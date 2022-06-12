using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CircleChatManager : MonoBehaviour, IChatClientListener
{
    #region Setup
    string chatRoomName;

    public void DebugReturn(DebugLevel level, string message)
    {
        // throw new System.NotImplementedException();
    }

    public void OnChatStateChange(ChatState state)
    {
        // throw new System.NotImplementedException();
    }

    public void OnConnected()
    {
        Debug.Log("Connected");
        isConnected = true;
        chatRoomName = PhotonNetwork.CurrentRoom.Name;
        // Have to verify that this code would work properly as is
        // Theres a one region limitation, not sure if this is related
        chatClient.Subscribe(new string[] { chatRoomName });

    }

    public void OnDisconnected()
    {
        throw new System.NotImplementedException();
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msg = "";
        for (int i = 0; i < senders.Length; i++)
        {
            msg = string.Format("{0}:\n{1}", senders[i], messages[i]);

            MessageItem newMessage = Instantiate(messageItemPrefab, contentObject.transform);
            newMessage.SetMessageItemInfo(msg);
            messageItemList.Add(newMessage);
            chatScrollBar.value = 0;
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        // throw new System.NotImplementedException();
    }

    public void OnUnsubscribed(string[] channels)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserSubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        throw new System.NotImplementedException();
    }

    ChatClient chatClient;
    bool isConnected;
    [SerializeField] string userName;

    #endregion Setup

    #region PublicChat

    public void SubmitPublicChatOnclick()
    {
        if (privateReceiver == "")
        {
            chatClient.PublishMessage(chatRoomName, currentChat);
            chatField.text = "";
            currentChat = "";
        }
    }

    public void TypeChatOnValueChange(string valueIn)
    {
        currentChat = valueIn;
    }

    #endregion PublicChat


    #region General

    string currentChat;
    string privateReceiver = "";
    [SerializeField] TMP_InputField chatField;
    [SerializeField] Scrollbar chatScrollBar;

    // for generating messages
    public MessageItem messageItemPrefab;
    List<MessageItem> messageItemList = new List<MessageItem>();
    public GameObject contentObject;

    // Start is called before the first frame update
    void Start()
    {
        isConnected = true;
        userName = PhotonNetwork.NickName;
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(userName));
        Debug.Log("Connecting");
    }

    // Update is called once per frame
    void Update()
    {
        if (isConnected)
        {
            chatClient.Service();
        }
        if (chatField.text != "" && Input.GetKey(KeyCode.Return))
        {
            SubmitPublicChatOnclick();
            // SubmitPrivateChatOnClick();
        }
    }

    #endregion General
}
