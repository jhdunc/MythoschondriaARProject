using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
   public void LoadScene(string sceneName)
    {
        Debug.Log("SCENE LOADED OMG");
        SceneManager.LoadScene(sceneName);
    }
}
