using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float _timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;

    [SerializeField] private Transform attackPose;
    [SerializeField] private float attackRange;

    [SerializeField] private LayerMask whatIsEnamy;

    [SerializeField] private int damage = 15;

    [SerializeField] private ParticleSystem blood;
    
    private void Update()
    {
        if (_timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("+=+");
                
            }
            _timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            _timeBtwAttack -= Time.deltaTime;
        }
    }

    public void OnAttackkk()
    {
        var enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, whatIsEnamy);
        foreach (var t in enemiesToDamage)
        {
            if (t.GetComponent<CharacterLives>())
            {
                t.GetComponent<CharacterLives>().TakeDamage(damage);
                blood.Play();
            }
               
        }
        print("AnimEnemy   " + damage);
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
}
