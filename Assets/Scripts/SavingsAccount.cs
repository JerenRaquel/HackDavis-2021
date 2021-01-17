using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingsAccount : Investment
{
    // the variables SavingAccount will use.
    private float[] interestRates;

    // constructor for SavingsAccount object.
    public SavingsAccount(float[] interestRates, int year)
    {
        this.totalValue = 0;
        this.year = year;
        this.interestRates = interestRates;
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

    // Progression should be called everytime the global game timer refreshes.
    // increment year counter to math system year
    // do simple interest on the value in SavingsAccount
    // update the interest rate
    public void Progression()
    {
        totalValue = Mathf.RoundToInt(totalValue + totalValue * rate);
        year++;
        this.rate = interestRates[year];
    }

}