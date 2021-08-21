using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindowNewGameSwitching : MonoBehaviour
{
  [Header("Element")]
  [SerializeField] private TextMeshProUGUI [] menuButton;

  [Header("Color")]
  public Color noActiveColor;
  public Color activeColor;

  [Header("Window")]
  [SerializeField] private GameObject windowNewGame;
  [SerializeField] private GameObject windowCutscene;
  
  
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
    if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && _position != 0)
      PrintButton(IndexPosition(--_position));
    if (( Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && _position != menuButton.Length - 1)
      PrintButton(IndexPosition(++_position));

    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
    {
      //Action
      switch (menuButton[_position].text)
      {
        case "~ No ~":
          No();
          break;
        case "~ Yes ~":
          Yes();
          break;
      }
    }
  }

  
  private void Yes()
  {
    windowCutscene.SetActive(true);
    windowNewGame.SetActive(false);
    PlayerPrefs.SetInt("PointsPlayer", 0);  
  }
  
  private void No()
  {
    windowNewGame.SetActive(false);
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
