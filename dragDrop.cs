using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class dragDrop : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    public bool dargRoot;
    public bool dragParent;
    public Vector3 startCoordinate;
    public bool interuptDrag;

    public bool mouseUp;
    public bool mouseDown;

    private void Start()
    {
        startCoordinate = this.transform.position;
    }
    public void ResetToPosition()
    {
        //transform.position = moveTo;
        transform.position=transform.parent.position;
       
    }
    private void OnMouseUp()
    {
        mouseUp = true;
        mouseDown = false;
        //crik crik
        print("mouse UP");
        interuptDrag = false;
    }
    void OnMouseDown()
    {
        mouseDown = true;
        mouseUp = false;

        if (Input.GetMouseButtonDown(1))
        {
            interuptDrag = true;
            //do stuff here
        }
        if (interuptDrag)
        {
            ResetToPosition();
        }
        else
        {
            if (dargRoot)
            {
                mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.root.position).z;
                // Store offset = gameobject world pos - mouse world pos
                mOffset = gameObject.transform.root.position - GetMouseAsWorldPoint();
            }
            else if (dragParent)
            {
                mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.parent.position).z;
                // Store offset = gameobject world pos - mouse world pos
                mOffset = gameObject.transform.parent.position - GetMouseAsWorldPoint();
            }
            else
            {
                mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
                // Store offset = gameobject world pos - mouse world pos
                mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
            }
        }
    }
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(1)){
            //do stuff here
        }
    }
    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if (Input.GetMouseButtonDown(1))
        {
            interuptDrag = true;
            //do stuff here
        }
        if (interuptDrag)
        {
            ResetToPosition();
        }
        else
        {
            if (dargRoot)
            {
                transform.root.position = GetMouseAsWorldPoint() + mOffset;
            }
            else if (dragParent)
            {
                transform.parent.position = GetMouseAsWorldPoint() + mOffset;
            }
            else
            {
                transform.position = GetMouseAsWorldPoint() + mOffset;
            }
        }
    }
}