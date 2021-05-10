using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manequim : MonoBehaviour
{
    public bool AllinteractionsDOne;
    public int NumberOfHitsToBreak;
    public int currentHits;
    public float thrust;

    public bool thisIsLeg;

    public Sprite AchievmentImage;
    public string AchievmentText;
    public string AchievementName = "BREAK_A_LEG";

    void OnMouseDown()
    {
        if (AllinteractionsDOne) 
        {
            if(this.GetComponent<HingeJoint>())
            Destroy(this.GetComponent<HingeJoint>());
            return;
        }
        Rigidbody rb = this.transform.GetComponent<Rigidbody>();
        if(PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool == "Hammer" && currentHits < NumberOfHitsToBreak) 
        {
            currentHits++;
            rb.AddForce(Vector3.forward* thrust*10, ForceMode.Impulse);
        }
        if (PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool != "Hammer")
        {
            rb.AddForce(Vector3.forward * thrust, ForceMode.Impulse);
            return;
        }
        if (currentHits >= NumberOfHitsToBreak)
        {
            Debug.Log("broke");
            this.gameObject.tag = "DragInteractable";
            rb.AddForce(Vector3.forward * thrust, ForceMode.Impulse);
            Destroy(this.GetComponent<HingeJoint>());
            if (thisIsLeg) 
            {
                StartCoroutine(ReleaseAchAftTimer(1));
            }
            AllinteractionsDOne = true;
        }
    }
    public IEnumerator ReleaseAchAftTimer(float time)
    {
        yield return new WaitForSeconds(time);
        MANAGER.AchievementsList.instance.ON_BREAK_A_LEG(AchievmentText, AchievmentImage);//give and display UI
        // Code to execute after the delay

    }
}
