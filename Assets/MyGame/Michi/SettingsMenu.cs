using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    //Variables
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    
    //Resolution Settings
    void Start()
    {
        resolutions = Screen.resolutions;
        

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        LoadSettings();
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        //Set Resolution
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

        //Save Resolution
        PlayerPrefs.SetInt("Resolution", resolutionIndex);
        PlayerPrefs.Save();
    }
       
    //Quality Setting
    public void SetQuality (int qualityIndex) 
    {
        //Set Quality
        QualitySettings.SetQualityLevel(qualityIndex);

        //Save Quality
        PlayerPrefs.SetInt("Quality", qualityIndex);
        PlayerPrefs.Save();
    }

    //Fullscreen Setting
    public void SetFullscreen (bool isFullscreen)
    {
        //Set Fullscreen
        Screen.fullScreen = isFullscreen;

        //Save Fullscreen
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
        PlayerPrefs.Save();
    }

    void LoadSettings()
    {
        // Resolution
        if (PlayerPrefs.HasKey("Resolution"))
        {
            int resolutionIndex = PlayerPrefs.GetInt("Resolution");
            resolutionDropdown.value = resolutionIndex;
            SetResolution(resolutionIndex);
        }

        // Quality
        if (PlayerPrefs.HasKey("Quality"))
        {
            int qualityIndex = PlayerPrefs.GetInt("Quality");
            QualitySettings.SetQualityLevel(qualityIndex);
        }

        // Fullscreen
        if (PlayerPrefs.HasKey("Fullscreen"))
        {
            bool isFullscreen = PlayerPrefs.GetInt("Fullscreen") == 1;
            Screen.fullScreen = isFullscreen;
        }
    }

}
