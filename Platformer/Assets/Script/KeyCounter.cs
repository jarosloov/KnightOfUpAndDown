using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI key;
    [SerializeField] private int keyMax;

    [SerializeField] private GameObject infoBord;
    
    public static int _nowKey;
    private bool _timer;
    private void Start()
    {
        _nowKey = 0;
        _timer = true;
        infoBord.SetActive(false);
    }

    private void Update()
    {
        if (_nowKey >= keyMax)
        {
            key.text = "MAX"; 
            infoBord.SetActive(true);
        }
            
        else 
            key.text = _nowKey + "/" + keyMax;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Key>() != null)
        {
            StartCoroutine(CounterKeys());
        }
    }
    

    private IEnumerator CounterKeys()
    {
        if (_timer)
        {
            if(_nowKey < keyMax)
                _nowKey++;
            _timer = false;
        }
        yield return new WaitForSeconds(0.3f);
        _timer = true; 
    }
}
