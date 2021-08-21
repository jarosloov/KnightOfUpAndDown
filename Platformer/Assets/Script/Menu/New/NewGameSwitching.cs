using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameSwitching : MonoBehaviour
{
  [Header("Element")]
  [SerializeField] private TextMeshProUGUI [] menuButton;

  [Header("Color")]
  public Color noActiveColor;
  public Color activeColor;

  [Header("Window")]
  [SerializeField] private GameObject windowCutscene;
  [SerializeField] private GameObject windowExitGame;
  [SerializeField] private GameObject windowSettings;


  private string[] _nameButtons;  
  private int _position;
  

  private void Start()
  {
    _nameButtons = new string[menuButton.Length];
    for (var i = 0; i < menuButton.Length; i++)
      _nameButtons[i] = menuButton[i].text;
    _position = 0;
    PrintButton(_position);
  }
  
  private void Update()
  {
    if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _position != 0)
      PrintButton(IndexPosition(--_position));
    if ((Input.GetKeyDown(KeyCode.S)  || Input.GetKeyDown(KeyCode.DownArrow)) && _position != menuButton.Length - 1)
      PrintButton(IndexPosition(++_position));
    
    
    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
    {
      //Action
      switch (menuButton[_position].text)
      {
        case "~ New Game ~":
          ClickButtonNewGame();
          break;
        case "~ Settings ~":
          ClickButtonSettings();
          break;
        case "~ Exit ~":
          ClickButtonExitGame();
          break;
      }
    }
  }

  private void ClickButtonExitGame()
  {
    windowExitGame.SetActive(true);
  }

  private void ClickButtonSettings()
  {
    windowSettings.SetActive(true);
  }

  private void ClickButtonNewGame()
  {
    windowCutscene.SetActive(true);
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
