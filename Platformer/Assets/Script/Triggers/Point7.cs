using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point7 : MonoBehaviour
{
    private bool _checkPoint = false;
    [SerializeField] private Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovementCharacter>() != null)
        {
            animator.SetBool("OnCheck", _checkPoint);
            _checkPoint = other.GetComponent<MovementCharacter>();
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<MovementCharacter>() != null ) 
        {
            animator.SetBool("OnCheck", _checkPoint);
            _checkPoint = other.GetComponent<MovementCharacter>();
        }
    }
}
