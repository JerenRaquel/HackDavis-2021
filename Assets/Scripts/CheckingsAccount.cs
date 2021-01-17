using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckingsAccount : Investment
{
    int income;
    int expense;

    private void Start()
    {
        this.income = 10000;
        this.expense = 0;
    }

    // when output -1, it means that the CheckingAccount has no money and the player needs to reallocate money to pay.
    public void Withdraw(int amount)
    {
        //if (this.totalValue < amount)
        //{
        // pops to another function (not coded yet) which has to purpose to allow the user to divert other funds to solve this error.
        //    return -1;
        //}
        this.totalValue -= amount;
    }

    // to be used by outside functions such as events
    public void AddExpenses(int expenseAmount)
    {
        expense += expenseAmount;
    }

    // to be used by outside functions such as events and main
    public void SubtractExpenses(int subtractAmount)
    {
        expense -= subtractAmount;
    }

    // to be used by outside functions such as Assets and Education
    public void AddIncome(int incomeAmount)
    {
        income += incomeAmount;
    }

    public int GetValue()
    {
        return this.totalValue;
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