using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
  public GameObject menu;

  private bool isPaused = false;

  private void Start()
  {
    isPaused = false;
    menu.SetActive(isPaused);
  }


  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      SwitchState();
    }
  }

  public void SwitchState()
  {
    if (!isPaused)
    {
      isPaused = true;
      if (menu.activeSelf)
        menu.SetActive(isPaused);
      GameController.instance.SwitchState(GameController.GAME_STATES.PAUSE);
    }
    else if (isPaused)
    {
      isPaused = false;
      if (!menu.activeSelf)
        menu.SetActive(isPaused);
      GameController.instance.SwitchState(GameController.GAME_STATES.CONTINUE);
    }
  }

  public void QuitAndSave()
  {
    GameController.instance.SwitchState(GameController.GAME_STATES.SAVE_AND_QUIT);
  }
}
