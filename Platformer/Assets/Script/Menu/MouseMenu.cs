using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseMenu : MonoBehaviour
{
    [SerializeField] private Text nameButtons;
    private string _pastNameButton;

    public void Start()
    {
        _pastNameButton = nameButtons.text;
    }

    private void OnMouseEnter()
    {
        nameButtons.text = "~ " + _pastNameButton + " ~";
        print("OnMouseEnter");
    }

    private void OnMouseExit()
    {
        nameButtons.text = _pastNameButton;
    }
}
