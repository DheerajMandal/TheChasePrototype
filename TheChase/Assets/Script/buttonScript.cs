using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour
{
 
   public void startTheGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("main");
        Time.timeScale = 1;
    }
}
