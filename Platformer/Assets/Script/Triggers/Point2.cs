using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point2 : MonoBehaviour
{
    private bool _checkPoint = false;
    [SerializeField] private Animator _animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool("OnCheck", _checkPoint);
        _checkPoint = other.GetComponent<MovementCharacter>();
    }
}
