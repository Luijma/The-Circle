using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GroupIconContainer : MonoBehaviour
{
    public List<GroupChatIcon> chatIconList = new List<GroupChatIcon>();
    public GroupChatIcon chatIconPrefab;
    public Transform ProfileIconParent;


    private void PopulateChatIconContainer()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            GroupChatIcon newGroupChatIcon = Instantiate(chatIconPrefab, ProfileIconParent);
            newGroupChatIcon.SetPlayerInfo(player);
            chatIconList.Add(newGroupChatIcon);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PopulateChatIconContainer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
