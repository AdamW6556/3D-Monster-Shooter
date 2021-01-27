using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pauseformenu : MonoBehaviour
{
    public static bool pause = false;
    public GameObject pausemenu;
    public GameObject deathscreen;
    public GameObject winscreen;

    // Update is called once per frame
    void Update()
    {
        if(!deathscreen.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (pause)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }      
    }
    void Resume()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }
    void Pause()
    {
        if(!winscreen.activeSelf)
        {
            pausemenu.SetActive(true);
            Time.timeScale = 0f;
            pause = true;
        }
       
    }
}
