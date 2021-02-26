using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticAbility : MonoBehaviour
{
    [Header("Yin Or Yang")]
    public bool Yin;
    public bool Yang;
    public GameObject Player;

    [Header("Magnet Settings")]
	public float MagnetForce;
	public GameObject MagnetismSound;
	public ParticleSystem MagnetismParticle;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "Magnet" && Player.GetComponent<Player>().CollisionMagnet == false)
		{
			if(Yang == true && Yin == false)
			{
				Vector2 direction = transform.position - other.transform.position;
				float distance = direction.magnitude;
				direction = direction.normalized;
				float forceRate = (MagnetForce/ distance);
				GameObject OtherSObj = other.GetComponent<Magnet>().OtherSideObj;
				other.GetComponent<Rigidbody2D>().AddForce(direction * (forceRate / other.GetComponent<Rigidbody2D>().mass));
				OtherSObj.GetComponent<Rigidbody2D>().AddForce(new Vector2(-direction.x, direction.y) * (forceRate / other.GetComponent<Rigidbody2D>().mass));
			}
			else if(Yang == false && Yin == true)
			{
				Vector2 direction = transform.position - other.transform.position;
				float distance = direction.magnitude;
				direction = direction.normalized;
				float forceRate = (MagnetForce/ distance);
				GameObject OtherSObj = other.GetComponent<Magnet>().OtherSideObj;
				other.GetComponent<Rigidbody2D>().AddForce(-direction * (forceRate / other.GetComponent<Rigidbody2D>().mass));
				OtherSObj.GetComponent<Rigidbody2D>().AddForce(-new Vector2(-direction.x, direction.y) * (forceRate / other.GetComponent<Rigidbody2D>().mass));		
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
