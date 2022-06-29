using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefabs;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private void Start()
    {
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefabs.name, randomPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
