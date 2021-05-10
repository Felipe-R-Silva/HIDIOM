using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MANAGER
{
    public class LightManager : MonoBehaviour
    {
        public Light[] TutorialArea;
        public Light[] CenterRoom;
        public Light[] VendingMachine;
        public Light moon;

        public static LightManager instance;
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
        public void turnOffTutorialZone()
        {
            foreach (var item in TutorialArea)
            {
                item.enabled = false;
            }
        }
        public void turnONCenterRoom()
        {
            foreach (var item in CenterRoom)
            {
                item.enabled = true;
            }
        }
        public void turnONVendingMachine()
        {
            foreach (var item in VendingMachine)
            {
                item.enabled = true;
            }
        }

    }
}
