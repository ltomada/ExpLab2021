using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneController : MonoBehaviour
{
    public GameObject OtherSideObj;
    public GameObject VoidObj;
    public bool OnDeathTrigger;
    public bool PlatformTrigger;

    void Start()
    {
        
    }

    void Update()
    {
        OnDeathTrigger = VoidObj.GetComponent<CheckTrigger>().OnDeathTrigger;
        PlatformTrigger = OtherSideObj.GetComponent<CheckTrigger>().OnDeathTrigger;

        if(OnDeathTrigger == true && PlatformTrigger == false)
        {
            GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
        }
    }
}
