public static class SavingsAccount : Investment{
    // the variables SavingAccount will use.
    private float[] interestRates;
    // to know when in time our interest rate should be.
    private int interestRateIndex;

    // constructor for SavingsAccount object.
    public static SavingsAccount(float [] interestRates) {
        this.totalValue = 0;
        interestRateIndex = 0;
        this.rate = interestRate[interestRateIndex];
    }

    // Porgression should be called everytime the global game timer refreshes.
    public static void Progression() {
        totalValue = totalValue + (1 + savingsRate);
        interestRateIndex++;
        this.rate = interestRate[interestRateIndex];
    }

}