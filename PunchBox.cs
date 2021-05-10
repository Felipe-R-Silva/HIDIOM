using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBox : MonoBehaviour
{
    public GameObject invisibleWall;
    public punchLid Lid;
    public RagdollTogle Cat;
    public float punchdelay;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float punchStrenght;
    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        Lid.BreakLid();
    //        invisibleWall.SetActive(false);
    //        StartCoroutine(FlyCat(punchdelay));
    //    }
    //}
    public void Punch(GameObject Target) 
    {
        Target.GetComponent<Rigidbody>().AddForce((Target.transform.position - this.transform.position).normalized * punchStrenght ,ForceMode.VelocityChange);
    }
    IEnumerator FlyCat(float t)
    {
        yield return new WaitForSeconds(t);
        Cat.RagdollsetState(Cat.activeRagdol);
        Punch(Cat.ragdollBones[1].col.transform.gameObject);
    }

    public void ActivateSequence() 
    {
        Lid.BreakLid();
        invisibleWall.SetActive(false);
        StartCoroutine(FlyCat(punchdelay));
    }
}
