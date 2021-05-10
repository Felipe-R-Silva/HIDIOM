using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reseter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.tag == "DragInteractable")
        {
            Debug.Log("I am here");
            if (other.gameObject.GetComponent<InteractableObject>())
            {
                other.gameObject.GetComponent<InteractableObject>().ReturnToOriginPosition();
            }
            PLAYERCONTROLLER.try3.Instance.EndSelection();
            
        }
    }
}
