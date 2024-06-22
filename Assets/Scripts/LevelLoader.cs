using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    

    // Update is called once per frame
    void Update()
    {
               
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }
    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        
    }
    public void LoadMainMenu()
    {
        StartCoroutine(LoadLevel(0));
        
    }
    public void LoadHallLevel()
    {
        StartCoroutine(LoadLevel(1));
        
    }
    public void LoadParkLevel()
    {
        StartCoroutine(LoadLevel(2));
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
