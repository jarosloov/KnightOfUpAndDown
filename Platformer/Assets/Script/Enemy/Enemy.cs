using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private new CapsuleCollider2D collider;
    [SerializeField] private bool bigBoss = false;
    [SerializeField] private ParticleSystem part;
    [SerializeField] private GameObject particleSystems;
    
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private GameObject key;
    
    [Header("Sound")] 
    [SerializeField] private AudioSource audioSource;
    private AudioClip _clip;

    [SerializeField] private SpriteRenderer spriteRenderer;
    
    public void TakeDamage(int damage)
    {
        //print(health);
        health -= damage;
    }

    private void Update()
    {
        if (health <= 0)
        {
            if(GetComponent<PatrolMan>() != null)
                GetComponent<PatrolMan>().activity = false;
            //audioSource.PlayOneShot(_clip);
            anim.Play("Death");
            collider.isTrigger = true;
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    
    public void OnDeath()
    {
        Destroy(gameObject);
        Instantiate(particleSystems, enemyTransform.position, Quaternion.identity);
        part.Play();
        if(bigBoss)
            Instantiate(key, enemyTransform.position, Quaternion.identity);
        
    }

    
}
