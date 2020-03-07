using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] int damage = 100;

    void Start()
    {
        
    }

    void Update()
    {
       transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Attacker attacker = other.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            attacker.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }

  
}
