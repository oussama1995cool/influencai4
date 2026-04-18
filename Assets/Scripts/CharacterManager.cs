using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] characters;

    [Header("Character Spawner")]
    public float cameraDistance;
    public float animationSpeed;
    public float spawnDistance;
    Ray ray;
    RaycastHit hit;
    bool acLeft;
    bool acRight;
    float t;
    GameObject tempPlayer;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("CharacterSequence"))
        {
            PlayerPrefs.SetInt("CharacterSequence",0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Camera.main.transform.position);
        Debug.DrawRay(ray.origin,ray.direction*500,Color.red);
        if (Physics.Raycast(ray,out hit,500))
        {
            Debug.Log("Ray Hit");
            hit.transform.Rotate(Vector3.left);
            Debug.Log(hit.transform.gameObject.name);
        }
        if (acLeft)
        {
            t = 0;
            t += Time.deltaTime;
            Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, Camera.main.transform.position.x - cameraDistance, t), Camera.main.transform.position.y, Camera.main.transform.position.y);
        }
        if (acRight)
        {
            t = 0;
            t += Time.deltaTime;
            Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, Camera.main.transform.position.x + cameraDistance, t), Camera.main.transform.position.y,Camera.main.transform.position.z);
        }
    }
    void ReplaceCharacter()
    {
        //To be called in start of scene;
        //Find and disable mesh of player and instantiate character as a child
        GameObject temp;
        tempPlayer = GameObject.FindGameObjectWithTag("Player");
        tempPlayer.GetComponentInChildren<MeshRenderer>().enabled = false;
        temp = Instantiate(characters[PlayerPrefs.GetInt("CharacterSequence")], tempPlayer.transform);

    }
    public void SpawnCharacter()
    {
        float spacing =0 ;
        GameObject obj;
        foreach (GameObject gm in characters)
        {
           obj= Instantiate(gm,transform);
           obj.transform.position = new Vector3(obj.transform.position.x + spacing, obj.transform.position.y, obj.transform.position.z);
           spacing += spawnDistance;
        }
    }
    //Ui Button Functions
    public void NextCharacter()
    {
        acLeft = false;
        acRight = true;
    }
    public void PreviousCharacter()
    {
        acLeft = true;
        acRight = false;
    }
    public void SelectCharacter()
    {
        ray = Camera.main.ScreenPointToRay(Camera.main.transform.position);
        Debug.DrawRay(ray.origin, ray.direction * 500, Color.blue);
        if (Physics.Raycast(ray, out hit, 500))
        {
            Debug.Log("Ray Hit");
            hit.transform.Rotate(Vector3.left);
            Debug.Log(hit.transform.gameObject.name);
            PlayerPrefs.SetInt("CharacterSequence", hit.transform.gameObject.GetComponent<CharacterIdentifier>().squenceNumber);
        }
    }
    
}
