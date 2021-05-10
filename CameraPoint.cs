using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPoint
{
    public enum CP { Main, VendingMachine, VMGround, mannequin,CatBoxWindow,UpperShelf,LowerShelf,UnderShelfGround,CageMail,BlackMarket,Outside };
    [SerializeField]
    public CP place;
    [SerializeField]
    public Transform transform;
    [SerializeField]
    public BoxCollider trigger;



    public void DisableBoxCollider() 
    {
        if(trigger!= null)
        trigger.enabled = false;
    }
}
