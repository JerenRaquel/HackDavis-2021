using UnityEngine;

public class Stock
{
  int value;
  int shares;
  int currentValue;

  public Stock(int currentValue)
  {
    this.value = 0;
    this.currentValue = currentValue;
  }

  public int Shares { get { return this.shares; } set { this.shares = value; } }
  public string Name { get; set; }
  public int CurrentValue { get { return this.currentValue; } set { this.currentValue = value; } }
}

public class Stocks : Investment
{
  StonkSystem ss = new StonkSystem();

  Stock[] List_Stonks = new Stock[4];

  public Stocks(int[] initialValues)
  {
    for (int i = 0; i < 4; i++)
    {
      List_Stonks[i] = new Stock(initialValues[i]);
    }
    List_Stonks[0].Name = "GOGA";
    List_Stonks[1].Name = "TUSLA";
    List_Stonks[2].Name = "UWUZON";
    List_Stonks[3].Name = "WCDONALDS";
  }

  public int MaxBuyNotification(int value, int id)
  {
    return Mathf.RoundToInt(value / List_Stonks[id].CurrentValue)
    }

  public void Buy(int shares, int id, int maxMoney)
  {
    if (shares * List_Stonks[id].CurrentValue > maxMoney)
    {
      shares = maxMoney / List_Stonks[id].CurrentValue;
    }
    List_Stonks[id].Shares += shares;
  }

  public void Sell(int shares, int id)
  {
    if (shares * List_Stonks[id].CurrentValue > maxMoney)
    {
      shares = maxMoney / List_Stonks[id].CurrentValue;
    }
    List_Stonks[id].Shares += shares;
  }
}


