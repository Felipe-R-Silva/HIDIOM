using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class GizmosController : MonoBehaviour
{
    public GameObject prefab ;
    private Vector3 screenPoint;
    private Vector3 offset;
    public float speed;
    private void Start()
    {
        speed = 10;
    }
    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);//converts obj position to screan x y z-distance
        GetComponent<Rigidbody>().isKinematic = true;
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    private void OnMouseUp()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K)) 
        {
            Instantiate(prefab, screenPoint, Quaternion.identity);
        }
            if (Input.GetKey(KeyCode.UpArrow))
        {
            // transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(transform.position + Camera.main.transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(-Camera.main.transform.forward * speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(transform.position + -Camera.main.transform.forward * speed * Time.deltaTime);
        }
    }
    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        Instantiate(prefab, curPosition, Quaternion.identity);
        transform.position = curPosition;//hard move
        //move(curPosition,transform.position);

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
            //GetComponent<Rigidbody>().MovePosition(transform.position + Camera.main.transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-Camera.main.transform.forward * speed * Time.deltaTime);
            //GetComponent<Rigidbody>().MovePosition(transform.position + -Camera.main.transform.forward * speed * Time.deltaTime);
        }
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);//converts obj position to screan x y z-distance
        //offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }
    public void move(Vector3 desiredPosition, Vector3 currentPosition)
    {
        Vector3 direction = desiredPosition - currentPosition;
        Ray ray = new Ray(currentPosition, direction);
        RaycastHit hit;
        if (!Physics.Raycast(ray, out hit, direction.magnitude))
            GetComponent<Rigidbody>().MovePosition(desiredPosition);
        else
            GetComponent<Rigidbody>().MovePosition(hit.point);
    }

}