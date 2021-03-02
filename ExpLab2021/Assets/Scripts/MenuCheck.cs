using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCheck : MonoBehaviour
{
    private bool YinOnTrigger;
    private bool YangOnTrigger;
    public bool PlayButton;
    public bool ExitButton;

    void Start()
    {
  
    }

    void Update()
    {
        if(YinOnTrigger == true && YangOnTrigger == true)
        {
            GameObject Yin = GameObject.Find("Yin");
            GameObject Yang = GameObject.Find("Yang");  
            Yin.GetComponent<Player>().Control = false;
            Yang.GetComponent<Player>().Control = false;

            if(PlayButton == true && ExitButton == false)
            {
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = 1;
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
            }

            if(PlayButton == false && ExitButton == true)
            {
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().SceneToLoad = -1;
                GameObject.Find("LevelLoader").GetComponent<LevelLoader>().Fade = true;
                StartCoroutine(Exit());
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
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

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Yin")
        {
            YinOnTrigger = false;
        }

        if(other.gameObject.tag == "Yang")
        {
            YangOnTrigger = false;
        }
    }

    public IEnumerator Exit()
    {
        yield return new WaitForSeconds(2.5f);
        Application.Quit();      
    }
}
