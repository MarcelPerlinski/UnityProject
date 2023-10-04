using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public Transform button;
   public void RestartLevel()
    {
        Time.timeScale = 1;
        GameMenager.Health = 4;
        SceneManager.LoadScene(0);
    }
}
