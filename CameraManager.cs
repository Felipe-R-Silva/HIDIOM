using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MANAGER
{
    public class CameraManager : MonoBehaviour
    {
        public static CameraManager intance;

        private void Awake()
        {
            if (intance != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                intance = this;
            }
        }

        public CameraPoint.CP lastPlace;
        public CameraPoint.CP targetPlace;

        public Transform Current_CP;

        Dictionary<CameraPoint.CP, CameraPoint> location = new Dictionary<CameraPoint.CP, CameraPoint>();
        [SerializeField]
        public CameraPoint[] CPs;
        [TextArea(15, 20)]
        public string Description = "";
        [SerializeField] AnimationCurve _reachCurve = new AnimationCurve(new Keyframe[2] { new Keyframe(0, 0, 0, 0), new Keyframe(1, 1, 0, 0) });
        [SerializeField] float _timeToReach = 1f;
        float _time = 0;
        float _reach = 0;

        void Start()
        {
            AudioListener.volume = 0.5f;
            foreach (var item in CPs)
            {
                location.Add(item.place, item);
            }
        }
        void Update()
        {
             _time += Time.deltaTime;
            if (_time > _timeToReach/ _timeToReach)
            {
                if (targetPlace != lastPlace)
                {
                    lastPlace = targetPlace;
                }
                return;
            }
            moveCameraToTarget();
        }
        public void moveCameraToTarget()
        {
            _reach = _reachCurve.Evaluate(Mathf.InverseLerp(0, _timeToReach, _time));
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, location[targetPlace].transform.position, _reach);
            Camera.main.transform.rotation = Quaternion.Slerp(Camera.main.transform.rotation, location[targetPlace].transform.rotation, _reach);
        }
        public void MoveCameraToNewPosition(CameraPoint.CP newPosition)
        {
            if (location[newPosition].trigger != null)
                location[newPosition].trigger.gameObject.SetActive(false);
            if (location[targetPlace].trigger != null)
                location[targetPlace].trigger.gameObject.SetActive(true);

            if (!(newPosition == CameraPoint.CP.Main)) 
            {
                MANAGER.MainUIManager.instance.ON_Return_Main();
            }
            _time = 0;
            targetPlace = newPosition;
            Current_CP = Camera.main.transform;
        }


        public void MoveCameraToMain() 
        {
            MoveCameraToNewPosition(CameraPoint.CP.Main);

        }
    }
}
