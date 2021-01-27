using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    //public Weapon weapon;
    // Start is called before the first frame update
    public GameObject Endscrn;
    //Weapon weapon;
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOverscreen()
    {
        if(!Endscrn.activeSelf)
        {
            gameObject.SetActive(true);
        }
        Time.timeScale = 0f;

    }

    public void ReturntoMenu()
    {
        SceneManager.LoadScene(0);
  
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
}
