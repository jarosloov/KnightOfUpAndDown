using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _continue;
    [SerializeField] private GameObject _newGame;

    private void Start()
    {
        if (PlayerPrefs.GetInt("PointsPlayer") == 0)
        {
            _continue.SetActive(false);
            _newGame.SetActive(true);
        }
        else if(PlayerPrefs.GetInt("PointsPlayer") != 0)
        {
            _continue.SetActive(true);
            _newGame.SetActive(false);
        }
    }
    
}
