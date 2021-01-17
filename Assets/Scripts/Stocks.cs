public class Stock
{
  int value;
  int currentValue;
  int id;

  public Stock(int currentValue, int id)
  {
    this.value = 0;
    this.currentValue = currentValue;
    this.id = id;
  }

  public int Value { get { return this.value; } set { this.value = value; } }
  public int Id => this.id;
  public int CurrentValue { get { return this.currentValue; } set { this.currentValue = value; } }
}

public class Stocks : Investment
{
  StonkSystem ss = new StonkSystem();

  Stock[] StonksArray = new Stock[4];

  public Stocks(int[] initialValues)
  {

  }

  public void Buy(int value)
  {

  }

  public void Sell(int value)
  {

  }
}


