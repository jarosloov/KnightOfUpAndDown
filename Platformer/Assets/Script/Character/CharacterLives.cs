using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterLives : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [Range(0,100)]
    [SerializeField] private int fullBar;
    public float live;
    
    
    [Header("Player")]
    [SerializeField] private Transform _player;
    [SerializeField] private CapsuleCollider2D _colliderPlayer;
    [Header("CheckPoint")] 
    [SerializeField] private Transform[] checkPoints;
    
    [SerializeField] private Animator player;
    
    [SerializeField] private int sceneID;
    
    [Header("Sound")] 
    [SerializeField] private AudioSource activatingСheckpoint;
    private AudioClip _clip;

    private bool _one = false;

    private void Start()
    {
        _clip = activatingСheckpoint.clip;
        live = fullBar;
    }

    
    public void TakeDamage(int damage)
    {
        live -= damage;
        //print(live + " TakeDamage");
    }

    private void Update()
    {
        hpBar.fillAmount = live / 100; 
        if (live <= 0)
        {
            _one = true;
            if(_one)
                StartCoroutine(DieLight());
        }
        //print(live / 100 + "LLLLL");
        
    }
    
    private IEnumerator DieLight()
    {
        live = 100; 
        _one = false;
        player.Play("DeathByLight");
        yield return new WaitForSeconds(0.40f);
        activatingСheckpoint.PlayOneShot(_clip);
        yield return new WaitForSeconds(0.25f);
        
        _player.position = new Vector2(checkPoints[PlayerPrefs.GetInt("PointsPlayer")].position.x, 
            checkPoints[PlayerPrefs.GetInt("PointsPlayer")].position.y + _colliderPlayer.size.y);
    }
    
}
