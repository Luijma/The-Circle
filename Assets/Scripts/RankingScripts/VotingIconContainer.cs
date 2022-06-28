using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VotingIconContainer : MonoBehaviour
{
    public List<DmIconItem> icons = new List<DmIconItem>();
    public DmIconItem votingIconPrefab;
    public Transform votingIconParent;
    public VotingManager votingManager;

    private void PopulateVotingIconContainer()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player != PhotonNetwork.LocalPlayer)
            {
                DmIconItem newVotingIcon = Instantiate(votingIconPrefab, votingIconParent);
                newVotingIcon.SetPlayerInfo(player);
                newVotingIcon.votingManager = votingManager;
                newVotingIcon.parent = votingIconParent;
                icons.Add(newVotingIcon);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        PopulateVotingIconContainer();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
