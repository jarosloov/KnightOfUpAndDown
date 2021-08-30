using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CheckPoint : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform _player;
    [SerializeField] private CapsuleCollider2D _colliderPlayer;
    
    [SerializeField] private Animator animator;
    private bool _die;

    [Header("Sound")] 
    [SerializeField] private AudioSource activatingСheckpoint;
    
    [Header("CheckPoint")] 
    [SerializeField] private Transform[] checkPoints;

    
    private AudioClip _clip;

    private void Start()
    {
        _clip = activatingСheckpoint.clip;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<SharpSpikes>() != null)
        {
            StartCoroutine(Die());
        }
    }
    
    IEnumerator Die()
    {
        if (GetComponent<CharacterLives>() != null)
            GetComponent<CharacterLives>().live = 100;
        activatingСheckpoint.PlayOneShot(_clip);
        animator.Play("Die");
        yield return new WaitForSeconds(0.25f);
        _player.position = new Vector2(checkPoints[PlayerPrefs.GetInt("PointsPlayer")].position.x, 
            checkPoints[PlayerPrefs.GetInt("PointsPlayer")].position.y + _colliderPlayer.size.y);
    }
    
}
