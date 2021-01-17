using UnityEngine;

// Stock class for each individual stock, Each Stock object will have # of shares, current value of a stock, and its name.
public class Stock
{
    int shares;
    int currentValue;

    // input: the current price of the stock
    public Stock(int currentValue)
    {
        this.shares = 0;
        this.currentValue = currentValue;
    }

    public int Shares { get { return this.shares; } set { this.shares = value; } }
    public string Name { get; set; }
    public float PreviousValue { get; set; }
    public int CurrentValue { get { return this.currentValue; } set { this.currentValue = value; } }
}

// Stocks class
public class Stocks : Investment
{
    // StonkSystem imported, has functions to get rate of change of a stock for progression
    StonkSystem ss = new StonkSystem();
    public RateComponents rateComponents0 = new RateComponents(3f, 70f, 121f, 80f);
    public RateComponents rateComponents1 = new RateComponents(7f, 70f, 44f, 80f);
    public RateComponents rateComponents2 = new RateComponents(1f, 55f, 353f, 30f);
    public RateComponents rateComponents3 = new RateComponents(3f, 50f, 143f, 35f);

    // list of all 4 stock rates used in calculation to represent different companies
    RateComponents[] List_Rates = new RateComponents[4];


    // list of all 4 stock companies
    Stock[] List_Stonks = new Stock[4];

    // input: an int list of initializing values
    // Stocks constructor. Purpose is to create and initialize all 4 stock objects with respective names and starting values
    public Stocks(int[] initialValues)
    {
        // initialize all 4 stock objects and give them names
        for (int i = 0; i < 4; i++)
        {
            List_Stonks[i] = new Stock(initialValues[i]);
            List_Stonks[i].PreviousValue = List_Stonks[i].CurrentValue;
        }

        // names
        List_Stonks[0].Name = "GOGA";
        List_Stonks[1].Name = "TUSLA";
        List_Stonks[2].Name = "UWUZON";
        List_Stonks[3].Name = "WCDONALDS";

        // initializing all 4 rates with different values to represent their respective stock
        List_Rates[0] = rateComponents0;
        List_Rates[1] = rateComponents1;
        List_Rates[2] = rateComponents2;
        List_Rates[3] = rateComponents3;
    }

    // input: total amount in checkings account, ID of that stock
    // output: max # of shares of that stock the player can buy
    // used by outside function to calculate the Max shares of that stock that can be bought; this is for display purposes
    public int MaxBuyNotification(int maxMoney, int id)
    {
        return Mathf.RoundToInt(maxMoney / List_Stonks[id].CurrentValue);
    }

    // input: # of shares, ID of the stock, and total amount in checkings account
    // Buying a stock, occurs when the buy button is pressed on a specific stock, the id can be used to identify which stock
    // If the # of shares of stock inputed is more than what the player can get, then it would just buy all the stocks they get buy
    public void Buy(int shares, int id, int maxMoney)
    {
        // checks if the total value of the shares demanded is more than the player can handle
        if (shares * List_Stonks[id].CurrentValue > maxMoney)
        {
            shares = maxMoney / List_Stonks[id].CurrentValue;
        }
        List_Stonks[id].Shares += shares;
    }

    public string GetName(int id)
    {
        return List_Stonks[id].Name;
    }

    // input: # of shares, ID of the stock
    // output: Amount of money adding to Checkings
    // Selling a stock, occurs when the sell button is pressed on a specific stock, the id can be used to identify which stock
    // if the # of shares of stock inputed is more than what the player can sell. then it would just sell all of that stock they have
    public int Sell(int shares, int id)
    {
        int result = 0;
        if (shares > List_Stonks[id].Shares)
        {
            result = List_Stonks[id].Shares * List_Stonks[id].CurrentValue;
            List_Stonks[id].Shares = 0;
        }

        result = shares * List_Stonks[id].CurrentValue;
        List_Stonks[id].Shares -= shares;

        return result;
    }

    public float DisplayPercentageChange(int id)
    {
        return (List_Stonks[id].CurrentValue / List_Stonks[id].PreviousValue - 1) * 100f;
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
        // goes through all the stocks, saves their currentValue, then update their value using formula.
        for (int i = 0; i < 4; i++)
        {
            // saves the CurrentValue to PreviousValue
            List_Stonks[i].PreviousValue = List_Stonks[i].CurrentValue;

            // Gets the rate for the current year
            // This rate will subject current price of stock to change
            List_Stonks[i].CurrentValue = Mathf.RoundToInt(ss.GetRateAtYear(year, List_Rates[i]));
        }
        year++;
    }
}


