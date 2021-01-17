using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTracker : MonoBehaviour
{
  [System.Serializable]
  private class DateTime
  {
    public int month;
    public int day;
    public int hour;
    public int minute;
    public int seconds;
    public DateTime(int month, int day, int hour, int min, int sec)
    {
      this.month = month;
      this.day = day;
      this.hour = hour;
      this.minute = min;
      this.seconds = sec;
    }

    public string ConvertToString()
    {
      return month.ToString() + "_" + day.ToString() + " " + hour.ToString() + "_" + minute.ToString() + "_" + seconds.ToString();
    }

  }

  [System.Serializable]
  private class SaveFile
  {
    public string playerName;
    public float totalAssets;
    public int currentYear;
    [SerializeField]
    public DateTime dateTime;
    // public int month;
    // public int day;
    // public int hour;
    // public int minute;
    // public int seconds;

    public SaveFile(string name, float totalAssets, int currentYear, in DateTime dt)
    {
      this.playerName = name;
      this.totalAssets = totalAssets;
      this.currentYear = currentYear;
      this.dateTime = dt;
      //   this.month = dt.month;
      //   this.day = dt.day;
      //   this.hour = dt.hour;
      //   this.minute = dt.minute;
      //   this.seconds = dt.seconds;
    }
  }

  public string playerName = "RawShed";
  public float totalAssets = 420f;
  public int currentYear = 69;


  // TEMP for debug/manual
  public bool save = false;
  private void Update()
  {
    if (save)
    {
      save = false;
      WriteToJsonFile();
    }
  }

  // @param float totalAssets: The total amount of money in checking and savings
  // @param int currentYear: the currentYear
  public void UpdateData(float totalAssets, int currentYear)
  {
    this.totalAssets = totalAssets;
    this.currentYear = currentYear;
  }

  public void WriteToJsonFile()
  {
    int month = System.DateTime.Now.Month;
    int day = System.DateTime.Now.Day;
    int hour = System.DateTime.Now.Hour;
    int minute = System.DateTime.Now.Minute;
    int seconds = System.DateTime.Now.Second;

    DateTime dt = new DateTime(month, day, hour, minute, seconds);
    string fileName = this.playerName + "_" + dt.ConvertToString();

    SaveFile save = new SaveFile(fileName, totalAssets, currentYear, dt);

    // Debug.Log(fileName);

    string savefile = JsonUtility.ToJson(save);
    System.IO.File.WriteAllText(Application.persistentDataPath + "/" + fileName + ".json", savefile);
  }
}
