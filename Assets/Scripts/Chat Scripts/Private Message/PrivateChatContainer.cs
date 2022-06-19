using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PrivateChatContainer : MonoBehaviour
{
    // Receiver Info
    public List<ReceiverInfoItem> receiverInfoList = new List<ReceiverInfoItem>();
    public ReceiverInfoItem receiverInfoItemPrefab;
    public Transform receiverInfoParent;
    // Chatbox
    public List<MessageContentItem> contentList = new List<MessageContentItem>();
    public MessageContentItem messageContentPrefab;
    public Transform contentParent;

    public GameObject profilePictureContainer;
    public GameObject privateChatContainer;
    CircleChatManager chatManager;
    public void PopulateReceiverInfo()
    {
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value != PhotonNetwork.LocalPlayer)
            {
                MessageContentItem newMessageContentItem = Instantiate(messageContentPrefab, contentParent);
                newMessageContentItem.SetMessageContentInfo(player.Value);
                contentList.Add(newMessageContentItem);
            }
        }
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value != PhotonNetwork.LocalPlayer)
            {
                ReceiverInfoItem newReceiverInfoItem = Instantiate(receiverInfoItemPrefab, receiverInfoParent);
                newReceiverInfoItem.SetReceiverInfo(player.Value);
            }
        }
        
    }
    public void OpenChosenChat(string userName)
    {
        foreach (MessageContentItem contentItem in contentList)
        {
            if (contentItem.receiver == userName)
            {
                contentItem.GetComponent<GameObject>().SetActive(true);
                chatManager.chatScrollBar = contentItem.scrollBar;
            }
            else
            {
                contentItem.GetComponent<GameObject>().SetActive(false);
            }
        }
        foreach (ReceiverInfoItem infoItem in receiverInfoList)
        {
            if (infoItem.receiver == userName)
            {
                infoItem.GetComponent<GameObject>().SetActive(true);
            }
            else
            {
                infoItem.GetComponent<GameObject>().SetActive(false);
            }
        }
    }
    public void OnChatClosed()
    {
        chatManager.privateReceiver = "";
        privateChatContainer.SetActive(false);
        profilePictureContainer.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        PopulateReceiverInfo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
