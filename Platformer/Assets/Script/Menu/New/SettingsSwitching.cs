using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSwitching : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private TextMeshProUGUI[] menuButton;

    [Header("Color")]
    public Color noActiveColor;
    public Color activeColor;


    [Header("Audio")]
    [SerializeField] private AudioSource switchh;
    private AudioClip _clip;

    [Header("Slider")]
    [SerializeField] private Slider sliderFon;
    [SerializeField] private Slider sliderSound;
    [SerializeField] private TextMeshProUGUI valueFon;
    [SerializeField] private TextMeshProUGUI valueSound;
    [SerializeField] private float volumeStep;

    [Header("StatWindow")]
    [SerializeField] private GameObject _continue;
    [SerializeField] private GameObject _newGame;

    private string[] _nameButtons;  
    private int _position;

    private void Awake()
    {
        sliderFon.value = PlayerPrefs.GetFloat("SoundFon"); 
        valueFon.text = sliderFon.value + "%";

        sliderSound.value = PlayerPrefs.GetFloat("SoundSound");
        valueSound.text = sliderSound.value + "%";
    }

    private void Start()
    {
        
        _clip = switchh.clip;
        _nameButtons = new string[menuButton.Length];
        for (var i = 0; i < menuButton.Length; i++)
            _nameButtons[i] = menuButton[i].text;
        _position = 0;
        PrintButton(_position);
        
  }
  
    private void Switching()
    {
        if ((Input.GetKeyDown(KeyCode.W) ||Input.GetKeyDown(KeyCode.UpArrow)) && _position != 0)
        {
            PrintButton(IndexPosition(--_position));
            switchh.PlayOneShot(_clip);
        }
        if ((Input.GetKeyDown(KeyCode.S)  || Input.GetKeyDown(KeyCode.DownArrow)) && _position != menuButton.Length - 1)
        {
            PrintButton(IndexPosition(++_position));
            switchh.PlayOneShot(_clip);
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            //Action
            switch (menuButton[_position].text)
            {
                case "~ Назад ~":
                    Back();
                    break;
                   
                case "~ Управление ~":
                    Management();
                    break;
            }
        }
        print(sliderFon.value + " " + volumeStep / 100);
        if (_position == 0)
        {
            
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                print("123");
                if(sliderFon.value > 0)
                    sliderFon.value -= volumeStep / 100;
                PlayerPrefs.SetFloat("SoundFon", sliderFon.value);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if(sliderFon.value < 1)
                    sliderFon.value += volumeStep / 100;
                PlayerPrefs.SetFloat("SoundFon", sliderFon.value);
            }
        }

        if (_position == 1)
        {
            print("456");
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                print("456");
                if (sliderSound.value > 0)
                    sliderSound.value -= volumeStep / 100;
                PlayerPrefs.SetFloat("SoundSound", sliderSound.value);

            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (sliderSound.value < 1)
                    sliderSound.value += volumeStep / 100;
                PlayerPrefs.SetFloat("SoundSound", sliderSound.value);
            }
        }
    }

    private void Update()
    {
        Switching();
        Sound();    
        if(Input.GetKeyDown(KeyCode.Q))
            _newGame.SetActive(false);
        if(Input.GetKeyDown(KeyCode.E))
            _newGame.SetActive(true);
        if(Input.GetKeyDown(KeyCode.X))
            gameObject.SetActive(false);
    }

    private void Sound()
    {
        valueFon.text = Mathf.Round(sliderFon.value * 100) + "%";
        
        valueSound.text = Mathf.Round(sliderSound.value * 100) + "%";
        
    }



  private void Back()
  {
        if (PlayerPrefs.GetInt("PointsPlayer") == 0)
            _newGame.SetActive(true);
        if (PlayerPrefs.GetInt("PointsPlayer") != 0)
            _continue.SetActive(true);
        gameObject.SetActive(false);

  }
  
    private void Management()
    {

    }

  private int IndexPosition(int position)
  {
    if (position > menuButton.Length - 1)
      return 0;
    if (position < 0)
      return menuButton.Length - 1;
    return position;
  }

  private void PrintButton(int index)
  {
    PrintNoActiveButton(PreviousIndex(index), NextIndex(index));
    PrintActiveButton(index);
  }

  private int PreviousIndex(int index)
  {
    return (index - 1 < 0) ? menuButton.Length - 1 : index - 1;
  }

  private int NextIndex(int index)
  {
    return (index + 1 > menuButton.Length - 1) ? 0 : index + 1;
  }

  private void PrintNoActiveButton(int previous, int next)
  {
    menuButton[previous].color = noActiveColor;
    menuButton[next].color = noActiveColor;
    
    menuButton[previous].text = _nameButtons[previous];
    menuButton[next].text = _nameButtons[next];
  }

  private void PrintActiveButton(int active)  
  {
    menuButton[active].color = activeColor;
    menuButton[active].text = "~ " + menuButton[active].text + " ~";
  }
}
