public class CD
{
    int value;
    int rate;
    int year;
}

public class CertificatesOfDeposit : Investment
{
    List<CD> List_CDs;
    float[] interestRates;

    public CertificatesOfDeposit(int year, float[] interestRates)
    {
        this.year = year;
        this.interestRates = interestRates;
        this.rate = interestRates[year];
        this.List_CDs = new List<CD>();
    }

    public void Deposit(int amount, int yearOption)
    {
        CD item = new CD(amount, rate, yearOption);
        List_CDs.add(item);
    }

    public int collect(int id)
    {
        // this is where the error will happen where you're trying to collect an id that does not exist
        if (List_CDs.size() <= id)
        {
            return -1;
        }

        // if the CD has not reached maturity, collecting it will result in a penalty amount
        int collect_value;
        if (List_CDs[id].year != 0)
            collect_value = .9 * List_CDs[id].value;
        else
            collect_value = List_CDs[id].value;

        List_CDs.RemoveAt(id);
        return collect_value;
    }

    public void Progression()
    {
        this.year++;
        foreach (CD cd in List_CDs)
        {
            if (year != 0)
            {
                cd.year--;
                cd.value = cd.value + cd.value * (1 + cd.rate);
            }
        }
        this.rate = interestRates[year];
    }

}