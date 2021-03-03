using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public bool Void;
    public bool Platform;
    public bool Floor;
    public bool Hallway;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin" || other.gameObject.tag == "Yang")
        {
            if(Floor == true)
            {
                GameObject.Find("DeathController").GetComponent<DeathZoneController>().FloorTrigger = true;
            }

            if(Platform == true)
            {
                GameObject.Find("DeathController").GetComponent<DeathZoneController>().PlatformTrigger = true;
            }

            if(Void == true)
            {
                GameObject.Find("DeathController").GetComponent<DeathZoneController>().VoidTrigger = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin" || other.gameObject.tag == "Yang")
        {
            if(Floor == true)
            {
                GameObject.Find("DeathController").GetComponent<DeathZoneController>().FloorTrigger = false;
            }

            if(Platform == true)
            {
                GameObject.Find("DeathController").GetComponent<DeathZoneController>().PlatformTrigger = false;
            }

            if(Void == true)
            {
                GameObject.Find("DeathController").GetComponent<DeathZoneController>().VoidTrigger = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Yin" && Hallway == true && other.gameObject.transform.localScale.magnitude > 0.49f) 
       {
           GameObject.Find("DeathController").GetComponent<DeathZoneController>().Hallway = true;
       }
    }
}
