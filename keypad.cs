using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class keypad : MonoBehaviour
{
    //buttons
    // Start is called before the first frame update
    public List<int> NumbersInKeypad= new List<int>();
    public int CreditsAdded;
    public Text keypadDisplay;
    public GameObject[] chips;
    void Start()
    {
        StartCoroutine(BlinkText());
    }

    // Update is called once per frame
    public void PushNumberKeypad(int newNumber) 
    {
        if(NumbersInKeypad.Count < 3) 
        {
            if (NumbersInKeypad.Count == 0) 
            {
                keypadDisplay.text = "";
            }
            keypadDisplay.text += newNumber.ToString();
            NumbersInKeypad.Add(newNumber);

        }
        if (NumbersInKeypad.Count >= 3) 
        {
            GetFoodItem(NumbersInKeypad[0] * 100 + NumbersInKeypad[1] * 10 + NumbersInKeypad[2] * 1);
            return;
        }
    }
    public void GetFoodItem(int keypadNumber) 
    {
        Debug.Log("Your Item is ["+ keypadNumber + "]");
        keypadDisplay.text = "GRABING\n"+ keypadNumber;
        //grab
        grabItem(keypadNumber);
        StartCoroutine(waitTime(1f, returnValue =>
        {
            ResetKeypad();
        }
        ));

        return;
    }

    public void grabItem(int padNumber) 
    {
        if (padNumber==205) //free item
        {
            chips[0].GetComponent<Animator>().SetBool("animate", true);
            chips[1].GetComponent<Animator>().SetBool("animate", true);
        }
    }
    public void ResetKeypad() 
    {
        Coroutine routine= StartCoroutine(waitTime(1.5f, returnValue =>
        {
            keypadDisplay.text = "Thank you for your order";
            StartCoroutine(waitTime(1f, returnValue2 =>
            {
                keypadDisplay.text = "INSERT\nNUMBER";
                NumbersInKeypad.Clear();
            }
        ));
        }
        ));
    }
    public void HardResetKeypad()
    {
        //StopAllCoroutines();
        StopCoroutine("waitTime");
        StopCoroutine("BlinkText");
        StartCoroutine(BlinkText());
        NumbersInKeypad.Clear();
        keypadDisplay.text = "INSERT\nNUMBER";
    }
    /*
    StartCoroutine(RegisterUser(user, returnValue =>
        {
        returnInt = returnValue;
    }
        ));
    */
    IEnumerator BlinkText()
    {
        while (true)
        {
            Debug.Log("blink");
            //keypadDisplay.enabled = false;
            float blinktime = Random.Range(0.5f, 3.0f);
            float intensity = Random.Range(0.5f, 1.0f);
            keypadDisplay.color = new Color(keypadDisplay.color.r, keypadDisplay.color.g, keypadDisplay.color.b, intensity); //RGBA is (0, 0, 0, 1)
            //yield on a new YieldInstruction that waits for 5 seconds.
            yield return new WaitForSeconds(blinktime);
            //After we have waited 5 seconds print the time again.
            //keypadDisplay.enabled = true;
            keypadDisplay.color = new Color(keypadDisplay.color.r, keypadDisplay.color.g, keypadDisplay.color.b, 1f);
            yield return new WaitForSeconds(blinktime);
        }
    }
    IEnumerator waitTime(float time, System.Action<int> callback = null)
    {
        yield return new WaitForSeconds(time);
        callback(1);
        //do something

    }
}
