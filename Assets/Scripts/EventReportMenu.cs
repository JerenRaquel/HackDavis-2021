using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventReportMenu : MonoBehaviour
{
  public enum PAYMENT_TYPE
  {
    CHECKING = 0b00000001,
    SAVINGS = 0b00000010,
    BOTH = CHECKING | SAVINGS
  }

  public GameObject panel;
  public GameObject savings;
  public GameObject checking;

  void Start()
  {
    panel.SetActive(false);
  }

  private void ClosePanel()
  {
    if (!savings.activeSelf)
      savings.SetActive(true);
    if (!checking.activeSelf)
      checking.SetActive(true);

    panel.SetActive(false);
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

  public void DisablePayment(PAYMENT_TYPE type)
  {
    switch (type)
    {
      case PAYMENT_TYPE.BOTH:
        savings.SetActive(true);
        checking.SetActive(true);
        break;
      case PAYMENT_TYPE.SAVINGS:
        savings.SetActive(true);
        break;
      case PAYMENT_TYPE.CHECKING:
        checking.SetActive(true);
        break;
    }
  }
}
