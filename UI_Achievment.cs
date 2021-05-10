using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Achievment : MonoBehaviour
{
    bool AchievemntSolved = false;

    [SerializeField] public MANAGER.AchievementsList.achievementsEnum type;

    [SerializeField] GameObject title_reveled;
    [SerializeField] GameObject title_locked;

    [SerializeField] GameObject description_reveled;
    [SerializeField] GameObject description_locked;

    [SerializeField] GameObject image_reveled;
    [SerializeField] GameObject image_locked;

    [SerializeField] CanvasGroup hintsGroup;
    [SerializeField] GameObject hintsText;
    [TextArea(5, 20)]
    [SerializeField] string Hint1;
    [TextArea(5, 20)]
    [SerializeField] string Hint2;
    [TextArea(5, 20)]
    [SerializeField] string Hint3;

    private void OnEnable()
    {
        Hide_Achievement();
        if (MANAGER.AchievementsList.instance.getEnumBool(type)) 
        {
            Reveal_Achievement();
            AchievemntSolved = true;
        } 
    }

    public void Reveal_Achievement()
    {
        hintsGroup.interactable = false;

        hintsText.SetActive(false);

        title_reveled.SetActive(true);
        title_locked.SetActive(false);

        description_reveled.SetActive(true);
        description_locked.SetActive(false);

        image_reveled.SetActive(true);
        image_locked.SetActive(false);
    }
    public void Hide_Achievement()
    {
        //hintsText.SetActive(false);

        title_reveled.SetActive(false);
        title_locked.SetActive(true);

        description_reveled.SetActive(false);
        if (!hintsText.activeInHierarchy)
        {
            description_locked.SetActive(true);
        }

        image_reveled.SetActive(false);
        image_locked.SetActive(true);
    }

    public void Reveal_Hint_1() 
    {
        description_locked.SetActive(false);
        description_reveled.SetActive(false);
        hintsText.SetActive(true);
        hintsText.GetComponent<Text>().text = Hint1;

    }
    public void Reveal_Hint_2()
    {
        description_locked.SetActive(false);
        description_reveled.SetActive(false);
        hintsText.SetActive(true);
        hintsText.GetComponent<Text>().text = Hint2;

    }
    public void Reveal_Hint_3()
    {
        description_locked.SetActive(false);
        description_reveled.SetActive(false);
        hintsText.SetActive(true);
        hintsText.GetComponent<Text>().text = Hint3;

    }
}
