using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Winscene : MonoBehaviour
{

    
   
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Winscreen()
    {
      
        gameObject.SetActive(true);
       
    }

    public void QuitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void Playagain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
    public void ReturntoMenu()
    {
        SceneManager.LoadScene(0);
        //Time.timeScale = 0f;
    }
}
