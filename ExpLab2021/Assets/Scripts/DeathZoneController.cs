using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    public GameObject OtherSideObj;
    public GameObject VoidObj;
    public GameObject Yin;
    public GameObject Yang;
    public GameObject DeathSound;
    public bool OnDeathTrigger;
    public bool PlatformTrigger;

    void Start()
    {
        Yin = GameObject.FindGameObjectWithTag("Yin");
        Yang = GameObject.FindGameObjectWithTag("Yang");
    }

    void Update()
    {
        OnDeathTrigger = VoidObj.GetComponent<CheckTrigger>().OnDeathTrigger;
        PlatformTrigger = OtherSideObj.GetComponent<CheckTrigger>().OnDeathTrigger;

        if(OnDeathTrigger == true && PlatformTrigger == false)
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
