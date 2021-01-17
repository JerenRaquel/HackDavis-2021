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
  private float owedMoney = 0f;

  private void Update()
  {
    if (!yearProcessing && !isPaused)
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
          if (result.Amount < 0)
            this.owedMoney = result.Amount;
          // Check if can pay
          this.eventReportBox.panel.SetActive(true);
          this.eventReportBox.titleBox.text = result.Title;
          this.eventReportBox.descriptionBox.text = result.Message;
          this.year++;
          this.yearProcessing = false;
          SwitchState(GAME_STATES.PAUSE);
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

  public void RemoveFromChecking()
  {
    owedMoney = 0f;
  }

  public void RemoveFromSavings()
  {
    owedMoney = 0f;
  }

  public bool CheckForAvailable(float amount, bool checkChecking = true)
  {
    if (checkChecking)
    {
      return true;
    }
    else
    {
      return true;
    }
  }

  public bool IsGameActive => this.isPaused;
}
