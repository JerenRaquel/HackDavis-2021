public static class SavingsAccount : Investment{
    // the variables SavingAccount will use.
    private int savingsAmount = 0;
    private float savingsRate = 0;
    private float[] interestRates;
    // to know when in time our interest rate should be.
    private int interestRateIndex;

    // constructor for SavingsAccount object.
    public static SavingsAccount(float [] interestRates) {
        this.savingsAmount = 0;
        interestRateIndex = 0;
        this.savingsRate = interestRate[interestRateIndex];
    }

    // Porgression should be called everytime the global game timer refreshes.
    public static void Progression() {
        savingsAmount = savingsAmount + (1 + savingsRate);
        interestRateIndex++;
    }

    // to get the value of the amount in the savings account.
    public static int getAmount() {
        return savingsAmount;
    }

    // to deposit money into the savings account.
    public static void deposit(int amount) {
        savingsAmount += amount;
    }

    // to withdraw money from the savings account.
    public static int withdraw(int amount) {
        // this is an error when the user inputs an amount larger than what they have in the savings account
        if (amount > savingsAmount) {
            return -1;
        }
        savingsAmount -= amount;
        return amount;
    }


}