using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RankingIconContainer : MonoBehaviour
{
    public List<DmIconItem> icons = new List<DmIconItem>();
    DmIconItem influencerIconPrefab;
    Transform InfluencerIconParent;
    ElectionManager electionManager;
    // Start is called before the first frame update

    private void PopulateRankingIconContainer()
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if (player != PhotonNetwork.LocalPlayer)
            {
                DmIconItem newInfluencerIcon = Instantiate(influencerIconPrefab, InfluencerIconParent);
                newInfluencerIcon.SetPlayerInfo(player);
                newInfluencerIcon.electionManager = electionManager;
                newInfluencerIcon.parent = InfluencerIconParent;
                icons.Add(newInfluencerIcon);
            }
        }
    }
    void Start()
    {
        PopulateRankingIconContainer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
