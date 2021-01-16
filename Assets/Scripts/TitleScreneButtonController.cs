using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreneButtonController : MonoBehaviour
{
  public void Quit()
  {
    Debug.Log("Quitting");
    Application.Quit();
  }

  public void StartGame()
  {
    Debug.Log("Starting");
  }
}
