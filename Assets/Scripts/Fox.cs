using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    bool attack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;
        if (otherObject.GetComponent<Gravestone>())
        {
            Debug.Log(GetComponent<Animator>());
            GetComponent<Animator>().SetTrigger("jumpTrigger");

        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
