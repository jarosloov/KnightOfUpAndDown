using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private int sceneID;
    [SerializeField] private Image bar;

    private void Start()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        var oper = SceneManager.LoadSceneAsync(sceneID);
        while (!oper.isDone)
        {
            yield return new WaitForSeconds(1);
            bar.fillAmount = oper.progress + 0.1f;
            yield return null;
        }
    }
    
}
