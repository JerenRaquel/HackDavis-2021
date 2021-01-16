public class SavingsAccount : Investment
{
  // the variables SavingAccount will use.
  private float[] interestRates;
  // to know when in time our interest rate should be.
  private int interestRateIndex;

  // constructor for SavingsAccount object.
  public SavingsAccount(float[] interestRates)
  {
    this.totalValue = 0;
    interestRateIndex = 0;
    this.rate = interestRates[interestRateIndex];
  }

  // Porgression should be called everytime the global game timer refreshes.
  public void Progression()
  {
    totalValue = totalValue + (1 + this.rate);
    interestRateIndex++;
    this.rate = interestRates[interestRateIndex];
  }

}