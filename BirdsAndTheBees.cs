using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BirdsAndTheBees : MonoBehaviour
{
    public int beesNeeded;
    public int beesCount = 0;
    public bool AllInteractionsAreDone;

    public Sprite AchievmentImage;
    public string AchievmentText;
    public string AchievementName = "BIRDS_AND_THE_BEES";


    public Text Countdown;
    private void Start()
    {
        Countdown.text = "";
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DragInteractable" && other.name.Contains("Bee"))
        {
            Debug.Log("bee enter the Cage");
            beesCount++;
            if (beesCount!=0) 
            {
                Countdown.text = (beesNeeded - beesCount).ToString(); ;
            }
            if(beesCount >= beesNeeded && !AllInteractionsAreDone) 
            {
                Countdown.text = "";
                StartCoroutine(ReleaseAchAftTimer(0.7f));
                AllInteractionsAreDone = true;
            }
        }
    }
    public IEnumerator ReleaseAchAftTimer(float time)
    {
        yield return new WaitForSeconds(time);
        MANAGER.AchievementsList.instance.ON_BIRDS_AND_THE_BEES(AchievmentText, AchievmentImage);//give and display UI
        this.gameObject.SetActive(false);
        // Code to execute after the delay

    }
}
