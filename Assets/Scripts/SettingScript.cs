using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!(PlayerPrefs.HasKey("EVibration")))
        {
            PlayerPrefs.SetInt("EVibration", 1);
        }
        if (!(PlayerPrefs.HasKey("EMusic")))
        {
            PlayerPrefs.SetInt("EMusic", 1);
        }
        if (!(PlayerPrefs.HasKey("ESound")))
        {
            PlayerPrefs.SetInt("ESound", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableVirbration()
    {
            PlayerPrefs.SetInt("EVibration", 1);
    }
    public void DisableVirbration()
    {
        PlayerPrefs.SetInt("EVibration", 0);
    }
    public void EnableBGMusic()
    {
        PlayerPrefs.SetInt("EMusic", 1);
    }
    public void DisableBGMusic()
    {
        PlayerPrefs.SetInt("EMusic", 0);
    }
    public void EnableSound()
    {
        PlayerPrefs.SetInt("ESound", 1);
    }
    public void DisableSound()
    {
        PlayerPrefs.SetInt("ESound", 0);

    }
}
