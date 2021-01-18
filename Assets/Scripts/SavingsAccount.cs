using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingsAccount : Investment
{
    public InvestmentModule investmentModule;

    // the variables SavingAccount will use.
    public float[] interestRates;

    private void Start()
    {
        this.totalValue = 0;
        this.year = 0;
        this.rate = interestRates[year];
    }

    // For Displaying purposes
    // Gets a string which represents the SavingsAccount Data
    public string DisplaySavings()
    {
        string result;
        result = "Amount: " + this.totalValue + "\nInterest rate: " + this.rate;
        return result;
    }

    public int DisplayAmount()
    {
        return this.totalValue;
    }

    public float DisplayRate()
    {
        return this.rate;
    }

    // Progression should be called everytime the global game timer refreshes.
    // increment year counter to math system year
    // do simple interest on the value in SavingsAccount
    // update the interest rate
    public void Progression()
    {
        if (!(GameController.instance.IsGameActive))
            return;

        totalValue = Mathf.RoundToInt(totalValue + totalValue * rate);
        year++;
        this.rate = interestRates[year];
    }

}