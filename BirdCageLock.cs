using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BirdCageLock : MonoBehaviour
{
    public GameObject LockCage;
    public GameObject DoorCage;
    public GameObject OpenCOlliderGroup;
    bool AllInteractionsAreDone;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        if (PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool != "Key2"|| AllInteractionsAreDone)
        {
            return;
        }
        //Activate animation Sequence
        StartCoroutine(OpenLock(1));
        AllInteractionsAreDone = true;

        return;
    }

    public IEnumerator OpenLock(float time)
    {
        // Open Lock
        LockCage.GetComponent<Animator>().SetBool("OpenLock", true);
        yield return new WaitForSeconds(time);
        //Open Cage
        DoorCage.GetComponent<Animator>().SetBool("OpenCageDoor", true);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        OpenCOlliderGroup.SetActive(true);

        yield return new WaitForSeconds(time);
        Destroy(LockCage);
    }
}
