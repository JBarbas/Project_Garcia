using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    private AsyncOperation nextLevel;

    private void Start()
    {
        nextLevel = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        nextLevel.allowSceneActivation = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Agent Garcia")
        {
            nextLevel.allowSceneActivation = true;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
