
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lever : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] Sprite pressedLever;
    [SerializeField] SpriteRenderer lever;
    [SerializeField] private GameObject continuue;
    
    private bool _playItOnce;
    private bool _key;

    private void Start()
    {
        continuue.SetActive(false);
        _playItOnce = true;
    }

    private void Update()
    {
        _key = KeyCounter._nowKey >= 3;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<MovementCharacter>() != null)
        {
            if (_playItOnce && _key)
                StartCoroutine(Rychag());
        }

    }

    private IEnumerator Rychag()
    {
        _playItOnce = false;
        anim.Play("rychag");
        yield return new WaitForSeconds(0.5f);
        continuue.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
}
