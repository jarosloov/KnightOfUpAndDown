using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondPlate : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovementCharacter>())
        {
            gameObject.SetActive(true);
        }
    }
}