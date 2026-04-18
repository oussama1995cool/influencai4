using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagr : MonoBehaviour
{
    public AudioClip bgMusic;
    public AudioClip dieSound;
    public AudioClip hitSound;
    public AudioClip pickupSound;
    public AudioClip clickSound;
    AudioSource audioSource;
    public GameObject bgSound;
    //public static SoundManagr instance;
    // Start is called before the first frame update
    void Start()
    {
        bgSound.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        playBgMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playBgMusic()
    {
        PlayerPrefs.SetInt("EMusic", 1);
        if (PlayerPrefs.GetInt("EMusic") == 1)
        {
            Debug.Log("Music is true");
            bgSound.SetActive(true);
        }
    }
    public void muteBgMusic()
    {

    }
    public void pauseAudio()
    {
        audioSource.Pause();
        bgSound.SetActive(false);
    }
    public void resumeAudio()
    {
        if (PlayerPrefs.GetInt("EMusic") == 1)
        {
            Debug.Log("Music is true");
            bgSound.SetActive(true);
            audioSource.Play();
        }
        audioSource.mute = false;
        bgSound.SetActive(true);
    }
    public void ClickSoundPlay()
    {
        if (PlayerPrefs.GetInt("ESound") == 1)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }
    public void PlaySoundClip(string i)
    {
        switch (i)
        {
            /*case "Music":
                {
                    if (PlayerPrefs.GetInt("EMusic") == 1)
                    {
                        Debug.Log("Music is true");
                        //audioSource.PlayOneShot(bgMusic);
                    }
                    break;
                }*/
            case "Hit":
                {
                    if (PlayerPrefs.GetInt("ESound") == 1)
                    {
                    audioSource.PlayOneShot(hitSound);
                    }
                    break;
                }
            case "Pick":
                {
                    if (PlayerPrefs.GetInt("ESound") == 1)
                    {
                     audioSource.PlayOneShot(pickupSound);
                    }
                    break;
                }
            case "Die":
                {
                    if (PlayerPrefs.GetInt("ESound") == 1)
                    {
                    audioSource.PlayOneShot(dieSound);
                    }
                    break;
                }
            case "Click":
                {
                    if (PlayerPrefs.GetInt("ESound") == 1)
                    {
                        audioSource.PlayOneShot(clickSound);
                    }
                    break;
                }

        }
    }
}
