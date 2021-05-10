using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

namespace PLAYERCONTROLLER
{
    [System.Serializable]
    public class ControllerManager : MonoBehaviour
    {
        public static ControllerManager instance;
        public GameObject toolScriptLocation;
        public bool toolON;
        public bool dragON; //PLAYERCONTROLLER.ControllerManager.Instance
        public RaycastHit hit;

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
        void Start()
        {
            toolON = false;
            dragON = false;
        }
        // Update is called once per frame
        void Update()
        {
            if ( dragON == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    
                    string currentState = FindInteractable(out hit);
                    if (currentState != "No") // you are aiming at a selectable or tool and click it
                    {
                        Debug.Log(hit.transform.name + currentState);
                        switch (currentState)
                        {
                            case "DragInteractable":
                                Debug.Log("Case 0 - Hovering Over Drag OBJ");
                                dragON = true;
                                //drag turning on 
                                PLAYERCONTROLLER.try3.Instance.manualyStart(hit.transform.gameObject);// math data store

                                break;
                            case "ToolInteractable":
                                Debug.Log("Case 1 - Hovering Over Tool OBJ");
                                //tool turning on 
                                toolON = true;
                                PLAYERCONTROLLER.try3.Instance.GetComponent<ToolController>().manualyStart(hit.transform.gameObject);

                                break;
                            case "CameraTrigger":
                                Debug.Log("Case 2 - Hovering Over CameraTrigger");
                                Debug.Log(hit.transform.GetComponent<colliderID>().trigger);
                                Debug.Log("*******" + hit.transform.GetComponent<colliderID>().trigger);
                                MANAGER.CameraManager.intance.MoveCameraToNewPosition(hit.transform.GetComponent<colliderID>().trigger);
                                break;

                        }

                    }
                }
            }

        }
        public string FindInteractable(out RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.DrawLine(hit.point, mouseWorldPosition, Color.red);
                return hit.transform.gameObject.tag;
            }
            return "No";

        }
    }
}

//public int FindInteractable(out RaycastHit hit)
//{
//    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//    if (Physics.Raycast(ray, out hit))
//    {
//        Transform objectHit = hit.transform;
//        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Debug.DrawLine(hit.point, mouseWorldPosition, Color.red);

//        // Do something with the object that was hit by the raycast.
//        if (hit.transform.gameObject.tag == "DragInteractable")
//        {
//            Debug.Log("Hovering Over Drag OBJ");
//            return 0;
//        }
//        if (hit.transform.gameObject.tag == "ToolInteractable")
//        {
//            Debug.Log("Hovering Over Tool OBJ");
//            return 1;
//        }
//        if (hit.transform.gameObject.tag == "Interactable")
//        {
//            Debug.Log("Hovering Over OBJ Can Use Tool");
//            return 2;
//        }
//    }
//    return -1;

//}