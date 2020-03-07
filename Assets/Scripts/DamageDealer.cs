using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int damage;
   // [SerializeField] int health;
    void Start()
    {
        
    }

   
  
    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDamage()
    {
        return damage;
    }

}
