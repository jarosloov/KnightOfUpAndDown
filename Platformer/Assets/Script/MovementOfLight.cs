using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOfLight : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform min, max;
    [SerializeField] private bool moveRight = true;

    private void Update()
    {
        if (transform.position.y > max.position.y)
        {
            moveRight = false;
            //print(moveRight + "  " + transform.position.y + "  " + max.position.y);
        }
            
        if(transform.position.y < min.position.y)
            moveRight = true;
        if (moveRight)
            transform.position = new Vector2(transform.position.x , transform.position.y+ speed * Time.deltaTime);
        else
            transform.position = new Vector2(transform.position.x , transform.position.y- speed * Time.deltaTime);
    }
    
}
