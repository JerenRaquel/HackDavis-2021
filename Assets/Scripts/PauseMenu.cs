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
    // Turn it off
    if (isPaused)
    {
      isPaused = false;
      if (menu.activeSelf)
        menu.SetActive(false);
      GameController.instance.SwitchState(GameController.GAME_STATES.CONTINUE);
    }
    else if (!isPaused)
    {
      isPaused = true;
      if (!menu.activeSelf)
        menu.SetActive(true);
      GameController.instance.SwitchState(GameController.GAME_STATES.PAUSE);
    }
  }

  public void QuitAndSave()
  {
    GameController.instance.SwitchState(GameController.GAME_STATES.SAVE_AND_QUIT);
  }
}
