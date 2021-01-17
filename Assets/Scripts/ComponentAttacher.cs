using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EventReportBox
{
  public GameObject panel;
  public EventReportMenu menu;
  public TMPro.TMP_Text titleBox;
  public TMPro.TMP_Text descriptionBox;
}

public class ComponentAttacher : MonoBehaviour
{
  public ContainerBars.ProgressSystem yearProgressBar;
  public EventReportBox eventReportBox;

  void Start()
  {
    if (yearProgressBar != null)
      GameController.instance.yearProgressBar = yearProgressBar;
    if (eventReportBox != null)
      GameController.instance.eventReportBox = eventReportBox;
  }
}
