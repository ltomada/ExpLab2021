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
                other.gameObject.GetComponent<Player>().OnFloor = true;
            }

            if(Void == true)
            {
                other.gameObject.GetComponent<Player>().OnVoid = true;
            }
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin" || other.gameObject.tag == "Yang")
        {   
            if(Platform == true)
            {
                other.gameObject.GetComponent<Player>().OnPlatform = true;
            }
        }     
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin" || other.gameObject.tag == "Yang")
        {
            if(Floor == true)
            {
                other.gameObject.GetComponent<Player>().OnFloor = false;
            }

            if(Platform == true)
            {
                other.gameObject.GetComponent<Player>().OnPlatform = false;
            }

            if(Void == true)
            {
                other.gameObject.GetComponent<Player>().OnVoid = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
       if(other.gameObject.tag == "Yin" && Hallway == true && other.gameObject.transform.localScale.magnitude > 0.49f) 
       {
           GameObject.Find("DeathController").GetComponent<DeathController>().Hallway = true;
       }
    }
}
