using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[Header("Yin or Yang")]
	public bool Yin;
	public bool Yang;

	[Header("Basic settings")]
    public float Speed;
	public Rigidbody2D rb;
	public bool Control = true;

	[Header("Audio Clip")]	
	public AudioSource Source;
	public AudioClip Collision;

	[Header("Size Settings")]
    public Vector2 StandardScale;	
	public Vector2 SizeScale; 
	public float SizeSpeed; 
	public float StandardSpeed; 
	public bool SizeUp;

	[Header("Magnet Settings")]	
	public float MagnetForce;
	bool CollisionMagnet;
	public GameObject MagnetismSound;
	public ParticleSystem MagnetismParticle;

	void Start()
	{
	  	Control = true;
	}

	void FixedUpdate()
	{
    	//Movement key
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
		GameObject[]  BlackObjects = GameObject.FindGameObjectsWithTag("BlackTerrain");
		GameObject[]  WhiteObjects = GameObject.FindGameObjectsWithTag("WhiteTerrain");

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

		//Change Dimension
		if(SizeUp == true)
		{
			transform.localScale = Vector2.Lerp (transform.localScale, SizeScale, SizeSpeed * Time.deltaTime);
		}
		else
		{
			StopCoroutine(LerpFunction());
			transform.localScale = Vector2.Lerp (transform.localScale, StandardScale, StandardSpeed * Time.deltaTime);
		}		
	}

	public IEnumerator LerpFunction()
	{
		SizeUp = true;
		yield return new WaitForSeconds(5.0f);
		SizeUp = false;
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		Source.PlayOneShot(Collision, 0.1F);

		if(other.gameObject.tag == "Size")
		{
			if(SizeUp == false)
			{
				StartCoroutine(LerpFunction());
			}
		}

		if(other.gameObject.tag == "Magnet")
		{
			CollisionMagnet = true;
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if(other.gameObject.tag == "Magnet")
		{
			CollisionMagnet = false;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Magnet" && CollisionMagnet == false)
		{
			if(Yin == true && Yang == false)
			{
				Vector2 direction = transform.position - other.transform.position;
				float distance = direction.magnitude;
				direction = direction.normalized;
				float forceRate = (MagnetForce/ distance);
				GameObject OtherSObj = other.GetComponent<Magnet>().OtherSideObj;
				other.GetComponent<Rigidbody2D>().AddForce(direction * (forceRate / other.GetComponent<Rigidbody2D>().mass));
				OtherSObj.GetComponent<Rigidbody2D>().AddForce(direction * (forceRate / other.GetComponent<Rigidbody2D>().mass));
			}
			else if(Yin == false && Yang == true)
			{
				Vector2 direction = transform.position - other.transform.position;
				float distance = direction.magnitude;
				direction = direction.normalized;
				float forceRate = (MagnetForce/ distance);
				GameObject OtherSObj = other.GetComponent<Magnet>().OtherSideObj;
				other.GetComponent<Rigidbody2D>().AddForce(-direction * (forceRate / other.GetComponent<Rigidbody2D>().mass));
				OtherSObj.GetComponent<Rigidbody2D>().AddForce(-direction * (forceRate / other.GetComponent<Rigidbody2D>().mass));		
			}
		}				
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Magnet")
		{
			MagnetismSound.SetActive(true);
			MagnetismParticle.Play();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Magnet")
		{
			MagnetismSound.SetActive(false);
			MagnetismParticle.Stop();
		}
	}
}