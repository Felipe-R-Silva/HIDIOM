using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PieceOfCake : MonoBehaviour
{
    public string AchievementName;
    public bool AllInteractionsAreDone;

    public GameObject ACHIEVEMNTE_UI;
    public Sprite AchievmentImage;
    public string AchievmentText;

    ToolController tool=null;
    MANAGER.AchievementsList achievelist = null;
    // Start is called before the first frame update
    private void Start()
    {
        tool = PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<ToolController>();
        achievelist = MANAGER.AchievementsList.instance;
    }
    void OnMouseDown()
    {
        if (tool.ActiveTool == null || tool.ActiveTool=="")
        {
            achievelist.ON_PIECE_OF_CAKE(AchievmentText, AchievmentImage);//give and Display UI
            AllInteractionsAreDone = true;
            PLAYERCONTROLLER.try3.Instance.gameObject.SetActive(false);
            Destroy(this.gameObject,0.5f);
            return;
        }
    }
}
