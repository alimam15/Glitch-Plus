using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winText, loseText;
    float waitToLoad = 2;
 

    int numberAttacker = 0;
    bool levelTimerFinished = false;
    // Start is called before the first frame update

    private void Start()
    {
        loseText.SetActive(false);
        winText.SetActive(false);
    }

    public void AttackedSpawned()
    {
        numberAttacker++;
    }

    public void AttackerKilled()
    {
        numberAttacker--;
        if(numberAttacker<=0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winText.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<Level>().LoadNextScene();

    }

   

   public void HandleLose()
    {
        loseText.SetActive(true);
        Time.timeScale = 0;
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawn();
    }

    private void StopSpawn()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }


}
