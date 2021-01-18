using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventReportBox
{
  public bool active = false;
  public GameObject panel;
  public EventReportMenu menu;
  public TMPro.TMP_Text titleBox;
  public TMPro.TMP_Text descriptionBox;
}

public class ComponentAttacher : MonoBehaviour
{
  public ContainerBars.ProgressSystem yearProgressBar;
  public EventReportBox eventReportBox;
  public CheckingsAccount checkingsAccount;
  public SavingsAccount savingsAccount;

  void Start()
  {
    if (yearProgressBar != null)
      GameController.instance.yearProgressBar = yearProgressBar;
    if (eventReportBox != null && eventReportBox.active)
      GameController.instance.eventReportBox = eventReportBox;
    if (savingsAccount != null)
      GameController.instance.savingsAccount = savingsAccount;
    if (checkingsAccount != null)
      GameController.instance.checkingsAccount = checkingsAccount;
  }
}
