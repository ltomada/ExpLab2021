using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        GameObject[]  Platform = GameObject.FindGameObjectsWithTag("Platform");

		foreach (GameObject obj in Platform) 
		{
			Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
		}
    }
}
