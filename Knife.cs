using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : ToolBase
{
    private void Start()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
    }
}
