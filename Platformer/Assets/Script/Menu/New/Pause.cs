using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pause;
    private bool _active = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _active = !_active;
            pause.SetActive(_active);
            Time.timeScale = _active ? 0f : 1f;
        }
    }
}
