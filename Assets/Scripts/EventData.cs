using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventData", menuName = "Investments/EventData", order = 0)]
public class EventData : ScriptableObject
{
  public string name = "No Name";
  [TextArea(10, 15)]
  public string description = "";
  public float amount = 0;
  public EventData nestedEvent;
}