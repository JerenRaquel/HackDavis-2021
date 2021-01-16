using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investment : MonoBehaviour
{
  private float totalValue = 0;
  private float rate = 1f;

  public void AddFunds(float amount)
  {
    this.totalValue += amount;
  }

  public void RemoveFunds(float amount)
  {
    this.totalValue -= amount;
    this.totalValue = this.totalValue < 0 ? 0 : this.totalValue;
  }

  public float TotalFunds => this.totalValue;
}
