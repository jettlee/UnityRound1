﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockRotateScript : MonoBehaviour {


    private const string HAND_TAG = "Hand";
    public GameObject hourPiv;
    public GameObject minPiv;
    public static bool clockRotate = false;
    private bool initialRotate = false;
    public GameObject trackedObj;

    private Quaternion firstMin;
    private Quaternion firstHour;
    private Transform firstController;
    private Transform currentMin;
    private Transform currentHour;
    private Transform prevController;

    public float speed = 1.0f;


    // Update is called once per frame
    void Update () {

        if (clockRotate && ControllerGrabObject.hasTrigger)
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
            Vector3 target = currentController.position - prevController.position;
            target.x = 0;
            float angle = Vector3.Angle(target, transform.forward);
            minPiv.transform.Rotate(angle, 0, 0);
            hourPiv.transform.Rotate(angle / 12, 0, 0);
            prevController = currentController;
        }

        if (clockRotate && ControllerGrabObject.hasTrigger)
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

        if (other.gameObject.tag == HAND_TAG)
        {
            clockRotate = false;
            initialRotate = false;
        }
    }

    private void releaseRotate(Transform fitstController, Quaternion firstHour, Quaternion firstMin)
    {
        Transform currentController = trackedObj.transform;
        Vector3 target = currentController.position - firstController.position;
        target.x = 0;
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
