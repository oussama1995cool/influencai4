using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Text;
using System.Threading.Tasks;


public class SplashScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(2f);

        SceneManager.LoadScene(1);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
