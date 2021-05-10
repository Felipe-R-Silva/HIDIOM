using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToolController : MonoBehaviour
{
    public GameObject target;
    [SerializeField]
    public Dictionary<string,GameObject> Tools;

    public string ActiveTool;


    //DATA
    [SerializeField]
    public Vector3 position; //location of object before hiding it
    [SerializeField]
    public Quaternion rotation; //rotation
    [SerializeField]
    public GameObject OBJ_prefab; // Gameobject of this tool
    [SerializeField]
    public Texture2D[] MousePointers = new Texture2D[2]; //sprite of animations
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

        if (MousePointers[0] != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //animate
                Cursor.SetCursor(MousePointers[1], Vector2.zero, CursorMode.Auto);
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //animate
                Cursor.SetCursor(MousePointers[0], Vector2.zero, CursorMode.Auto);
            }

            if (Input.GetKeyDown(KeyCode.Mouse1)) 
            {
                Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                PLAYERCONTROLLER.try3.Instance.gameObject.GetComponent<PLAYERCONTROLLER.ControllerManager>().toolON = false;
                Instantiate(OBJ_prefab, position,rotation);
                Destroy(OBJ_prefab);
                rotation = new Quaternion();
                position = new Vector3();
                MousePointers[0] = null;
                MousePointers[1] = null;
                ActiveTool = null;
            }
        }
    }

    public void manualyStart(GameObject newtarget)
    {
        //save Tool target
        target = newtarget;
        //Request to save ToolData
        target.SendMessage("SendDataToToolController", SendMessageOptions.RequireReceiver);
        //Swap Cursor
        Cursor.SetCursor(MousePointers[0], Vector2.zero, CursorMode.Auto);
        //delete Object
        Destroy(target);
    }
    IEnumerator AnimateMouse()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("before");
            Cursor.SetCursor(MousePointers[1], Vector2.zero, CursorMode.Auto);
            yield return new WaitForSeconds(0.2f);
            Debug.Log("after");
            Cursor.SetCursor(MousePointers[0], Vector2.zero, CursorMode.Auto);

        }
    }

    public bool FindInteractable(out RaycastHit hit)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(hit.point, mouseWorldPosition, Color.red);

            // Do something with the object that was hit by the raycast.
            if (hit.transform.gameObject.tag == "Interactable")
            {
                return true;
            }
        }
        return false;
    }
}
