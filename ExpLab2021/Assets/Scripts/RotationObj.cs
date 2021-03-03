using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObj : MonoBehaviour
{
    public bool Active;
    public float RotateSpeed;
    float z;

    void Start()
    {
        
    }

    void Update()
    {
        if(Active == true)
        {
            z = RotateSpeed;
            transform.Rotate(0, 0, z);
        }
        else
        {
            z = 0;
            transform.Rotate(0, 0, z);        
        }
    }
}
