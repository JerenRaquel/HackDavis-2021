using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investment : MonoBehaviour
{
    protected float totalValue = 0;
    protected float rate = 1f;

    protected int year = 0;

    public void Deposit(float amount)
    {
        this.totalValue += amount;
    }

    public void Withdraw(float amount)
    {
        this.totalValue -= amount;
        this.totalValue = this.totalValue < 0 ? 0 : this.totalValue;
    }

    public float TotalFunds => this.totalValue;

}
