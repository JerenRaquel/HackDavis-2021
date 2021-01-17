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
  private bool eventFound;
  private float amount;
  private string msg;
  private string title;

  public EventReturnVal(float amount, string msg, string title, bool eventState = true)
  {
    this.amount = amount;
    this.msg = msg;
    this.title = title;
    this.eventFound = eventState;
  }

  public float Amount => this.amount;
  public string Message => this.msg;
  public string Title => this.title;
  public bool EventFound => this.eventFound;
}

public class RandomEventSystem : MonoBehaviour
{
  public EventData[] events;

  public EventReturnVal GetRandomEvent(EventData rngEvent = null, bool recurse = false)
  {
    // Base case
    if (rngEvent == null && recurse)
      return new EventReturnVal(0, "", "", false);

    // Check if event is played
    int chance = Random.Range(0, 2);
    if (chance == 0)
      return new EventReturnVal(0, "", "", false);

    // Get event
    EventData ree;
    if (rngEvent == null)
      ree = events[Random.Range(0, events.Length)];
    else
      ree = rngEvent;

    // Check for nested event
    if (ree != null)
    {
      EventReturnVal temp = GetRandomEvent(ree.nestedEvent, true);
      if (ree.nestedEvent != null)
        return new EventReturnVal(GetAmount(in ree.amounts) + temp.Amount, "-" + ree.description + "\n" + temp.Message, ree.name);
      else
        return new EventReturnVal(GetAmount(in ree.amounts), "-" + ree.description, ree.name);
      // return GetAmount(in ree.amounts) + GetRandomEventAmount(ree.nestedEvent).amount;
    }

    return new EventReturnVal(0, "", "", false);
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
