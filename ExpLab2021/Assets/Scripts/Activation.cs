using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [Header("Yin or Yang")]
    public bool YinActivator;
    public bool YangActivator;

    [Header("Basic Activato Settings")]
    public GameObject ObjToActive0;
    public GameObject ObjToActive1;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Yin" || other.gameObject.tag == "Yang")
        {
            if(YinActivator == true && YangActivator == false)
            {
                ObjToActive0.GetComponent<MovingPlatform>().Active = false;
                ObjToActive1.GetComponent<MovingPlatform>().Active = false; 
            }
            else if(YinActivator == false && YangActivator == true)
            {
                ObjToActive0.GetComponent<MovingPlatform>().Active = true;
                ObjToActive1.GetComponent<MovingPlatform>().Active = true;           
            }
        }
    }
}
