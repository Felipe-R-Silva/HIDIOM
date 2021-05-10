using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RagdollBone
{
    [SerializeField]
    public Rigidbody rb;
    [SerializeField]
    public Collider col;

    public RagdollBone(Rigidbody newrb, Collider newcol)
    {
        rb = newrb;
        col = newcol;
    }
    public RagdollBone()
    {
        rb = null;
        col = null;
    }
}
