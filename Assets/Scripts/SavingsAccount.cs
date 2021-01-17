public class SavingsAccount : Investment
{
    // the variables SavingAccount will use.
    private float[] interestRates;


<<<<<<< HEAD
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
        totalValue = totalValue + totalValue * rate;
        year++;
        this.rate = interestRates[year];
    }
=======
  // Porgression should be called everytime the global game timer refreshes.
  public void Progression()
  {
    totalValue = totalValue + (1 + this.rate);
    interestRateIndex++;
    this.rate = interestRates[interestRateIndex];
  }
>>>>>>> b0883d4b1fad6ba006f3dd1356c4ff661a0c3f6f

}