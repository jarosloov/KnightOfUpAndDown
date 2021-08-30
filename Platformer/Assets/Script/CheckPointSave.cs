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
        else if (PlayerPrefs.GetInt("PointsPlayer") == 3)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        else if (PlayerPrefs.GetInt("PointsPlayer") == 4)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        else if (PlayerPrefs.GetInt("PointsPlayer") == 5)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        else if (PlayerPrefs.GetInt("PointsPlayer") == 6)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        else if (PlayerPrefs.GetInt("PointsPlayer") == 7)
            transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
        if(PlayerPrefs.GetInt("PointsPlayer") != 0)
            newGame = false;
    }

    private void Update()
    {
        //print(PlayerPrefs.GetInt("PointsPlayer"));
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.SetInt("PointsPlayer", 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Point>() != null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 1);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point2>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 2);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point3>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 3);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point4>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 4);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point5>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 5);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point6>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 6);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point7>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 7);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<Point>() != null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 1);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point2>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 2);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point3>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 3);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point4>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 4);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point5>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 5);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point6>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 6);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        else if (other.GetComponent<Point7>()!= null)
        {
            PlayerPrefs.SetInt("PointsPlayer", 7);
            PlayerPrefs.SetFloat("xPosition", transform.position.x);
            PlayerPrefs.SetFloat("yPosition", transform.position.y);
        }
        
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("PointsPlayer", 0);
    }

}


