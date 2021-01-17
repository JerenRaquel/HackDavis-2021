using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD
{
  int value;
  float rate;
  int year;

  public CD(int amount, float rate, int year)
  {
    this.value = amount;
    this.rate = rate;
    this.year = year;
  }

  public int Value { get { return this.value; } set { this.value = value; } }
  public float Rate => this.rate;
  public int Year { get { return this.year; } set { this.year = value; } }
}

public class CertificatesOfDeposit : Investment
{
  List<CD> List_CDs;
  float[] interestRates;

  public CertificatesOfDeposit(float[] interestRates, int year)
  {
    this.year = year;
    this.interestRates = interestRates;
    this.rate = interestRates[year];
    this.List_CDs = new List<CD>();
  }

  public void Deposit(int amount, int yearOption)
  {
    CD cd_item = new CD(amount, rate, yearOption);
    List_CDs.Add(cd_item);
  }

  public int Collect(int id)
  {

    // this is where the error will happen where you're trying to collect an id that does not exist
    if (List_CDs.Count <= id)
    {
      // -1 placeholder. return error message
      return -1;
    }

    // if the CD has not reached maturity, collecting it will result in a penalty amount
    int collect_value;
    if (List_CDs[id].Year != 0)
      collect_value = Mathf.RoundToInt(.9f * (float)List_CDs[id].Value);
    else
      collect_value = List_CDs[id].Value;

    List_CDs.RemoveAt(id);
    return collect_value;
  }

  public void Progression()
  {
    this.year++;
    foreach (CD cd in List_CDs)
    {
        if (year != 0)
        {
          cd.Year--;
          cd.Value = Mathf.RoundToInt(cd.Value + cd.Value * (1 + cd.Rate));
        }
      }
      this.rate = interestRates[year];
    }

}