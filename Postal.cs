using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Postal : MonoBehaviour
{
    public bool AllinteractionsDOne;
    public Sprite AchievmentImage;
    public string AchievmentText;
    public string AchievementName = "GO_POSTAL";
    public float movespeed;

    public GameObject[] navPoints;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "_mail") 
        {
           // PLAYERCONTROLLER.try3.Instance.EndSelection();
            // Destroy(other.gameObject.GetComponent<Rigidbody>());
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //do animation
            StartCoroutine(AnimateEmail(other.gameObject, movespeed));
        }
    }
    public IEnumerator AnimateEmail(GameObject target,float speed)
    {
        if (speed <= 0) 
        {
            speed = 5;
        }
        target.transform.LookAt(navPoints[0].transform);
        for (int i = 0; i < navPoints.Length; i++)
        {
            
            target.transform.LookAt(navPoints[0].transform);
            while (Vector3.Distance(navPoints[i].transform.position, target.transform.position)>0.5)
            {
                float step = speed * Time.deltaTime; // calculate distance to move
                target.transform.position = Vector3.MoveTowards(target.transform.position, navPoints[i].transform.position, step);
                yield return new WaitForSeconds(0.001f);
            }
        }
        StartCoroutine(ReleaseAchAftTimer(1));
    }

    public IEnumerator ReleaseAchAftTimer(float time)
    {
        yield return new WaitForSeconds(time);
        MANAGER.AchievementsList.instance.ON_GO_POSTAL(AchievmentText, AchievmentImage);//give and display UI
        // Code to execute after the delay

    }
}
