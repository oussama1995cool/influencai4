using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ZUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text _pickupText;
    public GameObject _heart1;
    public GameObject _heart2;
    public GameObject _heart3;
    public GameObject _pauseMenu;
    public GameObject _GameOverMenu;
    public Text _counter;
   // public gameAdmanager gad;
    [HideInInspector]public SoundManagr soundManager;
    void Start()
    {
        soundManager = FindObjectOfType<SoundManagr>();
        if (!PlayerPrefs.HasKey("Pickup"))
        {
            PlayerPrefs.SetInt("Pickup",0);
        }
        else
        {
            _pickupText.text = PlayerPrefs.GetInt("Pickup").ToString();
        }
        //Hide UI
        _pauseMenu.SetActive(false);
        _GameOverMenu.SetActive(false);
        //Show Lives
        _heart1.SetActive(true);
        _heart2.SetActive(true);
        _heart3.SetActive(true);
        CountDown();
    }
    public void lifeDisplay(int live)
    {
        Debug.Log("CL Value Passed : " + live);
        switch (live)
        {
            case 2:
                {
                    _heart1.SetActive(true);
                    _heart2.SetActive(true);
                    _heart3.SetActive(false);

                    break;
                }
            case 1:
                {
                    _heart1.SetActive(true);
                    _heart2.SetActive(false);
                    _heart3.SetActive(false);
                    break;
                }
            case 0:
                {
                    _heart1.SetActive(false);
                    _heart2.SetActive(false);
                    _heart3.SetActive(false);
                    break;
                }
        }
    }
    public void Replay()
    {
        
        SceneManager.LoadScene(1);
       // gad.showinterstial();
    }
    public void showPauseMenu()
    {
        _pauseMenu.SetActive(true);
        
    }
    public void HidePauseMenu()
    {
        _pauseMenu.SetActive(true);
    }
    public void LoadMenu()
    {
         
        SceneManager.LoadScene(0);
    }
    void CountDown()
    {
        StartCoroutine(CountDownCo());
    }
    IEnumerator CountDownCo()
    {
        yield return new WaitForSeconds(1);
        _counter.text = "3";
        _counter.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        _counter.text = "2";
        yield return new WaitForSeconds(0.5f);
        _counter.text = "1";
        yield return new WaitForSeconds(0.5f);
        _counter.text = "GO!";
        yield return new WaitForSeconds(0.5f);
        _counter.gameObject.SetActive(false);
        StopCoroutine(CountDownCo());
    }
}
