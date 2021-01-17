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

    // Porgression should be called everytime the global game timer refreshes.
    public void Progression()
    {
        totalValue = Mathf.RoundToInt(totalValue + totalValue * rate);
        year++;
        this.rate = interestRates[year];
    }

}