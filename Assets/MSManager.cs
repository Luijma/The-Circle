using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MSManager : MonoBehaviour
{
    // Start is called before the first frame update
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
     }
}