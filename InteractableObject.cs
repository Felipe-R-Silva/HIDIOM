using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    Vector3 OriginPosition;
    // Start is called before the first frame update
    void Start()
    {
        OriginPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReturnToOriginPosition() 
    {
        this.transform.position = OriginPosition;
        if (PLAYERCONTROLLER.try3.Instance.target == this.gameObject) 
        {
        }

        PLAYERCONTROLLER.try3.Instance.TargetOldPosition= OriginPosition;// 1 history
        PLAYERCONTROLLER.try3.Instance.TargetNewPosition= OriginPosition;//current position
        PLAYERCONTROLLER.try3.Instance.AjustedProjectecDesiredPosition= OriginPosition;
    }
}
