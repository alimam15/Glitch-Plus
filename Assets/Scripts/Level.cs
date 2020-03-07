using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 3f;
    int currentSceneIndex;

    public void Start()
    {
        Debug.Log("Start scene index: " + currentSceneIndex);

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            LoadStartScene();
        } 
    }


    public void LoadNextScene()
    {
        Debug.Log("Next scence index" + currentSceneIndex);

        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void ReloadScence()
    {
        Debug.Log("Current scence index"+ currentSceneIndex);
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);

    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsScreen()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Options");
    }


    public void LoadStartScene()
    {
        StartCoroutine(WaitAndLoad());
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        //SceneManager.LoadScene("Start Screen");
        LoadNextScene();


    }

    public void LoadSplashScene()
    {
        SceneManager.LoadScene("Splash Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
