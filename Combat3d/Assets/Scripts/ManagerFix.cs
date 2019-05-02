using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ManagerFix : MonoBehaviour
{

    public void PlayGame() // loads game
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }


    // quits game

    public void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }





   
    


    //set fullscreen settings


    public void SetFullscreen(bool isFullscreen)
    {
        bool FullscreenValue = isFullscreen;

        Screen.fullScreen = FullscreenValue;

        if (FullscreenValue == true)
        {
            isFullscreenValue = 1;

        }

        else
        {
            isFullscreenValue = 0;
        }
        PlayerPrefs.SetInt("isFullscreen", isFullscreenValue);

    }


    //resolution settings

    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    int isFullscreenValue;
   


    //method that sets fullscreen on start
    public Toggle FullscreenToggle;
    public void FullscreenStart()
    {

        if (isFullscreenValue == 0)
        {
            Screen.fullScreen = false;
            FullscreenToggle.isOn = false;
        }
        if (isFullscreenValue == 1)
        {
            Screen.fullScreen = true;
            FullscreenToggle.isOn = true;
        }

    }


   



    public void SetResolutionStart()
    {
       int ResolutionIndexValue1 = PlayerPrefs.GetInt("ResolutionIndex");

        Resolution resolution1 = resolutions[ResolutionIndexValue1];
        Screen.SetResolution(resolution1.width, resolution1.height, Screen.fullScreen);
        

    }



    // START METHOD HERE

    public int ResolutionIndexValue;
    void Start()
    {

        isFullscreenValue = PlayerPrefs.GetInt("isFullscreen");
        ResolutionIndexValue = PlayerPrefs.GetInt("ResolutionIndex");
        

        FullscreenStart();




        //getting resolution options at starting the scene
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SetResolutionStart();

    }

    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", resolutionIndex);
        ResolutionIndexValue = resolutionIndex;


    }






}
