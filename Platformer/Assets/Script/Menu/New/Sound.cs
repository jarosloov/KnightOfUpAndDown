using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource soundMenu;
    private void Update()
    {
        soundMenu.volume = PlayerPrefs.GetFloat("Sound");
    }
}
