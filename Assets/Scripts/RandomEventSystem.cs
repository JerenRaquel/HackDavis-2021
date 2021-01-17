using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RandomEvent
{

}

public class RandomEventSystem : MonoBehaviour
{
  public EventData[] events;

  public float GetRandomEventAmount(EventData rngEvent = null)
  {
    // Check if event is played
    int chance = Random.Range(0, 1);
    if (chance == 0)
      return 0;

    // Get event
    EventData ree;
    if (rngEvent == null)
      ree = events[Random.Range(0, events.Length)];
    else
      ree = rngEvent;

    // Check for nested event
    if (ree != null)
      return ree.amount + GetRandomEventAmount(ree.nestedEvent);

    return 0;
  }
}
