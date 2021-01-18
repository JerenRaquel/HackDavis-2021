using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvestmentModule : MonoBehaviour
{
  public delegate void Report(float amount);

  public TMPro.TMP_Text title;
  public TMPro.TMP_Text amount;
  public TMPro.TMP_Text addName;
  public TMPro.TMP_Text removeName;
  public TMPro.TMP_InputField inputField;

  private Report addFundsFunction;
  private Report removeFundsFunction;


  //   public class temp
  //   {
  //     public  InvestmentModule im;

  //     private void Start() {
  //         im.Initailize(string title, int startingValue, string addName, string removeName, foobar, (float amount) => {}));
  //     }  

  //     private void foobar(float valuethatwaspassedin) {

  //     }
  //   }

  /* Initalize(): 
   *    This needs to be called at the before interacting with this script. Not calling this will error out the script or 
   *    make it not responsive.
   *    @param string title: The name of the investment type.
   *    @param float startingValue: the starting value. Should be defualted to 0 in most cases.
   *    @param string addname: The name of the add funds to this investment button.
   *    @param string removeName: The name of the remove funds to this investment button.
   *    @param Report addFundsFunction: The function pointer to add funds to the investment
   *    @param Report removeFundsFunction: The funtion pointer to remove funds to the investment.
   */
  public void Initailize(string title, float startingValue, string addName, string removeName, Report addFundsFunction, Report removeFundsFunction)
  {
    this.title.text = title;
    this.amount.text = "Amount: " + startingValue.ToString();
    this.addName.text = addName;
    this.removeName.text = removeName;
    this.addFundsFunction = addFundsFunction;
    this.removeFundsFunction = removeFundsFunction;
  }

  // Don't use
  public void Add(string value)
  {
    float addedAmount;
    if (float.TryParse(value, out addedAmount) && addFundsFunction != null)
      this.addFundsFunction(addedAmount);
  }

  // Don't use
  public void Remove(string value)
  {
    float removedAmount;
    if (float.TryParse(value, out removedAmount) && removeFundsFunction != null)
      this.removeFundsFunction(removedAmount);
  }

  // Call to update the UI
  public void UpdateValue(float value)
  {
    this.amount.text = "Amount: " + value;
  }
}
