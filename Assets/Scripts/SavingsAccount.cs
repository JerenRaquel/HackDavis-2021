using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingsAccount : Investment
{
    public InvestmentModule investmentModule;
    public CheckingsAccount checkingsAccount;

    // the variables SavingAccount will use.

    private void Start()
    {
        this.totalValue = 0;
        this.year = 0;
        this.rate = .14f;
        investmentModule.Initailize("Saving's Piggy", 0, "Deposit", "Withdraw", Add_Pointer, Subtract_Pointer);
    }
    public void Add_Pointer(float userInputValue)
    {
        if (checkingsAccount.DisplayAmount() < userInputValue)
        {
            Deposit(checkingsAccount.DisplayAmount());
            checkingsAccount.Withdraw(checkingsAccount.DisplayAmount());
        }
        else
        {
            Deposit(userInputValue);
            checkingsAccount.Withdraw(userInputValue);
        }
    }
    public void Subtract_Pointer(float userInputValue)
    {
        if (DisplayAmount() < userInputValue)
        {
            checkingsAccount.Deposit(DisplayAmount());
            Withdraw(DisplayAmount());
        }
        else
        {
            checkingsAccount.Deposit(userInputValue);
            Withdraw(userInputValue);
        }
    }

    // For Displaying purposes
    // Gets a string which represents the SavingsAccount Data

    public float DisplayAmount()
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

        totalValue = totalValue + totalValue * rate;
        year++;
        this.rate = this.rate - Random.Range(0f, 0.0018f);
        investmentModule.UpdateValue(DisplayAmount());
    }

}