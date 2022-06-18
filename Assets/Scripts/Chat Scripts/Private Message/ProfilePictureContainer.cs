using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ProfilePictureContainer : MonoBehaviour
{  
    //Dm Icon variables
    public List<DmIconItem> DmIconList = new List<DmIconItem>();
    public DmIconItem DmIconPrefab;
    public Transform DmIconParent;

    // Panel Setting variables
    public GameObject privateChatContainer;
    public GameObject profilePicContainer;
    public CircleChatManager chatManager;


    void OnDmButtonClick(string userName)
    {
        chatManager.privateReceiver = userName;
        privateChatContainer.SetActive(true);
        profilePicContainer.SetActive(false);
        privateChatContainer.GetComponent<PrivateChatContainer>().OpenChosenChat(userName);
        Debug.Log(userName);
    }

    private void PopulateProfilePictureContainer()
    {
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value != PhotonNetwork.LocalPlayer)
            {
                DmIconItem newDmIcon = Instantiate(DmIconPrefab, DmIconParent);
                newDmIcon.SetPlayerInfo(player.Value);
                newDmIcon.GetComponentInChildren<Button>().onClick.AddListener(delegate { OnDmButtonClick(player.Value.NickName); });
                DmIconList.Add(newDmIcon);
            }
        }
    }
    private void Awake()
    {
        PopulateProfilePictureContainer();
    }
}
