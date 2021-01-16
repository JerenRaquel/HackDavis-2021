public class CheckingsAccount : Investment {
    
    int income = 0;
    int expense = 0;

    public int RemoveFunds(int amount) {
        if (this.TotalFunds < amount) {
            return -1;
        }
        this.TotalFunds -= amount;
    }

    public void addExpenses(int expenseAmount) {
        expense += expenseAmount;
    }

    public void subtractExpenses(int subtractAmount) {
        expense -= subtractAmount;
    }

    public void addIncome(int incomeAmount) {
        income += incomeAmount;
    }

    public int Progression() {
        this.TotalFunds += income;

        // error checking for a game over
        if (TotalFunds < expense) {
            return -1;
        }
        TotalFunds -= expense;
        return 1;
    }


}