using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PLAYERCONTROLLER
{
    [System.Serializable]
    public class try3 : MonoBehaviour
    {

        //PLAYERCONTROLLER.try3.Instance.YourVariable
        static public try3 Instance { get { return _instance; } }
        static protected try3 _instance;

        public void Awake()
        {
            if (_instance != null)
            {
                Debug.LogWarning("PlayerMaster is already in play. Deleting new!", gameObject);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Instantiating new", gameObject);
                _instance = this;
            }
        }

        public GameObject target;
        float distanceFromCamera;
        public Vector3 offset;// this offset is the distance of your click to the center of the actual object
        float speed;
        // Start is called before the first frame update

        public Vector3 TargetOldPosition;// 1 history
        public Vector3 TargetNewPosition;//current position
        public Vector3 AjustedProjectecDesiredPosition; // desired position to end in last interaction

        void Start()
        {
            speed = 10;
        }

        private void Update()//Run with out ControllerManager
        {
            //if (target == null)
            //{
            //    RaycastHit hit;
            //    if (FindInteractable(out hit) && Input.GetMouseButtonDown(0)) // you are aiming at a selectable and click it
            //    {
            //        initializeTargetValues(hit);// math data store

            //        //misc UX
            //        target.GetComponent<Rigidbody>().useGravity = false;
            //        target.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            //        //target.transform.GetChild(0).transform.parent = null;

            //    }
            //}

        }
        // Update is called once per frame
        void FixedUpdate()
        {

            if (target != null)//has something selected
            {
                if (Input.GetKey(KeyCode.Mouse1)) 
                {
                    EndSelection();
                    return;
                }
                    //State Update
                    TargetNewPosition = target.transform.position;
                // State Evaluation
                if (IsPathObstructed(AjustedProjectecDesiredPosition))
                {
                    target.transform.position = TargetOldPosition;// reset item position
                    EndSelection(); // re establish gravity and some interactions
                    //target = null; // drop item
                    return;
                }
                else
                {
                    TargetOldPosition = TargetNewPosition;//update the safe position
                }

                //mouse
                Vector3 MouseDesiredPoint = XYMouseNewPosition();
                target.GetComponent<Rigidbody>().MovePosition(MouseDesiredPoint);
                AjustedProjectecDesiredPosition = MouseDesiredPoint;


                Vector3 arrowDesiredPoint = Vector3.zero;
                Vector3 ArrowPointVector = Vector3.zero;
                //arrows
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
                {
                    arrowDesiredPoint = ZMouseNewPosition(15, MouseDesiredPoint);
                    target.GetComponent<Rigidbody>().MovePosition(arrowDesiredPoint);
                    AjustedProjectecDesiredPosition = arrowDesiredPoint;

                    distanceFromCamera = Camera.main.WorldToScreenPoint(target.transform.position).z;//dont forget to update distance when moving away from camera
                }

                //Move

                //target.GetComponent<Rigidbody>().MovePosition(target.transform.position + (MousePointVector + ArrowPointVector));
                //AjustedProjectecDesiredPosition = MouseDesiredPoint;

                //distanceFromCamera = Camera.main.WorldToScreenPoint(target.transform.position).z;//dont forget to update distance when moving away from camera
            }
        }
        public bool FindInteractable(out RaycastHit hit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.DrawLine(hit.point, mouseWorldPosition, Color.red);

                // Do something with the object that was hit by the raycast.
                if (hit.transform.gameObject.tag == "Interactable")
                {
                    Debug.Log("HoveeingOverInteractable");
                    return true;
                }
            }
            return false;
        }
        public void manualyStart(GameObject newtarget) 
        {
            initializeTargetValues(newtarget);// math data store

            //misc UX
            target.GetComponent<Rigidbody>().useGravity = false;
            target.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;
            //target.transform.GetChild(0).transform.parent = null;
        }
         
        public void initializeTargetValues(GameObject hit)
        {
            target = hit;//lock target
            TargetOldPosition = target.transform.position;//Initial position
            TargetNewPosition = target.transform.position;//initial position
            AjustedProjectecDesiredPosition = target.transform.position;//initial position
            distanceFromCamera = Camera.main.WorldToScreenPoint(target.transform.position).z;//initialize target distance from camera
            offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));// initialize ofset of mouuse from center of target

            //UX
            if(target.GetComponent<MeshRenderer>())
            if (!target.GetComponent<MeshRenderer>().enabled)
            {
                target.GetComponent<MeshRenderer>().enabled = true;
            }
        }

        public bool IsPathObstructed(Vector3 desiredposition)
        {
            if (target.transform.position != desiredposition)//path is blocked
            {
                return true;
            }
            return false;

        }

        public Vector3 XYMouseNewPosition()
        {
            Vector3 mouse2DPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera);

            Vector3 mouse3DPosition = Camera.main.ScreenToWorldPoint(mouse2DPosition) + offset;
            //target.transform.position = AjustedProjectecDesiredPosition;//hard move
            //target.GetComponent<Rigidbody>().MovePosition(AjustedProjectecDesiredPosition);
            return mouse3DPosition;

        }
        public Vector3 ZMouseNewPosition(float speed, Vector3 MousePosition)
        {
            Vector3 arrow3DPossition;

            int signal = 1;// 1 or -1
            if (Input.GetKey(KeyCode.UpArrow) )
            {
                signal = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                signal = -1;
            }
            Vector3 clickofsetfromobjcenter = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceFromCamera));
            Vector3 corectdirection = (target.transform.position - (Camera.main.ScreenToWorldPoint(Input.mousePosition) + clickofsetfromobjcenter)).normalized;
            arrow3DPossition = MousePosition + (corectdirection * speed * Time.deltaTime) * signal;
            return arrow3DPossition;
        }
        public void EndSelection() 
        {
            target.GetComponent<Rigidbody>().useGravity = true;//UX
            target.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;//UX
            //StartCoroutine(collideAnimation(target));//UX
            target = null;
            this.gameObject.GetComponent<PLAYERCONTROLLER.ControllerManager>().dragON = false;
        }
        IEnumerator collideAnimation(GameObject trget)
        {
            int value = 5;
            for (int i = 0; i < value; i++)
            {
                Vector3 scaleChange2 = new Vector3(+0.5f, +0.5f, +0.5f);
                trget.transform.localScale += scaleChange2;
                yield return new WaitForSeconds(0.01f);
                // yield return null;
            }
            Vector3 scaleChange = new Vector3(-0.5f, -0.5f, -0.5f) * value;
            trget.transform.localScale += scaleChange;
            target = null;
        }
    }
}
