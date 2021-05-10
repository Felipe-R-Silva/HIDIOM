using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassBoxButton : MonoBehaviour
{
    public GameObject lid;
    public GameObject crakedLid;
    public GameObject brokenLid;

    public int NumberOfHitsToBreak;
    public int currentHits;

    private void Start()
    {
        if (NumberOfHitsToBreak < 2)
        {
            NumberOfHitsToBreak = 2;
        }
    }
    void OnMouseDown()
    {
        if (PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool == "Hammer" && currentHits < NumberOfHitsToBreak)
        {
            currentHits++;
            if (currentHits == NumberOfHitsToBreak-1)
            {
                //crackGlass
                CrackLid();
            }
        }
        if(currentHits == NumberOfHitsToBreak) 
        {
            this.GetComponent<BoxCollider>().enabled = false;
            BreakLid();
        }
    }
    public void CrackLid()
    {
        lid.SetActive(false);
        crakedLid.SetActive(true);
    }
    public void BreakLid()
    {
        crakedLid.SetActive(false);
        brokenLid.SetActive(true);
    }
}
