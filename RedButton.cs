using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedButton : MonoBehaviour
{
    public PunchBox box;
    public bool AllinteractionsDOne;

    public Sprite AchievmentImage;
    public string AchievmentText;
    public string AchievementName = "CURIOSITY_KILLED_THE_CAT";

    void OnMouseDown()
    {
        if (AllinteractionsDOne) {
            return;
        }
        box.ActivateSequence();
        AllinteractionsDOne = true;
        StartCoroutine(ReleaseAchAftTimer(1.5f));
    }

    public IEnumerator ReleaseAchAftTimer(float time)
    {
        yield return new WaitForSeconds(time);
        MANAGER.AchievementsList.instance.ON_CURIOSITY_KILLED_THE_CAT(AchievmentText, AchievmentImage);//give and display UI
        // Code to execute after the delay

    }
}
