public class CheckingsAccount : Investment
{

<<<<<<< HEAD
    int income;
    int expense = 0;

    public CheckingsAccount(int income)
    {
        this.income = income;
    }

    // when output -1, it means that the CheckingAccount has no money and the player needs to reallocate money to pay.
    public int Withdraw(int amount)
    {
        if (this.totalValue < amount)
        {
            // pops to another function (not coded yet) which has to purpose to allow the user to divert other funds to solve this error.
            return -1;
        }
        this.totalValue -= amount;
        return 1;
=======
  int income;
  int expense = 0;

  public CheckingsAccount(int income)
  {
    this.income = income;
  }


  // when output -1, it means that the CheckingAccount has no money and the player needs to reallocate money to pay.
  public int RemoveFunds(int amount)
  {
    if (this.TotalFunds < amount)
    {
      //
      return -1;
    }
    this.totalValue -= amount;
    return 1;
  }
>>>>>>> b0883d4b1fad6ba006f3dd1356c4ff661a0c3f6f

    }

    // to be used by outside functions such as events
    public void addExpenses(int expenseAmount)
    {
        expense += expenseAmount;
    }

    // to be used by outside functions such as events and main
    public void subtractExpenses(int subtractAmount)
    {
        expense -= subtractAmount;
    }

    // to be used by outside functions such as Assets and Education
    public void addIncome(int incomeAmount)
    {
        income += incomeAmount;
    }

    public int Progression()
    {
        this.totalValue += income;

        // error checking for a game over
        if (totalValue < expense)
        {
            return -1;
        }
        totalValue -= expense;
        return 1;
    }


}