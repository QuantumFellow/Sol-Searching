using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class SettingMenu : MonoBehaviour
{

    public TMPro.TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    FMOD.Studio.Bus Master; //Grabs bus from fmod
    float MasterVol = 1f;

    void Awake()
    {
        Master = FMODUnity.RuntimeManager.GetBus("bus:/");
    }

    void Start()
    {
        resolutions = Screen.resolutions;
        //resolutionDropdown.ClearOptions(); //clears dropbox

        List<string> options = new List<string>(); //creates list for new values
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height; //stores the spring to be outputted
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); //adds those strings to the list
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    void Update()
    {
        Master.setVolume(MasterVol);
    }


    public void SetMasterVolume(float vol)
    {
        MasterVol = vol; //controls Master Vol
    }

    public void SetQuality(int qualindex)
    {
        QualitySettings.SetQualityLevel(qualindex);
    }

    public void SetFullScreen(bool IsFullscreen)
    {
        Screen.fullScreen = IsFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex]; //sets the resolution
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}

