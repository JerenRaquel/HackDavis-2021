using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stock class for each individual stock, Each Stock object will have # of shares, current value of a stock, and its name.
public class Stock
{
  float shares;
  float currentValue;

  // input: the current price of the stock
  public Stock(float currentValue)
  {
    this.shares = 0;
    this.currentValue = currentValue;
  }

  public float Shares { get { return this.shares; } set { this.shares = value; } }
  public string Name { get; set; }
  public float PreviousValue { get; set; }
  public float CurrentValue { get { return this.currentValue; } set { this.currentValue = value; } }
}

// Stocks class
public class Stocks : Investment
{
  /* Order
  private void OnEnable() { // <---- on initialized

  }
  private void Awake() {

  }
  private void Start() {// <----- on live start

  }*/

  public InvestmentModule investmentModule;
  public CheckingsAccount checkingsAccount;

  // StonkSystem imported, has functions to get rate of change of a stock for progression
  StonkSystem ss = new StonkSystem();

  // Init of all the rateComponents for each individual company / stock
  public RateComponents rateComponents = new RateComponents(3f, 70f, 121f, 80f);
  //public RateComponents rateComponents1 = new RateComponents(7f, 70f, 44f, 80f);
  //public RateComponents rateComponents2 = new RateComponents(1f, 55f, 353f, 30f);
  //public RateComponents rateComponents3 = new RateComponents(3f, 50f, 143f, 35f);

  // list of all 4 stock rates used in calculation to represent different companies
  //RateComponents[] List_Rates = new RateComponents[4];

  //[SerializeField] private int[] initialValues = { 16, 22, 6, 18 };
  [SerializeField] private float initialValue;

  // list of all 4 stock companies
  //Stock[] List_Stonks = new Stock[4];
  Stock stock;

  string stock_name;
  private void Start()
  {
    // initialize all 4 stock objects and give them names
    //for (int i = 0; i < 4; i++)
    //{
    //    List_Stonks[i] = new Stock(initialValues[i]);
    //    List_Stonks[i].PreviousValue = List_Stonks[i].CurrentValue;
    //}
    stock = new Stock(initialValue);
    stock.CurrentValue = initialValue;
    stock.PreviousValue = stock.CurrentValue;

    // names
    stock.Name = stock_name;
    investmentModule.Initailize("Stock", 0, "Buy", "Sell", Add_Pointer, Subtract_Pointer);
  }

  private void Add_Pointer(float userInputValue)
  {

    if (MaxBuyNotification(checkingsAccount.DisplayAmount()) < userInputValue)
    {
      Buy(userInputValue, checkingsAccount.DisplayAmount());
      checkingsAccount.Withdraw(checkingsAccount.DisplayAmount());
    }
    else
    {
      Buy(userInputValue, checkingsAccount.DisplayAmount());
      checkingsAccount.Withdraw(userInputValue * stock.CurrentValue);
    }

  }

  private void Subtract_Pointer(float userInputValue)
  {
    if (userInputValue > stock.Shares)
    {
      checkingsAccount.Deposit(stock.Shares * stock.CurrentValue);
      Sell(stock.Shares);
    }
    else
    {
      Sell(userInputValue);
      checkingsAccount.Deposit(userInputValue * stock.CurrentValue);
    }
  }

  // input: total amount in checkings account, ID of that stock
  // output: max # of shares of that stock the player can buy
  // used by outside function to calculate the Max shares of that stock that can be bought; this is for display purposes
  public float MaxBuyNotification(float maxMoney)
  {
    return Mathf.RoundToInt(maxMoney / stock.CurrentValue);
  }

  // input: # of shares, ID of the stock, and total amount in checkings account
  // Buying a stock, occurs when the buy button is pressed on a specific stock, the id can be used to identify which stock
  // If the # of shares of stock inputed is more than what the player can get, then it would just buy all the stocks they get buy
  public void Buy(float shares, float maxMoney)
  {
    // checks if the total value of the shares demanded is more than the player can handle
    if (shares * stock.CurrentValue > maxMoney)
    {
      shares = maxMoney / stock.CurrentValue;
    }
    stock.Shares += shares;
  }

  // Returns the name of the stock of id
  public string GetName()
  {
    return stock.Name;
  }

  // input: # of shares, ID of the stock
  // output: Amount of money adding to Checkings
  // Selling a stock, occurs when the sell button is pressed on a specific stock, the id can be used to identify which stock
  // if the # of shares of stock inputed is more than what the player can sell. then it would just sell all of that stock they have
  public float Sell(float shares)
  {
    float result = 0;
    if (shares > stock.Shares)
    {
      result = stock.Shares * stock.CurrentValue;
      stock.Shares = 0;
    }
    else
    {
      result = shares * stock.CurrentValue;
      stock.Shares -= shares;
    }

    return result;
  }

  // Calculates the percentage Change of the stock of id
  // using previous value and current value
  public float PercentageChange()
  {
    return (stock.CurrentValue / stock.PreviousValue - 1) * 100f;
  }

  public float DisplayStockShares()
  {
    return stock.Shares;
  }

  public float DisplayStockCurrentValue()
  {
    return stock.CurrentValue;
  }

  /* This function indicates progression of one year for Stocks.   
     After each year, current price of shares from stock companies
     are subjected to change. This function, therefore, updates
     the value of the shares the user invested as well as current prices. 
  */
  // Functions from StonkSystem
  // public float GetRateAtYear(int year, in RateComponents components)
  // public float GetRateAsPercentageAtYear(int year, float prevYearValue,
  //              out float yearValue, in RateComponents components)
  public void Progression()
  {
    if (!(GameController.instance.IsGameActive))
      return;

    year++;

    // saves the CurrentValue to PreviousValue
    stock.PreviousValue = stock.CurrentValue;

    // Gets the rate for the current year
    // This rate will subject current price of stock to change
    stock.CurrentValue = ss.GetRateAtYear(year, rateComponents);
  }
}


