using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ost : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip Music;

    void Start()
    {
        Source.PlayOneShot(Music, 0.3F);
    }

    void Update()
    {
        //DontDestroyOnLoad(this.gameObject);
    }
}
