using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefunction : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
    }

    // Update is called once per frame
    private void Update()
    {
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
    public void movefunc(Vector3 placetomove) 
    {
        GetComponent<Rigidbody>().MovePosition(placetomove);
    }
}
