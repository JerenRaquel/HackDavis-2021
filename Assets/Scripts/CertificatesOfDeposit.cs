public class CertificatesOfDeposit : SavingsAccount {
    public CerificateOfDeposit(float[] interestRates)
  {
    this.totalValue = 0;
    interestRateIndex = 0;
    this.rate = interestRates[interestRateIndex];
  }
}