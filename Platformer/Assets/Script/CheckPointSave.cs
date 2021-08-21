using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSave : MonoBehaviour
{
    [SerializeField] private GameObject _playerStartPoint;
    public static bool newGame;
    private void Start()
    {
        if (PlayerPrefs.GetInt("PointsPlayer") == 0)
        {
            transform.position = _playerStartPoint.transform.position;
            newGame = true;
        }
        else if (PlayerPrefs.GetInt("PointsPlayer") == 1)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        else if (PlayerPrefs.GetInt("PointsPlayer") == 2)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        if(PlayerPrefs.GetInt("PointsPlayer") != 0)
            newGame = false;
    }

    private void Update()
    {
        print(PlayerPrefs.GetInt("PointsPlayer"));
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.SetInt("PointsPlayer", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Point>())
        {
            PlayerPrefs.SetInt("PointsPlayer", 1);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        
        if (other.GetComponent<Point2>())
        {
            PlayerPrefs.SetInt("PointsPlayer", 2);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("PointsPlayer", 0);
    }

}


