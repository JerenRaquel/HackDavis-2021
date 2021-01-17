using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investment : MonoBehaviour
{
    protected int totalValue = 0;
    protected float rate = 1f;

    protected int year = 0;

    public void Deposit(int amount)
    {
        this.totalValue += amount;
    }

    public void Withdraw(int amount)
    {
        this.totalValue -= amount;
        this.totalValue = this.totalValue < 0 ? 0 : this.totalValue;
    }

    public int TotalFunds => this.totalValue;

}
