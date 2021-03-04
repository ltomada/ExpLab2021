using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public bool Fade = false;
    public int SceneToLoad;

    private Scene ThisScene;
    private string scene;
    public int SceneInt;

    void Update()
    {
       ThisScene = SceneManager.GetActiveScene();
       scene = ThisScene.name;
       SceneInt = SceneManager.GetActiveScene().buildIndex;
 

      if(Fade == true)
      {
         LoadNextLevel(SceneToLoad);
         transition.SetBool("Fade", true);
      }      

      if(SceneToLoad > PlayerPrefs.GetInt("levelAt"))
      {
          PlayerPrefs.SetInt("levelAt", SceneToLoad);
      }

      if(Input.GetKeyDown(KeyCode.R))
      {
         LoadNextLevel(SceneInt);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.N))
      {
         LoadNextLevel(SceneToLoad);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.M))
      {
         LoadNextLevel(SceneToLoad);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha0))
      {
         LoadNextLevel(0);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha1))
      {
         LoadNextLevel(1);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha2))
      {
         LoadNextLevel(2);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha3))
      {
         LoadNextLevel(3);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha4))
      {
         LoadNextLevel(4);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha5))
      {
         LoadNextLevel(5);
         transition.SetBool("Fade", true);
      }

      if(Input.GetKeyDown(KeyCode.Alpha6))
      {
         LoadNextLevel(6);
         transition.SetBool("Fade", true);
      }
    }  

    public void LoadNextLevel(int SceneToLoad)
    {
      StartCoroutine(LoadLevel(SceneToLoad));
    }

    IEnumerator LoadLevel(int LevelIndex)
    {  
       yield return new WaitForSeconds(transitionTime);
       SceneManager.LoadScene(LevelIndex);
    }
}
