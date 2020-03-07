using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] float attackerSpeed = 1f;
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] int damage = 50;
    GameObject currentTarget;
    // Start is called before the first frame update

    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackedSpawned();
    }

    private void OnDestroy()
    {
       LevelController levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.AttackerKilled();
        }
    }


    void Update()
    {
        transform.Translate(Vector2.left * attackerSpeed * Time.deltaTime );
        UpdateAnimationState();
    }

    public void SetMovementSpeed(float speed)
    {
        attackerSpeed = speed;

    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("isAttacking", true);
        currentTarget = target;
       
    }

    public void StrikeDefender()
    {
        if (!currentTarget) { return; }
        Defender defender = currentTarget.GetComponent<Defender>();
        if(defender)
        {
            defender.DamageDefender(damage);
        }
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);

        }

    }

    public void DealDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            TriggerDeathVfx();
        }
    }

    private void TriggerDeathVfx()
    {
        if (!deathVFX) { return;}
        Vector2 pos = new Vector2(transform.position.x - 0.7f, transform.position.y - 0.3f);
        GameObject explosion = Instantiate(deathVFX, pos, Quaternion.identity);
        Destroy(explosion, 1f);
    }
}
