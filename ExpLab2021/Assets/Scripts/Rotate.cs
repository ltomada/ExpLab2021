using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float RotateSpeed;
    float x;
    float y;
    float z;
    public bool RotateOnX;
    public bool RotateOnY;
    public bool RotateOnZ;

    void Update()
    {
        if(RotateOnX == true)
        {
            x = RotateSpeed;
            y = 0;
            z = 0;
        }

        if (RotateOnY == true)
        {
            x = 0;
            y = RotateSpeed;
            z = 0;
        }

        if (RotateOnZ == true)
        {
            x = 0;
            y = 0;
            z = RotateSpeed;
        }

        transform.Rotate(x, y, z);
    }
}
