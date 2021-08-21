using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementCharacter : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    private Vector2 _movement;
    [SerializeField] private float _gravityScale;

    [SerializeField] private Animator _animator;
    private bool _faceRight = true;

    private bool _ground;

    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal"); 
        Walk();
        ReflectCharacter();
        Revolution();
        Attack();
        Flip();
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
    }

    private void Flip()
    {
        _animator.SetBool("ground",_ground);
        
    }
    
    private void Walk()
    {
        _rigidbody2D.velocity = new Vector2(_movement.x * _speed, _rigidbody2D.velocity.y);
        _animator.SetFloat("movement", Mathf.Abs(_movement.x));
    }

    private void Attack()
    { 
        _animator.SetBool("attack", Input.GetKeyDown(KeyCode.Mouse0));
    }
    
    
    private void Revolution()
    {
        _movement.y = Input.GetAxis("Vertical");
        if (_movement.y < 0)
        {
            _rigidbody2D.gravityScale = _gravityScale;
            transform.localScale = new Vector2(transform.localScale.x,1);
        }
        
        if (_movement.y > 0)
        {
            _rigidbody2D.gravityScale = -_gravityScale;
            transform.localScale = new Vector2(transform.localScale.x,-1);
        }
    }
    

    private void ReflectCharacter()
    {
        if((_movement.x > 0 && !_faceRight) || (_movement.x < 0 && _faceRight))
        {
            transform.localScale *= new Vector2(-1,1);
            _faceRight = !_faceRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Ground>() || other.GetComponent<Ground>() == null)
            _ground = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Ground>() || other.GetComponent<Ground>() != null)
            _ground = false;
  
    }
    
}
