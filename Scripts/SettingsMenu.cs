using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public int index;
    public Text label;
    public Dropdown dropDown;

    public void Start()
    {
        dropDown.value = PlayerPrefs.GetInt("Graphics");
        /*if(PlayerPrefs.GetInt("Graphics") == 0)
        {
            label.text = "LOW";
        }
        if(PlayerPrefs.GetInt("Graphics") == 1)
        {
            label.text = "MEDIUM";
        }
        if(PlayerPrefs.GetInt("Graphics") == 2)
        {
            label.text = "HIGH";
        }
        if(PlayerPrefs.GetInt("Graphics") == 3)
        {
            label.text = "ULTRA";
        }*/
    }


    public void SetQuality(int qualityIndex)
    {
        //QualitySettings.SetQualityLevel(qualityIndex);
        switch(qualityIndex)
        {
            case 0:
                PlayerPrefs.SetInt("Graphics", 0);
                QualitySettings.SetQualityLevel(qualityIndex);
                break;
            case 1:
                PlayerPrefs.SetInt("Graphics", 1);
                QualitySettings.SetQualityLevel(qualityIndex);
                break;
            case 2:
                PlayerPrefs.SetInt("Graphics", 2);
                QualitySettings.SetQualityLevel(qualityIndex);
                break;
            case 3:
                PlayerPrefs.SetInt("Graphics", 3);
                QualitySettings.SetQualityLevel(qualityIndex);
                break;
        }
    }
}
