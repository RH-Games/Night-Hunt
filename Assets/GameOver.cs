using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
   public void Quit()
    {
        
        Debug.Log("Quit");
        //Application.Quit();
    }

    public void Retry()
    {
        Debug.Log("test");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
