using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    [SerializeField] private AudioSource soundMenu;
    private void Start()
    {
        soundMenu.volume = 0.5f;
    }
    private void Update()
    {
        soundMenu.volume = PlayerPrefs.GetFloat("SoundFon");
    }
}
