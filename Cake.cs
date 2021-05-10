using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public GameObject[] Stages;
    public int currentStage;
    public bool AllInteractionsAreDone;
    void OnMouseDown()
    {
        if (AllInteractionsAreDone) 
        {
            return;
        }
        Debug.Log("I clicked the cake");
        if (PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool != "Knife")
        {
            return;
        }
        /*Do your stuff here*/
        if (currentStage <= Stages.Length - 2)
        {
            Stages[currentStage].SetActive(false);
            Stages[currentStage + 1].SetActive(true);
            currentStage++;
        }
        if (currentStage == Stages.Length - 2)
        {
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            Stages[currentStage].transform.parent = null;
            Stages[currentStage].transform.GetChild(0).parent = null;
            AllInteractionsAreDone = true;
            return;
        }
    }
}
