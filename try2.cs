using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class try2 : MonoBehaviour
{
    public LayerMask myLayerMask;
    public GameObject cursor;
    public GameObject target;
    float distanceFromCamera;
    public Vector3 offset;// this offset is the distance of your click to the center of the actual object
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, myLayerMask))
        {
            Transform objectHit = hit.transform;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.DrawLine(hit.point, mouseWorldPosition, Color.red);

            // Do something with the object that was hit by the raycast.
            //grabs object
            cursor.transform.position = hit.point;
            if (hit.transform.gameObject.tag == "Interactable" && hit.transform.gameObject != target)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.transform.gameObject.layer = 2;//ignoreRaycast
                    if (hit.transform.GetComponent<SpringJoint>() == null) 
                    {
                        hit.transform.gameObject.AddComponent<SpringJoint>();
                        hit.transform.GetComponent<SpringJoint>().breakForce = 10000;
                        hit.transform.GetComponent<SpringJoint>().tolerance = 0.001f;
                        hit.transform.GetComponent<SpringJoint>().spring = 100;
                    }
                    hit.transform.GetComponent<SpringJoint>().connectedBody = cursor.GetComponent<Rigidbody>();
                }

            }
        }
        // cursormove
        if (target != null)
        {
            //Vector3 ObjectDesiredProjection = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);

            //Vector3 AjustedProjectecDesiredPosition = Camera.main.ScreenToWorldPoint(ObjectDesiredProjection) + offset;
            ////target.transform.position = curPosition;//hard move
            //target.GetComponent<Rigidbody>().MovePosition(AjustedProjectecDesiredPosition);
            //Vector3 direction = (AjustedProjectecDesiredPosition - target.transform.position).normalized;

            //if (Input.GetKey(KeyCode.UpArrow))
            //{
            //    //target.transform.Translate(Camera.main.transform.forward * 10 * Time.deltaTime);
            //    target.GetComponent<Rigidbody>().MovePosition(target.transform.position + Camera.main.transform.forward * 10 * Time.deltaTime);
            //    distanceFromCamera = Camera.main.WorldToScreenPoint(target.transform.position).z;
            //}
            //if (Input.GetKey(KeyCode.DownArrow))
            //{
            //    //target.transform.Translate(-Camera.main.transform.forward * 10 * Time.deltaTime);
            //    target.GetComponent<Rigidbody>().MovePosition(target.transform.position + (-Camera.main.transform.forward.normalized * 10 * Time.deltaTime));
            //    distanceFromCamera = Camera.main.WorldToScreenPoint(target.transform.position).z;
            //}

            //target.GetComponent<Rigidbody>().AddForce(direction*10);
            //target.GetComponent<Rigidbody>().MovePosition(AjustedProjectecDesiredPosition+ direction*100*Time.deltaTime);
            //target.GetComponent<Rigidbody>().MovePosition(target.transform.position + (direction * 1 * Time.deltaTime));


        }
    }
}
