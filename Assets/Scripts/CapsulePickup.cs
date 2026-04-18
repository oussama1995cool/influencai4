using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulePickup : MonoBehaviour
{
    ZUI _zui;
    // Start is called before the first frame update
    void Start()
    {
        _zui = FindObjectOfType<ZUI>();  
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            _zui.soundManager.PlaySoundClip("Pick");
            
            //score playerpref
            if (PlayerPrefs.HasKey("Pickup"))
            {
                PlayerPrefs.SetInt("Pickup", PlayerPrefs.GetInt("Pickup")+1);
                _zui._pickupText.text = PlayerPrefs.GetInt("Pickup").ToString();
            }

        }else if (other.gameObject.CompareTag("virus"))
        {
            Debug.Log("Virus Detected");
            this.transform.position= new Vector3( this.transform.position.x+1, this.transform.position.y, this.transform.position.z);
        }
    }
}
