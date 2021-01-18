using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RateComponents
{
  // The base rate at which the value grows
  public float baseRate = 5f;
  // The chance of growth
  public float luckyPercentage = 50f;
  // The starting value
  public float startingRate = 1f;
  // The range of flucuations
  public float fluxAmplitued = 50f;

  public RateComponents(float baseRate, float luckyPercentage, float startingRate, float fluxAmplitued)
  {
    this.baseRate = baseRate;
    this.luckyPercentage = luckyPercentage;
    this.startingRate = startingRate;
    this.fluxAmplitued = fluxAmplitued;
  }
}

public class StonkSystem : MonoBehaviour
{
  // @param int year: the year or time of the stonk value
  // @param in RateCompenents components: Look at the class
  // Get stock price at year
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

  // @param int year: the year or time of the stonk value
  // @param float prevYearValue: the value of the prevous year's rateValue
  // @param out float yearValue: the value of the current year
  // @param in RateCompenents components: Look at the class
  public float GetRateAsPercentageAtYear(int year, float prevYearValue, out float yearValue, in RateComponents components)
  {
    float value = GetRateAtYear(year, in components);
    float result = (value / prevYearValue - 1) * 10f;
    yearValue = value;
    return result;
  }

  // TEMP For debugging sake
  // public bool isOn = false;
  // private int year = 0;
  // public RateComponents rateComponents;
  // public TMPro.TMP_Text textbox;
  // private float time;
  // public float delay;
  // private float prevYear = 1f;
  // private void Update()
  // {
  //   if (isOn && time <= Time.time)
  //   {
  //     time += delay;
  //     //   textbox.text = GetRateAtYear(year, in rateComponents).ToString("F2");
  //     float currentYear;
  //     float val = GetRateAsPercentageAtYear(year, prevYear, out currentYear, in rateComponents);
  //     textbox.text = val.ToString("F2");
  //     prevYear = currentYear;
  //     year++;
  //   }
  // }
}
