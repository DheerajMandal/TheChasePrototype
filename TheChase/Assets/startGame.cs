using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startGame : MonoBehaviour
{
  
    public void startGameAgain()
    {
        SceneManager.LoadSceneAsync("main");
        Time.timeScale = 1;
    }
}
