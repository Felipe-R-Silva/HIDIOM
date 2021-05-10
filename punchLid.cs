using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchLid : MonoBehaviour
{
    public GameObject lid;
    public GameObject brokenLid;
    public void BreakLid()
    {
        lid.SetActive(false);
        brokenLid.SetActive(true);
    }
}
