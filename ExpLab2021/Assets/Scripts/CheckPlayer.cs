using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer : MonoBehaviour
{

    public GameObject Yin;
    public GameObject Yang;
    public bool YinOnTrigger;
    public bool YangOnTrigger;
    public GameObject UnionSound;

    void Start()
    {
        
    }

    void Update()
    {
        if(YinOnTrigger == true && YangOnTrigger == true)
        {
            UnionSound.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin")
        {
            YinOnTrigger = true;
        }

        if(other.gameObject.tag == "Yang")
        {
            YangOnTrigger = true;
        }
    }
}
