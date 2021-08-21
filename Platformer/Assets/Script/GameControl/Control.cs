using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    [SerializeField] public bool cursorr;
    void Start()
    {
        Cursor.visible = true;
    }
    
}
