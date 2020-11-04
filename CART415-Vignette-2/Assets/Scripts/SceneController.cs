using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            int activeScene = SceneManager.GetActiveScene().buildIndex;
            int nextScene = activeScene + 1;

            if (nextScene >= SceneManager.sceneCountInBuildSettings)
            {
                nextScene = 0;
            }
            SceneManager.LoadScene(nextScene);
        }
    }
}
