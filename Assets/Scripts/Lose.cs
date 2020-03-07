using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{

    public void OnTriggerEnter2D()
    {
        NewMethod();
    }

    private void NewMethod()
    {
        DefenderSpawner defenderSpawner = FindObjectOfType<DefenderSpawner>();
        if (defenderSpawner.GetLifes() > 1)
        {
            defenderSpawner.LoseLife();
        }
        else
        {
            FindObjectOfType<LevelController>().HandleLose();
            //LoadGameOver();
        }
    }


    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
