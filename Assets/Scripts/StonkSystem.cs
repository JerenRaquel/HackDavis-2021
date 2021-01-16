using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RateComponents
{
  public float baseRate = 5f;
  public float luckyPercentage = 50f;
  public float startingRate = 1f;
  public float fluxAmplitued = 50f;
}

public class StonkSystem : MonoBehaviour
{
  public float GetRateAtYear(int year, in RateComponents components)
  {
    float modifier = 1f * (components.luckyPercentage - Random.Range(0f, 25f));
    float y = components.baseRate * year + components.startingRate;
    float amp = components.fluxAmplitued + components.luckyPercentage;
    y = Mathf.Log(y, 2) * modifier;
    y += Random.Range(-amp, amp);
    y /= 10f;
    return y;
  }

  public float GetRateAsPercentageAtYear(int year, float prevYearValue, out float yearValue, in RateComponents components)
  {
    float value = GetRateAtYear(year, in components);
    float result = (value / prevYearValue - 1) * 10f;
    yearValue = value;
    return result;
  }

  // TEMP For debugging sake
  //   public bool isOn = false;
  //   private int year = 0;
  //   public RateComponents rateComponents;
  //   public TMPro.TMP_Text textbox;
  //   private float time;
  //   public float delay;
  //   private float prevYear = 1f;
  //   private void Update()
  //   {
  //     if (isOn && time <= Time.time)
  //     {
  //       time += delay;
  //       //   textbox.text = GetRateAtYear(year, in rateComponents).ToString("F2");
  //       float currentYear;
  //       float val = GetRateAsPercentageAtYear(year, prevYear, out currentYear, in rateComponents);
  //       textbox.text = val.ToString("F2");
  //       prevYear = currentYear;
  //       year++;
  //     }
  //   }
}
