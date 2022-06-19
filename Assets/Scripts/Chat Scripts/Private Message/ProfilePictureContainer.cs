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


    public void OnDmButtonClick(string userName)
    {
        chatManager.privateReceiver = userName;
        privateChatContainer.SetActive(true);
        profilePicContainer.SetActive(false);
        privateChatContainer.GetComponent<PrivateChatContainer>().OpenChosenChat(userName);
        Debug.Log(userName);
    }

    private void PopulateProfilePictureContainer()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player != PhotonNetwork.LocalPlayer)
            {
                DmIconItem newDmIcon = Instantiate(DmIconPrefab, DmIconParent);
                newDmIcon.SetPlayerInfo(player);
                newDmIcon.GetComponentInChildren<Button>().onClick.AddListener(delegate { OnDmButtonClick(player.NickName); });
                DmIconList.Add(newDmIcon);
            }
        }
    }
    private void Start()
    {
        PopulateProfilePictureContainer();
    }
}
