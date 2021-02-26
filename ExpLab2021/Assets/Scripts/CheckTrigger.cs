using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    public bool OnDeathTrigger;

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
            OnDeathTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin" || other.gameObject.tag == "Yang")
        {
            OnDeathTrigger = false;
        }
    }
}
