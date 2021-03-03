using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
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
        if(other.gameObject.tag == "Yin")
        {
            ObjToActive0.GetComponent<MovingPlatform>().Active = false;
            ObjToActive1.GetComponent<MovingPlatform>().Active = false; 
        }

        if(other.gameObject.tag == "Yang")
        {
            ObjToActive0.GetComponent<MovingPlatform>().Active = true;
            ObjToActive1.GetComponent<MovingPlatform>().Active = true;  
        }
    }
}
