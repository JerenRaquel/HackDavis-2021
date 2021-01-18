using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Created a new object called CD
   Will be used in the main CerficatesOfDeposit class
   as a way to store each CD that the player determines to buy
*/
public class CD
{
    float value;
    float rate;
    int year;

    // each CD will have a principal value, an interest rate, and a maturation year
    public CD(float amount, float rate, int year)
    {
        this.value = amount;
        this.rate = rate;
        this.year = year;
    }

    public float Value { get { return this.value; } set { this.value = value; } }
    public float Rate { get { return this.rate; } set { this.rate = value; } }
    public int Year { get { return this.year; } set { this.year = value; } }
}

public class CertificatesOfDeposit : Investment
{

    public InvestmentModule investmentModule;

    public CheckingsAccount checkingsAccount;

    // List of imported interestRates
    float[] interestRates;
    // The constructor for the CertificatesOfDeposits feature,
    // Meant to be called at the beginning when the game starts
    // input: A float array of interest rates, and the current year
    CD cd;
    private void Start()
    {
        this.year = 0;
        this.rate = interestRates[year];
        cd = new CD(0, this.rate, this.year);
        investmentModule.Initailize("Certificates Of Deposits", 0, "Deposit", "Collect", Add_Pointer, Subtract_Pointer);
    }

    private void Add_Pointer(float userInputValue)
    {

        if (checkingsAccount.DisplayAmount() < userInputValue)
        {
            Deposit(checkingsAccount.DisplayAmount(), 10);
            checkingsAccount.Withdraw(checkingsAccount.DisplayAmount());
        }
        else
        {
            Deposit(userInputValue, 10);
            checkingsAccount.Withdraw(userInputValue);
        }

    }

    private void Subtract_Pointer(float userInputValue)
    {

        checkingsAccount.Withdraw(Collect());

    }
    // When the player chooses to buy a CD,
    // they will input an amount, click on the the different yearOption buttons, then click on buy.
    // That will use this Deposit().
    // Deposit() creates a new CD object which has the amount input, the yearOption, and the current year rate
    // and stores it.
    // Input: the amount the player wants to deposit, how many years the player wants till expiration
    public void Deposit(float amount, int yearOption)
    {
        if (cd.Year == 0)
        {
            cd.Value += amount;
            cd.Rate = interestRates[year];
            cd.Year = yearOption;
        }
        else
            return;

    }

    // This function is called when the user wants to collect their CDs.
    // They will click on the CD they want to collect from (Assuming all CDs are displayed as individual bottons or we can do a list)
    // The CD will be collected and depending on the year might result in a penalty.
    // input: the id of the CD collected
    // output: the total amount of money collected from that CD
    public float Collect()
    {

        // the error handling should not be needed

        //this is where the error will happen where you're trying to collect an id that does not exist
        //if (List_CDs.Count <= id)
        //{
        //  -1 placeholder. return error message
        //  return -1;
        //}

        // if the CD has not reached maturity, collecting it will result in a penalty amount
        float collect_value;
        if (cd.Year != 0)
            collect_value = Mathf.RoundToInt(.9f * (float)cd.Value);
        else
            collect_value = cd.Value;

        // resetting cd
        cd.Value = 0;
        cd.Rate = 0;
        cd.Year = 0;

        // remove the collected CD from the list of CDs stored
        return collect_value;
    }

    public float DisplayCDValue()
    {
        return cd.Value;
    }

    public float DisplayCDRate()
    {
        return cd.Rate;
    }

    public float DisplayExpYear()
    {
        return cd.Year;
    }

    // Called everytime the global timer refreshes with all the other functions
    public void Progression()
    {
        if (!(GameController.instance.IsGameActive))
            return;

        // update the year counter to match with system year
        this.year++;

        // if the CD is not matured, increase its value by one year with simple interest
        if (cd.Year != 0)
        {
            cd.Year--;
            cd.Value = Mathf.RoundToInt(cd.Value + cd.Value * cd.Rate);
        }
        // update the interest rate for new CDs yet to be built
        this.rate = interestRates[year];

        investmentModule.UpdateValue(DisplayCDValue());
    }

}