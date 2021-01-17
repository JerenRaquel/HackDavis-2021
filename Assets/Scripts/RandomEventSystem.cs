using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ChanceAmount
{
  public float amount;
  public float chance;
}

public class EventReturnVal
{
  private float amount;
  private string msg;

  public EventReturnVal(float amount, string msg)
  {
    this.amount = amount;
    this.msg = msg;
  }

  public float Amount => this.amount;
  public string Message => this.msg;
}

public class RandomEventSystem : MonoBehaviour
{
  public EventData[] events;

  public EventReturnVal GetRandomEventAmount(EventData rngEvent = null, bool dive = false)
  {
    // Base case
    if (rngEvent == null && dive)
      return new EventReturnVal(0, "");

    // Check if event is played
    int chance = Random.Range(0, 1);
    if (chance == 0)
      return new EventReturnVal(0, "");

    // Get event
    EventData ree;
    if (rngEvent == null)
      ree = events[Random.Range(0, events.Length)];
    else
      ree = rngEvent;

    // Check for nested event
    if (ree != null)
    {
      EventReturnVal temp = GetRandomEventAmount(ree.nestedEvent);
      if (ree.nestedEvent != null)
        return new EventReturnVal(GetAmount(in ree.amounts) + temp.Amount, "-" + ree.description + "\n" + temp.Message);
      else
        return new EventReturnVal(GetAmount(in ree.amounts), "-" + ree.description);
      // return GetAmount(in ree.amounts) + GetRandomEventAmount(ree.nestedEvent).amount;
    }

    return new EventReturnVal(0, "");
  }

  private float GetAmount(in ChanceAmount[] amounts)
  {
    if (amounts.Length == 1)
      return amounts[0].amount;

    int rng = Random.Range(1, 101);
    float result = 0f;
    float maxChance = 0f;
    for (int i = 0; i < amounts.Length; i++)
    {
      if (amounts[i].chance >= maxChance && amounts[i].chance >= rng)
      {
        result = amounts[i].amount;
        maxChance = amounts[i].chance;
      }
    }
    return result;
  }
}
