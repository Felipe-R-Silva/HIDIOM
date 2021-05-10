using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milkCap : MonoBehaviour
{
    public bool AllInteractionsAreDone;
    public float thrust;
    public Transform capPosition;
    public MilkBox MilkBox;
    private void Update()
    {
        if (!AllInteractionsAreDone)
        this.transform.position = capPosition.transform.position;
        this.transform.rotation = capPosition.transform.rotation;
    }
    void OnMouseDown()
    {
        Debug.Log("I am here");
        if (AllInteractionsAreDone)
        {
            return;
        }
        Debug.Log("I clicked the cake");
        if (!string.IsNullOrEmpty(PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool))
        {
            return;
        }
        /*Do your stuff here*/
        MilkBox.milkLead = false;
        //transform.parent = null;
        if (!transform.GetComponent<Rigidbody>()) 
        {
            Rigidbody rb=gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            rb.AddForce(capPosition.up * thrust);
            rb.AddTorque(new Vector3(Random.value, Random.value, Random.value));
            AllInteractionsAreDone = true;
        }
    }
}
