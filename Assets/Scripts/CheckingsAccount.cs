public class CheckingsAccount : Investment
{

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
            // -1 placeholder for function to divert funds or game over.
            return -1;
        }
        totalValue -= expense;
        return 1;
    }


}