using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Animator player;
    [SerializeField] private Transform playerPosition;
    [SerializeField] private CapsuleCollider2D colliderPlayer;

    [SerializeField]
    private int sceneID;
    
    [Header("Sound")] 
    [SerializeField] private AudioSource activatingСheckpoint;
    private AudioClip _clip;

    private void Start()
    {
        _clip = activatingСheckpoint.clip;
    }

    private void Update()
    {
        if(GetComponent<CharacterLives>().live <= 0 && GetComponent<CharacterLives>() != null)
            StartCoroutine(DieLight());
    }

    private IEnumerator DieLight()
    {
        activatingСheckpoint.PlayOneShot(_clip);
        player.Play("DeathByLight");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneID);
    }
}
