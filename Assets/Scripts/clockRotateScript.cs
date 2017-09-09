using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockRotateScript : MonoBehaviour {


    private SteamVR_TrackedObject trackedObj;
    private const string HAND_TAG = "Hand";
    public GameObject hourPiv;
    public GameObject minPiv;
    public static bool clockRotate = false;
    private bool initialRotate = false;

    private Quaternion firstMin;
    private Quaternion firstHour;
    private Transform firstController;
    private Transform currentMin;
    private Transform currentHour;
    private Transform prevController;
    private Transform currController;

    public float speed = 1.0f;


    private void Awake()
    {
        trackedObj.GetComponent<SteamVR_TrackedObject>();

    }

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    // Update is called once per frame
    void Update () {

        if (clockRotate && Controller.GetHairTriggerDown())
        {
            if (!initialRotate)
            {
                firstMin = minPiv.transform.rotation;
                firstHour = hourPiv.transform.rotation;
                firstController = trackedObj.transform;
                initialRotate = true;
                prevController = firstController;
            }
            
            Transform currentController = trackedObj.transform;
            Vector3 target = currController.position - prevController.position;
            target.z = 0;
            float angle = Vector3.Angle(target, transform.forward);
            minPiv.transform.Rotate(angle, 0, 0);
            hourPiv.transform.Rotate(angle / 12, 0, 0);
            prevController = currentController;
        }

        if (clockRotate && Controller.GetHairTriggerUp())
        {
            releaseRotate(firstController, firstHour, firstMin);
            clockRotate = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == HAND_TAG)
        {
            clockRotate = true;
        }
    }

    private void releaseRotate(Transform fitstController, Quaternion firstHour, Quaternion firstMin)
    {
        Transform currentController = trackedObj.transform;
        Vector3 target = currentController.position - firstController.position;
        target.z = 0;
        float angle = Vector3.Angle(target, transform.forward);
        if (angle >= 180)
        {
            Quaternion targetAngleMin = minPiv.transform.rotation;
            Quaternion targetAngleHour = targetAngleMin;
            targetAngleMin.x = angle - 180;
            targetAngleHour.x = (angle - 180) / 12;
            minPiv.transform.rotation = Quaternion.Lerp(minPiv.transform.rotation, targetAngleMin, speed);
            hourPiv.transform.rotation = Quaternion.Lerp(hourPiv.transform.rotation, targetAngleHour, speed);

        }
        else
        {
            minPiv.transform.rotation = Quaternion.Lerp(minPiv.transform.rotation, firstMin, speed);
            hourPiv.transform.rotation = Quaternion.Lerp(hourPiv.transform.rotation, firstHour, speed);
        }
    }
}
