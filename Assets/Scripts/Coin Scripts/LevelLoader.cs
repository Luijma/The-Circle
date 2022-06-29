using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }

    }

    public void LoadNextLevel()
    {
        //Call LoadLevel instead of LoadScene
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //Automates our current Index Build
        //SceneManager.LoadScene("SceneChange"); //Can also use Scene Indexer which accesses Built Scenes and their set order
    }

    //Coroutine for scene transition pause
    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start"); //Start trigger in Animation Controller

        //Wait for animation to stop playing
        yield return new WaitForSeconds(transitionTime);

        //Load scene
        SceneManager.LoadScene(levelIndex);
    }
}