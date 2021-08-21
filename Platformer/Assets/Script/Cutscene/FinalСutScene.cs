using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalСutScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

    [SerializeField] private int sceneIDmenu;

    private int _index;

    private void Start()
    {
        text.text = string.Empty;
        StartDialog();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == lines[_index])
            {
                IsNextLine();
            }
            else
            {
                StopCoroutine(TypeLine());
                text.text = lines[_index];
            }
        }
    }


    private void StartDialog()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var c in lines[_index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }



    private void IsNextLine()
    {
        if (_index < lines.Length - 1)
        {
            _index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            PlayerPrefs.SetInt("PointsPlayer", 0);  
            SceneManager.LoadScene(sceneIDmenu);
        }
    }
}
