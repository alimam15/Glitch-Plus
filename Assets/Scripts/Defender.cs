using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 10;
    [SerializeField] int generateStars = 5;
    [SerializeField] int health = 100;

    public int GetHealth()
    {
        return health;
    }

    public void DamageDefender(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }


    public int GetStarCost()
    {
        return starCost;
    }

    public void GenerateStars(int amount)
    {
        FindObjectOfType<DefenderSpawner>().AddStars(generateStars);
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
