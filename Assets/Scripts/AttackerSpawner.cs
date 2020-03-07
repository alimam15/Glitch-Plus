using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerPrefab;
    [SerializeField]float minSpawnDelay = 1f;
    [SerializeField] float maxSpwanDelay = 5f;

    bool spawn = true;

    // Start is called before the first frame update


    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(minSpawnDelay, maxSpwanDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int spawnIndex = UnityEngine.Random.Range(0, attackerPrefab.Length);
       Attacker newAttacker = Instantiate(attackerPrefab[spawnIndex], transform.position, transform.rotation) as Attacker;
        newAttacker.transform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
