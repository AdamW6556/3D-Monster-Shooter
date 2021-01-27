using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject OptionsMenu;

    public Toggle[] resolutiontoggles;
    public int[] screenwidths;
    int activescreenindex;

    void Start()
    {
        activescreenindex = PlayerPrefs.GetInt("active res index");
        bool isfullScreen = (PlayerPrefs.GetInt("fullscreen")==1)?true:false;

        for(int i=0;i<resolutiontoggles.Length;i++)
        {
            resolutiontoggles[i].isOn = i == activescreenindex;
        }
        Setfullscreen(isfullScreen);
    }
    public void LoadGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        //SceneManager.LoadScene("Test_Map");
        SceneManager.LoadScene(1);
        //Time.timeScale = 1f;
    }
    public void MenuQuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }



    [SerializeField] Slider volumeslider;

    public void Awake()
    {
        if(PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeslider.value = PlayerPrefs.GetFloat("Volume");
        }
       
       
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume);
    }

    public void Setscreenquality(int i)
    {
        if(resolutiontoggles[i].isOn)
        {
            activescreenindex = i;
            float x = 16/9f;
            Screen.SetResolution(screenwidths[i],(int)(screenwidths[i]/x),false);
            PlayerPrefs.SetInt("Screen res index", activescreenindex);
            PlayerPrefs.Save();
        }

    }

    public void Setfullscreen(bool isfullscreen)
    {
        for(int i=0; i<resolutiontoggles.Length; i++)
        {
            resolutiontoggles[i].interactable = !isfullscreen;

        }

        if(isfullscreen)
        {
            Resolution[] allresolution = Screen.resolutions;
            Resolution maxResolution = allresolution[allresolution.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);

        }
        else
        {
            Setscreenquality(activescreenindex);
        }

        PlayerPrefs.SetInt("fullscreen", ( (isfullscreen) ? 1:0));
        PlayerPrefs.Save();
    }

}
