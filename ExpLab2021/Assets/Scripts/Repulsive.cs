using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulsive : MonoBehaviour
{  
    public float RepulsiveForce;

    void Start()
    {
        
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
      other.rigidbody.AddForce(-other.contacts[0].normal * RepulsiveForce, ForceMode2D.Impulse);     
    }
}
