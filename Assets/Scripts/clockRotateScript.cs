using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockRotateScript : MonoBehaviour {


    private const string HAND_TAG = "Hand";
    public GameObject hourPiv;
    public GameObject minPiv;
    private bool initialRotate = false;
    private bool clockRotate = false;
    private float startTime = 0f;
    public float rotateTime = 0.5f;
    private float angleTotal = 0f;


    private Quaternion firstMin;
    private Quaternion firstHour;
    private Vector2 firstController;
    private Vector2 prevController;

    public float speed = 1.0f;



    // Update is called once per frame
    void Update () {
        if (clockRotate && ViveControllerInputTest.controllerInput != Vector2.zero)
        {

            if (!initialRotate)
            {
                firstMin = minPiv.transform.rotation;
                firstHour = hourPiv.transform.rotation;
                firstController = ViveControllerInputTest.controllerInput;
                initialRotate = true;
                prevController = firstController;
            }

            float currentTime = startTime + Time.deltaTime;
            if(currentTime >= rotateTime)
            {
                Vector2 currentController = ViveControllerInputTest.controllerInput;
                float angle = Vector2.Angle(prevController, currentController);
                if (firstHour.x + angle > -60 && firstHour.x + angle < 30)
                {
                    minPiv.transform.Rotate(angle, 0, 0);
                    hourPiv.transform.Rotate(angle / 12, 0, 0);
                    angleTotal += angle;
                }
                prevController = currentController;
                currentTime = 0f;
            }
        }

        if (clockRotate && ViveControllerInputTest.controllerInput == Vector2.zero)
        {
            releaseRotate(firstController, firstHour, firstMin);
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

    private void releaseRotate(Vector2 fitstController, Quaternion firstHour, Quaternion firstMin)
    {
        if (angleTotal >= 180)
        {
            float finalAngle = 360 - angleTotal;
            minPiv.transform.Rotate(finalAngle, 0, 0);
            hourPiv.transform.Rotate(finalAngle / 12, 0, 0);
        }
        else
        {
            minPiv.transform.rotation = Quaternion.Lerp(minPiv.transform.rotation, firstMin, speed);
            hourPiv.transform.rotation = Quaternion.Lerp(hourPiv.transform.rotation, firstHour, speed);
        }

        angleTotal = 0f;
    }
}
