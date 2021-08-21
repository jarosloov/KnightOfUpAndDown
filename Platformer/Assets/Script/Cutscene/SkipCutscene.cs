using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField] private float sizeVideo;
    [SerializeField] private int sceneIDgame;
    [SerializeField] private int sceneIDTutorial;
    
    [Header("TextSkip")] 
    [SerializeField] private GameObject textSkip;
    private bool statisTextSkip;
    private void Start()
    {
        //StartCoroutine(CutsceneVideo());
        textSkip.SetActive(false);
        statisTextSkip = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Escape))
        {
            statisTextSkip = true;
            textSkip.SetActive(true);
        }
        

        if (statisTextSkip && Input.GetKeyDown(KeyCode.Return))
        {
            if(PlayerPrefs.GetInt("Tutorial") != 1)
                SceneManager.LoadScene(sceneIDgame);
            else
                SceneManager.LoadScene(sceneIDTutorial);
        } 
            
        
    }

    /*private IEnumerator CutsceneVideo()
    {
        yield return new WaitForSeconds(sizeVideo);
        if(PlayerPrefs.GetInt("Tutorial") != 1)
            SceneManager.LoadScene(sceneIDgame);
        else
            SceneManager.LoadScene(sceneIDTutorial);
    }*/
}
