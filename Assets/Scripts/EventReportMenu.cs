using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReportMenu : MonoBehaviour
{
  public enum PAYMENT_TYPE
  {
    CHECKING = 0b00000001,
    SAVINGS = 0b00000010,
    RECIEVE = 0b00000100,
    BOTH = CHECKING | SAVINGS,
    ALL = BOTH | RECIEVE
  }

  public GameObject[] panels;
  public GameObject savings;
  public GameObject checking;
  public GameObject recieve;

  void Start()
  {
    SwitchPanels(false);
  }

  private void SwitchPanels(bool state)
  {
    for (int i = 0; i < panels.Length; i++)
      panels[i].SetActive(state);
  }

  private void ClosePanel()
  {
    if (!savings.activeSelf)
      savings.SetActive(true);
    if (!checking.activeSelf)
      checking.SetActive(true);
    if (!recieve.activeSelf)
      recieve.SetActive(true);

    SwitchPanels(false);
    GameController.instance.SwitchState(GameController.GAME_STATES.CONTINUE);
  }

  public void PayFromChecking()
  {
    GameController.instance.RemoveFromChecking();
    ClosePanel();
  }

  public void PayFromSavings()
  {
    GameController.instance.RemoveFromSavings();
    ClosePanel();
  }

  public void Quit()
  {
    GameController.instance.SwitchState(GameController.GAME_STATES.SAVE_AND_QUIT);
  }

  public void GetPayment()
  {
    GameController.instance.AddFunds();
    ClosePanel();
  }

  public void DisablePayment(PAYMENT_TYPE type)
  {
    switch (type)
    {
      case PAYMENT_TYPE.ALL:
        savings.SetActive(false);
        checking.SetActive(false);
        recieve.SetActive(false);
        break;
      case PAYMENT_TYPE.BOTH:
        savings.SetActive(false);
        checking.SetActive(false);
        break;
      case PAYMENT_TYPE.SAVINGS:
        savings.SetActive(false);
        break;
      case PAYMENT_TYPE.CHECKING:
        checking.SetActive(false);
        break;
      case PAYMENT_TYPE.RECIEVE:
        recieve.SetActive(false);
        break;
    }
  }
}
