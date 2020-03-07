using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;

    float projectileSpeed = 1f;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

   
    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking",true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

   

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
        Debug.Log(spawners);
        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough =(Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            Debug.Log(isCloseEnough);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
                Debug.Log(spawner);
                Debug.Log(myLaneSpawner);
            }

        }

    }


    private bool IsAttackerInLane()
    {

        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }



}
