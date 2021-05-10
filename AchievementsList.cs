using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

namespace MANAGER
{
    public class AchievementsList : MonoBehaviour
    {
        public enum achievementsEnum
            {
            PIECE_OF_CAKE, DROP_THE_MIKE, BREAK_A_BILL, BIRDS_AND_THE_BEES, GREEN_THUMB, SPILL_THE_BEANS,
                NO_FREE_LUNCH, PAINT_THE_TOWN_RED, GO_POSTAL, BREAK_A_LEG, DONT_CRY_OVER_SPILT_MILK,CURIOSITY_KILLED_THE_CAT
        };
        public static AchievementsList instance;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this);
            }
        }
        public bool getEnumBool(achievementsEnum testEnum) 
        {
            switch (testEnum)
            {
                case achievementsEnum.PIECE_OF_CAKE:
                    return PIECE_OF_CAKE;
                case achievementsEnum.DROP_THE_MIKE:
                    return DROP_THE_MIKE;
                case achievementsEnum.BREAK_A_BILL:
                    return BREAK_A_BILL;
                case achievementsEnum.BIRDS_AND_THE_BEES:
                    return BIRDS_AND_THE_BEES;
                case achievementsEnum.GREEN_THUMB:
                    return GREEN_THUMB;
                case achievementsEnum.SPILL_THE_BEANS:
                    return SPILL_THE_BEANS;
                case achievementsEnum.NO_FREE_LUNCH:
                    return NO_FREE_LUNCH;
                case achievementsEnum.PAINT_THE_TOWN_RED:
                    return PAINT_THE_TOWN_RED;
                case achievementsEnum.GO_POSTAL:
                    return GO_POSTAL;
                case achievementsEnum.BREAK_A_LEG:
                    return BREAK_A_LEG;
                case achievementsEnum.DONT_CRY_OVER_SPILT_MILK:
                    return DONT_CRY_OVER_SPILT_MILK;
                case achievementsEnum.CURIOSITY_KILLED_THE_CAT:
                    return CURIOSITY_KILLED_THE_CAT;
                default:
                    Debug.LogError("EnumNotFound");
                    return false;
            }
        }

        public AchievemntUnlokedUI ACHIEVEMNTE_UI;

        public bool PIECE_OF_CAKE;//Piece of cake✓ 
        public bool DROP_THE_MIKE;//Drop the mike✓
        public bool BREAK_A_BILL;//Break a bill.✓
        public bool BIRDS_AND_THE_BEES;//Birds and the Bees✓
        public bool GREEN_THUMB;//Green thumb
        public bool SPILL_THE_BEANS;//Spill the Beans.
        public bool NO_FREE_LUNCH;//There's no such thing as a free lunch✓ 
        public bool PAINT_THE_TOWN_RED;//Paint the town red
        public bool GO_POSTAL;//Go postal✓
        public bool BREAK_A_LEG;//Break a leg✓
        public bool DONT_CRY_OVER_SPILT_MILK;//Don’t cry over spilt milk✓
        public bool CURIOSITY_KILLED_THE_CAT;//Curiosity killed the cat ✓


        public GameObject invisibelWall;

        public void DisplayUI(string AchievmentText,Sprite AchievmentImage)
        {
            ACHIEVEMNTE_UI.textOBJ.GetComponent<Text>().text = AchievmentText;
            ACHIEVEMNTE_UI.ImageOBJ.GetComponent<Image>().sprite = AchievmentImage;
            ACHIEVEMNTE_UI.gameObject.SetActive(true);
        }

        public void tutorialArea()
        {
            if (PIECE_OF_CAKE && DROP_THE_MIKE)
            {
                //End Tutorial Area

            }
        }
        public void EndTutorialArea()
        {
            MANAGER.LightManager.instance.turnOffTutorialZone();
            MANAGER.LightManager.instance.turnONCenterRoom();
            MANAGER.LightManager.instance.turnONVendingMachine();
            invisibelWall.SetActive(false);

        }


        public void ON_PIECE_OF_CAKE(string AchievmentText, Sprite AchievmentImage)
        {
            PIECE_OF_CAKE = true;
            DisplayUI(AchievmentText, AchievmentImage);
            if (DROP_THE_MIKE) 
            {
                EndTutorialArea();
            }
            GiveAchievement("PIECE_OF_CAKE");
            SteamUserStats.SetAchievement("PIECE_OF_CAKE");//localy recieves achievement
            SteamUserStats.StoreStats();//tell steam to update
            Debug.Log("PIECE_OF_CAKE"+ " unloked");
        }
        public void ON_BIRDS_AND_THE_BEES(string AchievmentText, Sprite AchievmentImage)
        {
            BIRDS_AND_THE_BEES = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("BIRDS_AND_THE_BEES");
        }
        public void ON_BREAK_A_BILL(string AchievmentText, Sprite AchievmentImage)
        {
            BREAK_A_BILL = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("BREAK_A_BILL");
        }
        public void ON_DROP_THE_MIKE(string AchievmentText, Sprite AchievmentImage)
        {
            DROP_THE_MIKE = true;
            GiveAchievement("DROP_THE_MIKE");
            if (PIECE_OF_CAKE)
            {
                EndTutorialArea();
            }
            DisplayUI(AchievmentText, AchievmentImage);
        }
        public void ON_GREEN_THUMB(string AchievmentText, Sprite AchievmentImage)
        {
            GREEN_THUMB = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("GREEN_THUMB");
        }
        public void ON_SPILL_THE_BEANS(string AchievmentText, Sprite AchievmentImage)
        {
            SPILL_THE_BEANS = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("SPILL_THE_BEANS");
        }
        public void ON_NO_FREE_LUNCH(string AchievmentText, Sprite AchievmentImage)
        {
            NO_FREE_LUNCH = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("NO_FREE_LUNCH");
        }
        public void ON_PAINT_THE_TOWN_RED(string AchievmentText, Sprite AchievmentImage)
        {
            PAINT_THE_TOWN_RED = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("PAINT_THE_TOWN_RED");

        }
        public void ON_GO_POSTAL(string AchievmentText, Sprite AchievmentImage)
        {
            GO_POSTAL = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("GO_POSTAL");
        }
        public void ON_BREAK_A_LEG(string AchievmentText, Sprite AchievmentImage)
        {
            BREAK_A_LEG = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("BREAK_A_LEG");
        }
        public void ON_DONT_CRY_OVER_SPILT_MILK(string AchievmentText, Sprite AchievmentImage)
        {
            DONT_CRY_OVER_SPILT_MILK = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("DONT_CRY_OVER_SPILT_MILK");
        }
        public void ON_CURIOSITY_KILLED_THE_CAT(string AchievmentText, Sprite AchievmentImage)
        {
            CURIOSITY_KILLED_THE_CAT = true;
            DisplayUI(AchievmentText, AchievmentImage);
            GiveAchievement("CURIOSITY_KILLED_THE_CAT");
        }

        public void GiveAchievement(string achievementName)
        {
            //SteamUserStats.SetAchievement(achievementName);//localy recieves achievement
            //SteamUserStats.StoreStats();//tell steam to update
            //Debug.Log("(" + achievementName + ")+" + " unloked");
        }
    }
}
