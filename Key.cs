using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ToolBase
{
    private void Start()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
    }

}
