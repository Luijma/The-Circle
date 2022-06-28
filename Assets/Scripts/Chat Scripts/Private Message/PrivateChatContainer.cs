using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Chat;

public class PrivateChatContainer : MonoBehaviour
{
    // Receiver Info
    public List<ReceiverInfoItem> receiverInfoList = new List<ReceiverInfoItem>();
    public ReceiverInfoItem receiverInfoItemPrefab;
    public Transform receiverInfoParent;
    // Chatbox
    public MessageContentItem messageContentItem;
    public ChatChannel currentChat;

    public ProfilePictureContainer profilePictureContainer;
    public PrivateChatContainer privateChatContainer;
    public CircleChatManager chatManager;
  
    public void OpenChosenChat(string userName)
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player.NickName == userName)
            {
                ReceiverInfoItem newReceiverInfoItem = Instantiate(receiverInfoItemPrefab, receiverInfoParent);
                newReceiverInfoItem.SetReceiverInfo(player);
                receiverInfoList.Add(newReceiverInfoItem);

            }
        }
        chatManager.chatClient.TryGetPrivateChannelByUser(userName, out currentChat);
        Debug.Log("current Chat channel: " + currentChat.Name);
        Debug.Log("username: " + userName);

        messageContentItem.DisplayCurrentConversation(currentChat);
        
        Debug.Log("After DisplayCurrent Conversation call");
    }
    public void OnChatClosed()
    {
        chatManager.privateReceiver = "";
        currentChat = null;
        messageContentItem.ClearCurrentConversation();
        // Remove Receiver info
        foreach (ReceiverInfoItem receiverInfo in receiverInfoList)
        {
            Destroy(receiverInfo.gameObject);
        }
        receiverInfoList.Clear();
        privateChatContainer.gameObject.SetActive(false);
        profilePictureContainer.gameObject.SetActive(true);
    }
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
