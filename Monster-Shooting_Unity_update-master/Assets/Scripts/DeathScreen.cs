using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public Text keytextpickwhite;
    public Text keytextpickdark;
    public Text keytextpickgold;
    public Text keytextpickgrey;
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

        keytextpickdark.enabled = false;
        keytextpickgold.enabled = false;
        keytextpickgrey.enabled = false;
        keytextpickwhite.enabled = false;


    }

    public void ReturntoMenu()
    {
        SceneManager.LoadScene(0);
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMenuscene"));
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(0));
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
