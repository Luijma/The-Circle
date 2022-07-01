using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpawnPlayer : MonoBehaviour
{
    public PlayerController playerPrefabs;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefabs.name, randomPos, Quaternion.identity);
        foreach (Player player in PhotonNetwork.PlayerList )
        {
            int charIndex = (int)player.CustomProperties["characterImage"];
            playerPrefabs.characterImage.sprite = playerPrefabs.avatars[charIndex];
        }
    }
    private void SetPlayerInfo()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
