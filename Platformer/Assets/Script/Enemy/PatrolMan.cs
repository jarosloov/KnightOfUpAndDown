using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class PatrolMan : MonoBehaviour
{
    [SerializeField] private float speed; 
    [SerializeField] private float pointionOfPatrol;
    [SerializeField] private Transform point;
    [SerializeField] private SpriteRenderer enemy;

    [SerializeField] private Animator enemyAnimator;
    

    [SerializeField] private Transform player;
    [SerializeField] private float _stoppingDistance; // дистания остановке
    [SerializeField] private float _attackDistance;
    
    [Header("Attack")]
    
    [SerializeField] private Transform attackPose;
    [SerializeField] private float attackRange;

    [SerializeField] private LayerMask whatIsEnamy;

    [SerializeField] private int damage;
    
    private bool _moveingRight;
    private bool _chill = false;
    private bool _angry = false;
    private bool _goBack = false;
    private bool _attack = false;

    private float _time;
    [SerializeField] private float _timeAttack;

    public bool activity;
        
    
    
    private void Start()
    {
        speed = Random.Range(speed - 2, speed + 2);
        pointionOfPatrol = Random.Range(pointionOfPatrol - 1, pointionOfPatrol + 1);
        activity = true;
        if(gameObject.GetComponent<MovementCharacter>() != null)
            player = gameObject.GetComponent<MovementCharacter>().transform;
    }

    private void Activity()
    {
        Animations();
        if (Vector2.Distance(transform.position, player.transform.position) < _attackDistance && _angry)
        {
            _chill = _goBack = false;
            //print("Attack");
            _attack = true;
            Attack();
        }
        
        if (Vector2.Distance(transform.position, point.position) < pointionOfPatrol && _angry == false)
        {
            _chill = true;
            _goBack = false;
        }

        if (Vector2.Distance(transform.position, player.transform.position) < _stoppingDistance)
        {
            _angry = true;
            _goBack = false;
            _chill = false;
        }
        
        if (Vector2.Distance(transform.position, player.transform.position) > _stoppingDistance)
        {
            _goBack = true;
            _angry = false;

        }
        
        if(_chill == true)
            Chill();
        else if(_angry == true)
            Angry();
        else if (_goBack == true)
            GoBack();
        else if (_attack == true)
        {
            Attack();
            print("Attack");
        }
    }
    
    
    
    private void Update()
    {
        if(activity)
            Activity();
    }

    private void Animations()
    {
        enemyAnimator.SetBool("run", (_goBack || _angry ||_angry));
        enemyAnimator.SetBool("attack", Vector2.Distance(transform.position, player.transform.position) < _attackDistance && _angry);
        
       
        //_enemyAnimator.SetBool("attack", Vector2.Distance(transform.position, _player.transform.position) < _attackDistance && _angry);
    }
    

    private void Attack()
    {
        _time += Time.deltaTime;
        if (_time >= _timeAttack)
        {
            //print("Удар");
            _time = 0;
        }
    }
    /*
    public void OnAttack()
    {
        var enemiesToDamage = Physics2D.OverlapCircleAll(attackPose.position, attackRange, whatIsEnamy);
        foreach (var t in enemiesToDamage)
        {
            if(t.GetComponent<CharacterLives>())
                t.GetComponent<CharacterLives>().TakeDamage(damage);
        }
        print("Anim");
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPose.position, attackRange);
    }
    */
    private void Chill()
    {
        if (transform.position.x > point.position.x + pointionOfPatrol)
        {
            _moveingRight = false;
        }
        else if (transform.position.x < point.position.x - pointionOfPatrol)
        {
            _moveingRight = true;
        }
        if (_moveingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime,
                transform.position.y);
            transform.localScale = new Vector2(1,transform.localScale.y);
        }
        
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime,
                transform.position.y);
            transform.localScale = new Vector2(-1,transform.localScale.y);
        }
    }

    private void Angry()
    {
        transform.position = Vector2.MoveTowards(transform.position, 
            player.position, speed * Time.deltaTime);
        
        if (transform.position.x > player.position.x )
        {
            _moveingRight = false;
        }
        else if (transform.position.x < player.position.x )
        {
            _moveingRight = true;
        }

        if (_moveingRight)
        {
            transform.localScale = new Vector2(1,transform.localScale.y);
            // _enemy.flipX = felse;
        }
        else
        {
           // _enemy.flipX = true;
           transform.localScale = new Vector2(-1,transform.localScale.y);
        }
    }

    private void GoBack()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, 
            point.position, speed * Time.deltaTime);
        
        if (transform.position.x > point.position.x + pointionOfPatrol)
        {
            _moveingRight = false;
        }
        else if (transform.position.x < point.position.x - pointionOfPatrol)
        {
            _moveingRight = true;
        }

        if (_moveingRight)
        {
            transform.localScale = new Vector2(1,transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-1,transform.localScale.y);
        }
    }
    
    
}
