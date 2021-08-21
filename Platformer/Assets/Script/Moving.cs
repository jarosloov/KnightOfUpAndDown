using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _newLevel;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<MovementCharacter>() && other.GetComponent<MovementCharacter>() != null)
            _player.transform.position = _newLevel.transform.position;
    }
}
