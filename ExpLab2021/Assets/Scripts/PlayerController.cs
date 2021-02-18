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
    }
}