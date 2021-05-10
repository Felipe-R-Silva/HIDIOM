using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerImpactExplosion : MonoBehaviour
{
    public float explosionForce;
    public float explosionRadios;
    public float explosionUpfroce;
    Vector3 explosionEpicenter;
    void OnMouseDown()
    {
        Debug.Log("I clicked the bill");
        if (PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool != "Hammer")
        {
            return;
        }
        explosionEpicenter = PLAYERCONTROLLER.ControllerManager.instance.hit.point;
        //make bill fly
        Collider[] coliders = Physics.OverlapSphere(explosionEpicenter, explosionRadios);
        Debug.Log(coliders.Length);

        foreach (Collider hit in coliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            //affect all in the area that have rigid body
            if (rb != null)
                rb.AddExplosionForce(explosionForce, explosionEpicenter, explosionRadios, explosionUpfroce, ForceMode.Impulse);
        }
    }
}
