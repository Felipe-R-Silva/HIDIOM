using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bill : MonoBehaviour
{
    public Sprite AchievmentImage;
    public string AchievmentText;
    public string AchievementName = "BREAK_A_BILL";

    public bool billBroken;
    public float explosionForce;
    public float explosionRadios;
    public float explosionUpfroce;
    Vector3 explosionEpicenter;
    public GameObject[] coins;
    public Vector3 spawnOfset;

    public int numberOfCoins;
    private void Start()
    {
        spawnOfset = new Vector3(0, 0.1f, 0);
        explosionEpicenter = this.transform.position;
    }
    void OnMouseDown()
    {
        Debug.Log("I clicked the bill");
        if (PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>().ActiveTool != "Hammer" || billBroken)
        {
            return;
        }
        //make bill fly
        Collider[] coliders = Physics.OverlapSphere(explosionEpicenter, explosionRadios);
        foreach(Collider hit in coliders) 
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            //affect all in the area that have rigid body
            if(rb!= null)
            rb.AddExplosionForce(explosionForce, explosionEpicenter, explosionRadios, explosionUpfroce, ForceMode.Impulse);
            //tell every children in the area of explosion to instantiate a coin
            if (hit.GetComponent<Bill>()) 
            {
                //hit.GetComponent<Bill>().SpawnCoins();
                hit.GetComponent<Bill>().billBroken = true;
            }
        }
        SpawnCoins();
        //MANAGER.AchievementsList.instance.ON_BREAK_A_BILL(AchievmentText, AchievmentImage);//give and display UI
        //set achievement
        StartCoroutine(ReleaseAchAftTimer(1));
    }
    public void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject randomNewCoin = Instantiate(coins[Random.Range(0, coins.Length)], transform.position + spawnOfset, Random.rotation);
            randomNewCoin.name = "coin[" + i + "]";
            //randomNewCoin.transform.parent = this.transform;//parent to parent
                                                                   //add force
            randomNewCoin.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadios / 5, 3, ForceMode.Impulse);
        }

    }
    public IEnumerator ReleaseAchAftTimer(float time)
    {
        yield return new WaitForSeconds(time);
        MANAGER.AchievementsList.instance.ON_BREAK_A_BILL(AchievmentText, AchievmentImage);//give and display UI
        this.gameObject.SetActive(false);
        // Code to execute after the delay

    }
}
