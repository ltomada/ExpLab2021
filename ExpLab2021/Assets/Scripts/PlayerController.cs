using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	[Header("Yin or Yang")]
	public bool Yin;
	public bool Yang;

	[Header("Basic settings")]
    public float Speed;
	public Rigidbody2D rb;
	public bool Control = true;

	void Start()
	{
	  	Control = true;
		  
	  	//Ingnora Collisioni
		GameObject[] BlackObjects = GameObject.FindGameObjectsWithTag("BlackTerrain");
		GameObject[] WhiteObjects = GameObject.FindGameObjectsWithTag("WhiteTerrain");

		if(Yin == true && Yang == false)
		{
			foreach (GameObject obj in BlackObjects) 
			{
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
			}
		}

		if(Yin == false && Yang == true)
		{
			foreach (GameObject obj in WhiteObjects) 
			{
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
			}
		}
	}

	void Update()
	{
    // Movement key
    	if(Control == true)
		{
			if(Yin == true && Yang == false)
			{
				if(Input.GetKey(KeyCode.D))
	   			{
		   			rb.AddForce(new Vector2 (Speed,0f));
	   			}
			
	   			if(Input.GetKey(KeyCode.A))
	   			{
			   	rb.AddForce(new Vector2 (-Speed,0f));
	   			}


	   			if(Input.GetKey(KeyCode.W))
	   			{
			   		rb.AddForce(new Vector2 (0f,Speed));
	   			}

	   			if(Input.GetKey(KeyCode.S))
	   			{
		 	  	rb.AddForce(new Vector2 (0f,-Speed));
				}	   			
			}

			if(Yin == false && Yang == true)
			{
				if(Input.GetKey(KeyCode.RightArrow))
	   			{
		   			rb.AddForce(new Vector2 (Speed,0f));
	   			}
			
	   			if(Input.GetKey(KeyCode.LeftArrow))
	   			{
			   	rb.AddForce(new Vector2 (-Speed,0f));
	   			}


	   			if(Input.GetKey(KeyCode.UpArrow))
	   			{
			   		rb.AddForce(new Vector2 (0f,Speed));
	   			}

	   			if(Input.GetKey(KeyCode.DownArrow))
	   			{
		 	  	rb.AddForce(new Vector2 (0f,-Speed));
				}	   			
			}      	      		
		}


		//Ingnora Collisioni
		GameObject[] BlackObjects = GameObject.FindGameObjectsWithTag("BlackTerrain");
		GameObject[] WhiteObjects = GameObject.FindGameObjectsWithTag("WhiteTerrain");

		if(Yin == true && Yang == false)
		{
			foreach (GameObject obj in BlackObjects) 
			{
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
			}
		}

		if(Yin == false && Yang == true)
		{
			foreach (GameObject obj in WhiteObjects) 
			{
				Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
			}
		}
	}
}