using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public string sceneToLoad;
    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
        */
    }

    public void LoadNextLevel()
    {
        //Call LoadLevel instead of LoadScene
        StartCoroutine(LoadLevel());

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Automates our current Index Build
        //SceneManager.LoadScene("SceneChange"); //Can also use Scene Indexer which accesses Built Scenes and their set order
    }

    //Coroutine for scene transition pause
    IEnumerator LoadLevel()
    {
        //Play animation
        transition.SetTrigger("Start"); //Start trigger in Animation Controller

        //Wait for animation to stop playing
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.LoadLevel(sceneToLoad);
        }
        else
        {
            PhotonNetwork.LoadLevel(sceneToLoad);
        }
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

    }
}