using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnamyPatrol : MonoBehaviour
{
    [Header("Enemy Characteristics")]
    [SerializeField] private float speed;
    [Space(10)]
    
    [Header("Patrol points")]
    [SerializeField] private Transform pointLeft, pointRight;
}
