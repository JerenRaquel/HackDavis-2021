<<<<<<< HEAD
public class SavingsAccount : Investment
{
  // the variables SavingAccount will use.
  private float[] interestRates;
  // to know when in time our interest rate should be.
  private int interestRateIndex;
=======
public class SavingsAccount : Investment
{
    // the variables SavingAccount will use.
    private float[] interestRates;
    // to know when in time our interest rate should be.
    private int interestRateIndex;
>>>>>>> 169b821cb4ae3557e82f2a0a2032c23efce3df34

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
    totalValue = totalValue + (1 + savingsRate);
    interestRateIndex++;
    this.rate = interestRates[interestRateIndex];
  }

}