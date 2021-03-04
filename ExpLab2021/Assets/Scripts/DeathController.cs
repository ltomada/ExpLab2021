using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject Yin;
    public GameObject Yang;
    public GameObject DeathSound;
    public bool Hallway;


    void Start()
    {
        Yin = GameObject.FindGameObjectWithTag("Yin");
        Yang = GameObject.FindGameObjectWithTag("Yang");
    }

    void Update()
    {

        if(Yin.GetComponent<Player>().OnVoid == true && Yin.GetComponent<Player>().OnPlatform == false && Yin.GetComponent<Player>().OnFloor == false)
        {
            StartCoroutine(Death());  
            Yin.GetComponent<Player>().Control = false; 
            Yang.GetComponent<Player>().Control = false;        
        }

        if(Yang.GetComponent<Player>().OnVoid == true && Yang.GetComponent<Player>().OnPlatform == false && Yang.GetComponent<Player>().OnFloor == false)
        {
            StartCoroutine(Death());  
            Yin.GetComponent<Player>().Control = false; 
            Yang.GetComponent<Player>().Control = false;        
        }

        if(Hallway == true)
        {
            StartCoroutine(Death());  
            Yin.GetComponent<Player>().Control = false; 
            Yang.GetComponent<Player>().Control = false; 
        }
    }

    public IEnumerator Death()
    {
        yield return new WaitForSeconds(1.0f);
        DeathSound.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneInt;
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
    }
}
