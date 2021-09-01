using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnamyPatrol : MonoBehaviour
{
    [Header("Enemy Characteristics")]
    [SerializeField] private float speed;
    [SerializeField] private float sleepTime;
    private float _time;
    private bool _stop;
    [Space(10)] [SerializeField] private float distance;
    [Header("Patrol points")]
    [SerializeField] private Transform pointLeft;
    [SerializeField] private Transform pointRight;


    
    private void Start()
    {
        
    }

    private bool _moveRight;
    private void Update()
    {
        var check = Physics2D.Raycast(transform.position, Vector2.left, distance);
        
        
        
        if (transform.position.x > pointRight.position.x)
        {
            _stop = true;
            _moveRight = false;
            StartCoroutine(StopPosition(false));
                
        }
        else if (transform.position.x < pointLeft.position.x)
        {
            _stop = true;
            _moveRight = true;
            StartCoroutine(StopPosition(true));
        }
        print(_stop);

        if (!_stop)
        {
            if (_moveRight)
            {
                print("+");
                transform.position = new Vector2(transform.position.x + speed * Time.deltaTime , transform.position.y);
                    
            }
            else
            {
                transform.position = new Vector2(transform.position.x - speed * Time.deltaTime , transform.position.y);
                print("-");
            }
        }
        
            
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawRay(transform.position, attackRange);
    }

    private IEnumerator StopPosition(bool right)
    {
        
       
        yield return new WaitForSeconds(sleepTime);
        print("+++");
        _stop = false;
    }
}
