using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activation : MonoBehaviour
{
    [Header("Basic Activato Settings")]
    public GameObject ObjToActive0;
    public GameObject ObjToActive1;
    public bool Rotation;
    public bool Translation;


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
            if(Translation == true)
            {
                ObjToActive0.GetComponent<MovingPlatform>().Active = false;
                ObjToActive1.GetComponent<MovingPlatform>().Active = false; 
            }
            else if(Rotation == true)
            {
                ObjToActive0.GetComponent<RotationObj>().Active = false;
                ObjToActive1.GetComponent<RotationObj>().Active = false;                
            }
        }

        if(other.gameObject.tag == "Yang")
        {
            if(Translation == true)
            {
                ObjToActive0.GetComponent<MovingPlatform>().Active = true;
                ObjToActive1.GetComponent<MovingPlatform>().Active = true; 
            }
            else if(Rotation == true)
            {
                ObjToActive0.GetComponent<RotationObj>().Active = true;
                ObjToActive1.GetComponent<RotationObj>().Active = true;             
            }
        }
    }
}
