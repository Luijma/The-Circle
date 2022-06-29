using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VotingMusicManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "Group_Chat")
        {
            Destroy(gameObject);
        }
        if (currentScene.name == "StartMenu")
        {
            Destroy(gameObject);
        }
    }
}