using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obi;

public class MilkBox : MonoBehaviour
{
    public bool AllInteractionsAreDone;
    // Start is called before the first frame update
    public Vector3 rotations;
    public GameObject ObiEmiter;
    public float liquidSpeed;
    public bool milkLead;
    ObiActor actor;
    public float targetTime = 2f;


    public Sprite AchievmentImage;
    public string AchievmentText;

    //actor.solverIndices.Length
    void Start()
    {
        milkLead = true;
        ObiEmiter.GetComponent<ObiEmitter>().speed = 0;
        actor = ObiEmiter.GetComponent<ObiActor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllInteractionsAreDone) 
        {
            return;
        }

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        rotations = this.transform.rotation.eulerAngles;
        if((rotations.x >= 30 && rotations.x <= 90 || rotations.z >= 30 && rotations.z <= 270 )&& !milkLead) 
        {
            ObiEmiter.GetComponent<ObiEmitter>().speed = liquidSpeed;
            targetTime -= Time.deltaTime;
            //if (rotations.x >= 30 && rotations.x < 45 || rotations.z >= 30 && rotations.z < 45 ||
            //    rotations.z <= -30 && rotations.z > -45)
            //{
            //    ObiEmiter.GetComponent<ObiEmitter>().speed = liquidSpeed / 3;
            //}
            //if (rotations.x >= 45 && rotations.x < 60 || rotations.z >= 45 && rotations.z <= 60 ||
            //   rotations.z <= -45 && rotations.z >= -60)
            //{
            //    ObiEmiter.GetComponent<ObiEmitter>().speed = liquidSpeed / 2;
            //}
            //if (rotations.x >= 60 && rotations.x <= 120 || rotations.z >= 60 && rotations.z <= 90 ||
            //    rotations.z <= -60 && rotations.z >= -90)
            //    ObiEmiter.GetComponent<ObiEmitter>().speed = liquidSpeed;
        }
        else 
        {
            ObiEmiter.GetComponent<ObiEmitter>().speed = 0;
        }
    }
    void timerEnded()
    {
        AllInteractionsAreDone = true;
        //do your stuff here.
        MANAGER.AchievementsList.instance.ON_DONT_CRY_OVER_SPILT_MILK(AchievmentText, AchievmentImage);//give and Display UI
    }

}
