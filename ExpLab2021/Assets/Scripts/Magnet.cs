using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool White;
    public bool Black;
    public GameObject OtherSideObj;

    void Start()
    {
		
    }

    void FixedUpdate()
    {
        //Follow movement

        //Ingnora Collisioni Terreno
		GameObject[]  BlackObjects = GameObject.FindGameObjectsWithTag("BlackTerrain");
		GameObject[]  WhiteObjects = GameObject.FindGameObjectsWithTag("WhiteTerrain");

		if(White == true && Black == false)
		{
			foreach (GameObject obj in BlackObjects) 
			{
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
			}
		}

		if(White == false && Black == true)
		{
			foreach (GameObject obj in WhiteObjects) 
			{
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
			}
		}
    }
}
