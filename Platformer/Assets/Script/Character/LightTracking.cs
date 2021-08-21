using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTracking : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Animator player;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private CapsuleCollider2D colliderPlayer;

    [Header("Sound")] 
    [SerializeField] private AudioSource activatingСheckpoint;
    private AudioClip _clip;

    private void Start()
    {
        _clip = activatingСheckpoint.clip;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<LightWindow>())
        {
            StartCoroutine(DieLight());
        }
    }

    private IEnumerator DieLight()
    {
        activatingСheckpoint.PlayOneShot(_clip);
        player.Play("DeathByLight");
        yield return new WaitForSeconds(1);
        playerPosition.position = new Vector2(startPoint.position.x, 
            startPoint.position.y + colliderPlayer.size.y);
    }
}
