using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject _mainMenu;
    public GameObject settingMenu;
    public Text _scoreText;
    public GameObject vibrationOn;
    public GameObject vibrationOff;
    public GameObject musicOn;
    public GameObject musicOff;
    public GameObject soundOn;
    public GameObject soundOff;
    AudioSource audioSource;
    public AudioClip buttonSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _scoreText.text = PlayerPrefs.GetInt("Pickup").ToString();
        settingMenu.SetActive(false);
        //PlayerPrefs
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
    public void ButtonClickSound()
    {
        if (PlayerPrefs.GetInt("ESound")==1)
        {
            audioSource.PlayOneShot(buttonSound);
        }
    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("Pickup", 0);
        _scoreText.text = PlayerPrefs.GetInt("Pickup").ToString();
    }
    public void PlayGame()
    {

        SceneManager.LoadScene(1);
    }
    public void ExitGm()
    {
        Application.Quit();
    }
    public void ShowSetting()
    {
        settingMenu.SetActive(true);
    }
    public void HideSetting()
    {
        settingMenu.SetActive(false);
    }
    public void EnableVirbration()
    {
        Debug.Log("Enabled");

        vibrationOn.SetActive(true);
        vibrationOff.SetActive(false);
        PlayerPrefs.SetInt("EVibration", 1);
    }
    public void DisableVirbration()
    {
        Debug.Log("Disabled");
        vibrationOn.SetActive(false);
        vibrationOff.SetActive(true);
        PlayerPrefs.SetInt("EVibration", 0);
    }
    public void EnableBGMusic()
    {
        musicOn.SetActive(true);
        musicOff.SetActive(false);
        PlayerPrefs.SetInt("EMusic", 1);
    }
    public void DisableBGMusic()
    {
        musicOn.SetActive(false);
        musicOff.SetActive(true);
        PlayerPrefs.SetInt("EMusic", 0);
    }
    public void EnableSound()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        PlayerPrefs.SetInt("ESound", 1);
    }
    public void DisableSound()
    {
        soundOff.SetActive(true);
        soundOn.SetActive(false);
        PlayerPrefs.SetInt("ESound", 0);

    }

}
