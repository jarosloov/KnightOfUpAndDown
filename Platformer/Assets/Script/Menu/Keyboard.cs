using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] private Image up;
    [SerializeField] private Image down;
    [SerializeField] private Image right;
    [SerializeField] private Image left;
    
    [Header("Unpressed buttons")]
    [SerializeField] private Sprite buttonUp;
    [SerializeField] private Sprite buttonDown;
    [SerializeField] private Sprite buttonRight;
    [SerializeField] private Sprite buttonLeft;
   
    
    [Header("Pressing the button")]
    [SerializeField] private Sprite buttonUpClick;
    [SerializeField] private Sprite buttonDownClick;
    [SerializeField] private Sprite buttonRightClick;
    [SerializeField] private Sprite buttonLeftClick;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            up.sprite = buttonUpClick;
        else
            up.sprite = buttonUp;
        
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            down.sprite =  buttonDownClick;
        else
            down.sprite =  buttonDown;
    }
}
