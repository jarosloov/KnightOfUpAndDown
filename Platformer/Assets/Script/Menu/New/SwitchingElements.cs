using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SwitchingElements : MonoBehaviour
{
  /*
  [Header("Element")]
  [SerializeField] private TextMeshProUGUI [] menuButton;

  [Header("Color")]
  public Color noActiveColor;
  public Color activeColor;

  [Header("Window")]
  [SerializeField] private GameObject windowNewGame;
  [SerializeField] private GameObject windowSettings;
  [SerializeField] private GameObject windowExitGame;

  [SerializeField] private GameObject windowCutscene;
  [SerializeField] private GameObject windowTutorial;
/*
  private bool _isCutscene;
  private bool _isTutorial;

  private bool _isWindowCutscene;
  private bool _isWindowTutorial;
  
  private bool _isWindowSettings;
  
  private bool _isNewGame;
  
  private string[] _nameButtons;  
  private int _position;
  

  private void Start()
  {
    windowNewGame.SetActive(false);
    
    
    _nameButtons = new string[menuButton.Length];
    for (var i = 0; i < menuButton.Length; i++)
      _nameButtons[i] = menuButton[i].text;
    _position = 0;
    PrintButton(_position);
  }
  
  private void Update()
  {
    if ((Input.GetKeyDown(KeyCode.W) ||  Input.GetKeyDown(KeyCode.A) ||
         Input.GetKeyDown(KeyCode.UpArrow) || 
         Input.GetKeyDown(KeyCode.LeftArrow)) && _position != 0)
    {
      PrintButton(IndexPosition(--_position));
    }
    if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || 
         Input.GetKeyDown(KeyCode.DownArrow) || 
         Input.GetKeyDown(KeyCode.RightArrow) 
         ) && _position != menuButton.Length - 1)
    {
      PrintButton(IndexPosition(++_position));
    }
    
    Debug.Log(PlayerPrefs.GetInt("PointsPlayer"));
    
    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
    {
      //Action
      switch (menuButton[_position].text)
      {
        case "~ Continue ~":
          ClickButtonContinue();
          break;
        case "~ New Game ~":
          ClickButtonNewGame();
          break;
        case "~ Settings ~":
          ClickButtonSettings();
          break;
        case "~ Exit ~":
          ClickButtonExitGame();
          break;
        case "~ No ~":
          No();
          break;
        case "~ Yes ~":
          Yes();
          break;
      }
    }
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
  
  
  
  public void ClickButtonContinue()
  {
    SceneManager.LoadScene(1);
  }

  public  void ClickButtonNewGame()
  {
    print("ClickNewGame");
    if (PlayerPrefs.GetInt("PointsPlayer") != 0)
    {
      windowNewGame.SetActive(true);
      _isNewGame = true;
    }
    else
    {
      //SceneManager.LoadScene(1);
      //PlayerPrefs.SetInt("PointsPlayer", 0);  
      windowCutscene.SetActive(true);
      _isWindowCutscene = true;
    }
  }

  public void ClickButtonSettings()
  {
        
  }

  public void ClickButtonExitGame()
  {
    Application.Quit();
  }

  public void Yes()
  {
    if (_isWindowCutscene)
    {
      _isCutscene = true;
      _isWindowCutscene = false;
      windowTutorial.SetActive(true);
      _isWindowTutorial = true;
      return;
    }
    
    if (_isWindowTutorial)
    {
      _isTutorial = true;
      _isWindowTutorial = false;
      
      return;
    }

    if (_isNewGame)
    {
      _isNewGame = false;
      windowCutscene.SetActive(true);
      _isWindowCutscene = true;
      
    }
    
    
    //PlayerPrefs.SetInt("PointsPlayer", 0); 
    //SceneManager.LoadScene(1);
  }

  public void No()
  {
    if (_isWindowCutscene)
    {
      _isCutscene = false;
      _isWindowCutscene = false;
      windowTutorial.SetActive(true);
      _isWindowTutorial = true;
      return;
    }

    if (_isWindowTutorial)
    {
      _isTutorial = false;
      _isWindowTutorial = false;
      
      return;
    }

    if (_isNewGame)
    {
      windowNewGame.SetActive(false);
      _isNewGame = false;
    }
    
      
      
    windowNewGame.SetActive(false);
  }
  */
}
