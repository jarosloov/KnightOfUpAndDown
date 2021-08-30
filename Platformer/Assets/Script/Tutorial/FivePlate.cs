using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FivePlate : MonoBehaviour
{
    [SerializeField] private new GameObject gameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovementCharacter>())
        {
            gameObject.SetActive(true);
        }
    }
}
