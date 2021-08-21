using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchingUIItems : MonoBehaviour
{
  [Header("Element")]
  [SerializeField] private Text[] menuButton;
  [SerializeField] private string[] _nameButtons;

  [Header("Color")]
  public Color _noActiveColor = Color.gray;
  public Color _activeColor = Color.green;

  [SerializeField] private GameObject _newGame;
  [SerializeField] private GameObject settings;

  private int _position;
  

  private void Start()
  {
    _position = 0;
    PrintButton(_position);
    _newGame.SetActive(false);
    settings.SetActive(false);
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
    
    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
    {
      //Action
      
      switch (menuButton[_position].text)
      {
        case "~ Продолжить ~":
          Continue();
          break;
        case "~ Новая игра ~":
          NewGame();
          break;
        case "~ Настройки ~":
          Settings();
          break;
        case "~ Выйти ~":
          Exit();
          break;
        case "~ Нет ~":
          Back();
          break;
        case "~ Да ~":
          YesNewGame();
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
    menuButton[previous].color = _noActiveColor;
    menuButton[next].color = _noActiveColor;
    
    menuButton[previous].text = _nameButtons[previous];
    menuButton[next].text = _nameButtons[next];
  }

  private void PrintActiveButton(int active)
  {
    menuButton[active].color = _activeColor;
    menuButton[active].text = "~ " + menuButton[active].text + " ~";
  }
  
  
  public void Continue()
  {
   
    SceneManager.LoadScene(1);
  }

  public void NewGame()
  {
    if (PlayerPrefs.GetInt("PointsPlayer") != 0)
    {
      _newGame.SetActive(true);
    }
    else
    {
      SceneManager.LoadScene(1);
      PlayerPrefs.SetInt("PointsPlayer", 0);  
    }
  }
  
  public void Settings()
  {
    settings.SetActive(true);
  }

  public void Exit()
  {
    Application.Quit(); 
    print("уходи!");
  }

  public void Back()
  {
    _newGame.SetActive(false);
    settings.SetActive(false);
  }

  public void YesNewGame()
  {
    PlayerPrefs.SetInt("PointsPlayer", 0); 
    SceneManager.LoadScene(1);
   
  }


}
