using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTogle : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody rb;
    protected BoxCollider bxc;

    public bool activeRagdol;
    public HashSet<GameObject> ragdollBonesHistory = new HashSet<GameObject>();
    public List<RagdollBone> ragdollBones = new List<RagdollBone>();
    // Start is called before the first frame update
    void Start()
    {
        GetAllChildren(this.transform, ragdollBones,ragdollBonesHistory);
        RagdollsetState(false);
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        bxc = GetComponent<BoxCollider>();
    }
    public void RagdollsetState(bool active) 
    {
        //children
        for (int i = 0; i < ragdollBones.Count; i++)
        {
            if (ragdollBones[i].rb)
            {
                ragdollBones[i].rb.isKinematic = !active;
                ragdollBones[i].rb.detectCollisions = active;
            }
            if (ragdollBones[i].col)
            {
            ragdollBones[i].col.enabled = active;
            }
        }
        //root
        if (rb)
        {
            rb.detectCollisions = active;
            rb.isKinematic = !active;
        }
        if (bxc)
        {
            bxc.enabled = active;
        }
        animator.enabled = !active;
    }
    private void Update()
    {
        /*
        if (!activeRagdol) { return;}
        for (int i = 0; i < ragdollBones.Count; i++)
        {
            ragdollBones[i].rb.isKinematic = false;
            ragdollBones[i].col.enabled = true;
        }
        */
    }
    public void GetAllChildren(Transform target, List<RagdollBone> ragdollBones, HashSet<GameObject> history)
    {
        if (target.childCount <= 0)
        {
            return;
        }

        foreach (Transform child in target)
        {
            if (AddRagdollBone(ragdollBones, child, history))
            {
                GetAllChildren(child, ragdollBones, history);
            }
        }

        return;
    }

    public bool AddRagdollBone(List<RagdollBone> ragdollBones, Transform target , HashSet<GameObject> his)
    {
        if (his.Contains(target.gameObject)) { return false; }
        his.Add(target.gameObject);
        Rigidbody RR = target.GetComponent<Rigidbody>();
        Collider CC = target.GetComponent<Collider>();
        RagdollBone n = new RagdollBone(RR, CC);
        ragdollBones.Add(n);
        return true;
    }
}
