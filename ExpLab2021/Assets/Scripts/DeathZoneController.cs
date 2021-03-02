using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    public GameObject Yin;
    public GameObject Yang;
    public GameObject DeathSound;
    public bool VoidTrigger;
    public bool PlatformTrigger;
    public bool FloorTrigger;

    void Start()
    {
        Yin = GameObject.FindGameObjectWithTag("Yin");
        Yang = GameObject.FindGameObjectWithTag("Yang");
    }

    void Update()
    {

        if(VoidTrigger == true && PlatformTrigger == false && FloorTrigger == false)
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
        GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
    }
}
