using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckingsAccount : Investment
{
    public InvestmentModule investmentModule;

    float income;
    float expense;

    public CheckingsAccount()
    {
        income = 10000;
        expense = 0;
        investmentModule.Initailize("Checking's", 0, "Deposit", "Withdraw", Add_Pointer, Subtract_Pointer);
    }

    public void Add_Pointer(float userInputValue)
    {
    }

    public void Subtract_Pointer(float userInputValue)
    {
    }


    // when output -1, it means that the CheckingAccount has no money and the player needs to reallocate money to pay.
    //public void Withdraw(float amount)
    //{
    //if (this.totalValue < amount)
    //{
    // pops to another function (not coded yet) which has to purpose to allow the user to divert other funds to solve this error.
    //    return -1;
    //}
    //   this.totalValue -= amount;
    //}

    // to be used by outside functions such as events
    public void AddExpenses(float expenseAmount)
    {
        expense += expenseAmount;
    }

    // to be used by outside functions such as events and main
    public void SubtractExpenses(float subtractAmount)
    {
        expense -= subtractAmount;
    }

    // to be used by outside functions such as Assets and Education
    public void AddIncome(float incomeAmount)
    {
        income += incomeAmount;
    }

    public float DisplayAmount()
    {
        return totalValue;
    }

    public void Progression()
    {
        if (!(GameController.instance.IsGameActive))
            return;

        this.totalValue += income;

        // error checking for a game over
        if (totalValue < expense)
        {
            // -1 placeholder for function to divert funds or game over.
            return;
        }
        totalValue -= expense;
    }


}