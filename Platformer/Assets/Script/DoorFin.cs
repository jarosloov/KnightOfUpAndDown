using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorFin : MonoBehaviour
{
    [SerializeField] private int sceneID; 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovementCharacter>())
        {
            PlayerPrefs.SetInt("PointsPlayer", 0);
            SceneManager.LoadScene(sceneID);
        }
    }
}
