using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSwitching : MonoBehaviour
{
  [Header("Element")]
  [SerializeField] private TextMeshProUGUI [] menuButton;

  [Header("Color")]
  public Color noActiveColor;
  public Color activeColor;

  [Header("Window")]
  [SerializeField] private GameObject windowTutorial;

  [Header("SceneID")]
  [SerializeField] private int cutscene;
  [SerializeField] private int tutorial;
  [SerializeField] private int game;
  
  
  
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
    PlayerPrefs.SetInt("Tutorial", 0);
    GameController();
  }
  
  private void No()
  {
    PlayerPrefs.SetInt("Tutorial", 1);
    GameController();
  }

  private void GameController()
  {
    if (PlayerPrefs.GetInt("Cutscene") == 1 && PlayerPrefs.GetInt("Tutorial") == 1)
    {
      SceneManager.LoadScene(cutscene);
    }
    else if (PlayerPrefs.GetInt("Cutscene") != 1 && PlayerPrefs.GetInt("Tutorial") == 1)
    {
      SceneManager.LoadScene(tutorial);
    }
    else if (PlayerPrefs.GetInt("Cutscene") != 1 && PlayerPrefs.GetInt("Tutorial") != 1)
    {
      SceneManager.LoadScene(game);
    }
    else if (PlayerPrefs.GetInt("Cutscene") == 1 && PlayerPrefs.GetInt("Tutorial") != 1)
    {
      SceneManager.LoadScene(cutscene);
    }
    else
    {
      SceneManager.LoadScene(0);
      Debug.Log("Ошибка");
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
}
