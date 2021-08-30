using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    private float _timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;

    [SerializeField] private Transform attackPose;
    [SerializeField] private float attackRange;

    [SerializeField] private LayerMask whatIsEnamy;

    [SerializeField] private int damage;

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

    public void OnAttack()
    {
        var enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, whatIsEnamy);
        foreach (var t in enemiesToDamage)
        {
            if (!t.GetComponent<Enemy>()) continue;
            t.GetComponent<Enemy>().TakeDamage(damage);
            blood.Play();
        }
        
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
}
