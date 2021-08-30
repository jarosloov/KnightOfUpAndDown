using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CharacterLanguage : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string[] lines;
    [SerializeField] private float textSpeed;

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
                //StopCoroutine(TypeLine());
                //text.text = lines[_index];
            }
        }
    }


    private void StartDialog()
    {
        _index = 0;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
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
            Destroy(gameObject);
        }
    }
    
}
