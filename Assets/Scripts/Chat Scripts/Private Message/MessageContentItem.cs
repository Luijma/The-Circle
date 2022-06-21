using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Photon.Chat;

public class MessageContentItem : MonoBehaviour
{
    public List<MessageItem> messageItemList = new List<MessageItem>();
    public MessageItem messageItemPrefab;
    public Scrollbar chatScrollBar;

    public void DisplayCurrentConversation(ChatChannel currentChannel)
    {
        // This will be called when a conversation is opened only
        string message = "";
        for(int i = 0; i < currentChannel.MessageCount; i++)
        {
            message = string.Format("{0}:\n{1}", currentChannel.Senders[i], currentChannel.Messages[i]);
            Debug.Log("Inside DisplayCurrentConversation, message is:  " + message);
            MessageItem newMessage = Instantiate(messageItemPrefab, this.transform);
            newMessage.SetMessageItemInfo(message, currentChannel.Senders[i]);
            messageItemList.Add(newMessage);
            chatScrollBar.value = 0;
        }
    }
    public void UpdateCurrentConversation(string sender, object message)
    {
        // This will be called when a message is received while a conversation is open
        string msg = "";

        msg = string.Format("{0}:\n{1}", sender, message.ToString());
        Debug.Log("Inside UpdateCurrentConversation, message is: " + msg);
        MessageItem newMessage = Instantiate(messageItemPrefab, this.transform);
        newMessage.SetMessageItemInfo(msg, sender);
        messageItemList.Add(newMessage);
        chatScrollBar.value = 0;
    }
    public void ClearCurrentConversation()
    {
        // This is called when a conversation is closed
        foreach (MessageItem message in messageItemList)
        {
            Destroy(message.gameObject);
        }
        messageItemList.Clear();
    }
}
