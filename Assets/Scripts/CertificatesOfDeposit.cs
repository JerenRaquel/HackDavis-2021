using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Created a new object called CD
   Will be used in the main CerficatesOfDeposit class
   as a way to store each CD that the player determines to buy
*/
public class CD
{
    int value;
    float rate;
    int year;

    // each CD will have a principal value, an interest rate, and a maturation year
    public CD(int amount, float rate, int year)
    {
        this.value = amount;
        this.rate = rate;
        this.year = year;
    }

    public int Value { get { return this.value; } set { this.value = value; } }
    public float Rate => this.rate;
    public int Year { get { return this.year; } set { this.year = value; } }
}

public class CertificatesOfDeposit : Investment
{
    // declares the list which holds all the CD objects
    List<CD> List_CDs;
    // List of imported interestRates
    float[] interestRates;
    // The constructor for the CertificatesOfDeposits feature,
    // Meant to be called at the beginning when the game starts
    // input: A float array of interest rates, and the current year
    public CertificatesOfDeposit(float[] interestRates, int year)
    {
        this.year = year;
        this.interestRates = interestRates;
        this.rate = interestRates[year];
        this.List_CDs = new List<CD>();
    }

    // When the player chooses to buy a CD,
    // they will input an amount, click on the the different yearOption buttons, then click on buy.
    // That will use this Deposit().
    // Deposit() creates a new CD object which has the amount input, the yearOption, and the current year rate
    // and stores it.
    // Input: the amount the player wants to deposit, how many years the player wants till expiration
    public void Deposit(int amount, int yearOption)
    {
        CD cd_item = new CD(amount, rate, yearOption);
        List_CDs.Add(cd_item);
    }

    // This function is called when the user wants to collect their CDs.
    // They will click on the CD they want to collect from (Assuming all CDs are displayed as individual bottons or we can do a list)
    // The CD will be collected and depending on the year might result in a penalty.
    // input: the id of the CD collected
    // output: the total amount of money collected from that CD
    public int Collect(int id)
    {

        // the error handling should not be needed

        //this is where the error will happen where you're trying to collect an id that does not exist
        //if (List_CDs.Count <= id)
        //{
        //  -1 placeholder. return error message
        //  return -1;
        //}

        // if the CD has not reached maturity, collecting it will result in a penalty amount
        int collect_value;
        if (List_CDs[id].Year != 0)
            collect_value = Mathf.RoundToInt(.9f * (float)List_CDs[id].Value);
        else
            collect_value = List_CDs[id].Value;

        // remove the collected CD from the list of CDs stored
        List_CDs.RemoveAt(id);
        return collect_value;
    }

    // DisplayCD() would return a string which displays all the important information of the CD
    // Can use DisplayCD() to get the data needed to put on the Collect buttons
    public string DisplayCD(int id)
    {
        string result = "$" + List_CDs[id].Value + "\nAPY Rate: " + List_CDs[id].Rate + "\nYears till Maturity: " + List_CDs[id].Year + " Years";
        return result;

    }

    // Called everytime the global timer refreshes with all the other functions
    public void Progression()
    {
        if (!(GameController.instance.IsGameActive))
            return;

        // update the year counter to match with system year
        this.year++;

        // update the value of each CD for one year
        foreach (CD cd in List_CDs)
        {
            // if the CD is not matured, increase its value by one year with simple interest
            if (cd.Year != 0)
            {
                cd.Year--;
                cd.Value = Mathf.RoundToInt(cd.Value + cd.Value * cd.Rate);
            }
        }
        // update the interest rate for new CDs yet to be built
        this.rate = interestRates[year];
    }

}