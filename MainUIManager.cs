using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MANAGER
{
    public class MainUIManager : MonoBehaviour
    {
        public static MainUIManager instance;

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

        public GameObject button_Camera_To_Main;

       public void ON_Return_Main() 
       {
            button_Camera_To_Main.SetActive(true);
       }
        public void OFF_Return_Main()
        {
            button_Camera_To_Main.SetActive(false);
        }
    }
}
