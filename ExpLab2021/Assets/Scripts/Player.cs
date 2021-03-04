using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
	[Header("Yin or Yang")]
	public bool Yin;
	public bool Yang;
	public GameObject OthersidePlayer;

	[Header("Basic settings")]
    public float Speed;
	public Rigidbody2D rb;
	public bool Control = true;
  	public bool CollisionMagnet;
	public GameObject WalkParticle;

	[Header("Audio Clip")]	
	public AudioSource Source;
	public AudioClip Collision;

	[Header("Size Settings")]
    public Vector2 StandardScale;	
	public Vector2 SizeScale; 
	public float SizeSpeed; 
	public float StandardSpeed; 
	public bool SizeUp;
	
	[Header("Union Settings")]
	public GameObject Taijitu;	
	public Transform YinPoint;
	public Transform YangPoint;
	bool UnionTrigger = false;

	[Header("Death Animation")]
	public Animator Death;
	public GameObject MagneticAbility;
	public GameObject MagneticEffect;
	public bool OnVoid;
	public bool OnPlatform;
	public bool OnFloor;

	private Scene ThisScene;
    private string scene;

	void Start()
	{
		ThisScene = SceneManager.GetActiveScene();
		scene = ThisScene.name;

		if(scene != "0_MainMenu")
		{
			DynamicSplitScreen.SplitScreenManager.Instance.RegisterPlayer(transform);
		}

	  	Control = true;
	}

	void FixedUpdate()
	{
    	//Movement key
    	if(Control == true)
		{
			if(Yin == false && Yang == true)
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
			else if(Yin == true && Yang == false)
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
		else
		{
			if(scene != "0_MainMenu" && UnionTrigger == false)
			{
				WalkParticle.SetActive(false);
				MagneticAbility.SetActive(false);
				MagneticEffect.SetActive(false);
				Death.SetBool("Death", true);
			}
		}

		if(scene != "0_MainMenu")
		{
			if((GameObject.Find("Taijitu").GetComponent<CheckPlayer>().YinOnTrigger == true) && (GameObject.Find("Taijitu").GetComponent<CheckPlayer>().YangOnTrigger == true))
			{
				if(Yin == false && Yang == true)
				{
					transform.GetComponent<CircleCollider2D>().enabled = false;
					UnionTrigger = true;
					Control = false;
					transform.position = Vector3.Lerp(transform.position, YinPoint.transform.position, Time.deltaTime);
					StartCoroutine(Union());
				}
				else if(Yang == false && Yin == true)
				{
					transform.GetComponent<CircleCollider2D>().enabled = false;
					UnionTrigger = true;
					Control = false;
					transform.position = Vector3.Lerp(transform. position, YangPoint.transform.position, Time.deltaTime);
					StartCoroutine(Union());
				}
			}			
		}

		//Ingnora Collisioni
		//GameObject[]  Walls = GameObject.FindGameObjectsWithTag("Wall");
		GameObject[]  Platform = GameObject.FindGameObjectsWithTag("Platform");

		foreach (GameObject obj in Platform) 
		{
			Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>()); 
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

	public IEnumerator Union()
	{
		yield return new WaitForSeconds(2.5f);
		this.gameObject.transform.SetParent(Taijitu.transform, true);
		Taijitu.GetComponent<Rotate>().enabled = true;
		yield return new WaitForSeconds(5.0f);
		GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
	}
		
	void OnCollisionEnter2D(Collision2D other)
	{
		Source.PlayOneShot(Collision, 0.1F);

		if(other.gameObject.tag == "Size")
		{
			if(SizeUp == false)
			{
				StartCoroutine(LerpFunction());
				StartCoroutine(OthersidePlayer.GetComponent<Player>().LerpFunction());
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
}