using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  #region Class Instance
  public static GameController instance = null;
  private void CreateInstance()
  {
    if (instance == null)
      instance = this;
    else
      Destroy(this);
  }
  #endregion
  private void Awake() => CreateInstance();

  public enum GAME_STATES { NEW_YEAR, SAVE_AND_QUIT, PAUSE, CONTINUE }

  public StatTracker statTracker;
  public ContainerBars.ProgressSystem yearProgressBar;
  public RandomEventSystem randomEventSystem;
  public EventReportBox eventReportBox;

  private bool isPaused = false;
  private bool yearProcessing = false;
  private int year = 0;

  private void Update()
  {
    if (!yearProcessing)
    {
      yearProcessing = true;
      SwitchState(GAME_STATES.NEW_YEAR);
    }
  }

  public void SwitchState(GAME_STATES state)
  {
    switch (state)
    {
      case GAME_STATES.NEW_YEAR:
        yearProgressBar.Initialize(() =>
        {
          EventReturnVal result = randomEventSystem.GetRandomEvent();
          // Update assets base on result
          this.eventReportBox.titleBox.text = result.Title;
          this.eventReportBox.descriptionBox.text = result.Message;
          this.year++;
          this.yearProcessing = false;
        });
        break;
      case GAME_STATES.SAVE_AND_QUIT:
        this.isPaused = true;
        this.statTracker.WriteToJsonFile();
        Debug.Log("Quitting!");
        Application.Quit();
        break;
      case GAME_STATES.PAUSE:
        this.isPaused = true;
        break;
      case GAME_STATES.CONTINUE:
        this.isPaused = false;
        break;
    }
  }


  public bool IsGameActive => this.isPaused;
}
