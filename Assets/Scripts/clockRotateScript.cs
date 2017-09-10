using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockRotateScript : MonoBehaviour {


    private const string HAND_TAG = "Hand";
    public GameObject hourPiv;
    public GameObject minPiv;
    private bool initialRotate = false;
    private bool clockRotate = false;
    private float rotateTime = 0.2f;
    private float angleTotal = 0f;
    private float currentTime = 0.0f;

    private Vector3 currentMin;
    private Vector3 currentHour;
    private Vector3 firstMin;
    private Vector3 firstHour;
    private Vector2 firstController;
    private Vector2 prevController;

    public float minSpeed = 3.0f;
    public float hourSpeed = 1.0f;



    // Update is called once per frame
    void Update () {
        if (clockRotate && ViveControllerInputTest.controllerInput != Vector2.zero)
        {
            Debug.Log("getAxis");

            if (!initialRotate)
            {
                firstMin = minPiv.transform.eulerAngles;
                firstHour = hourPiv.transform.eulerAngles;
                currentHour = firstHour;
                currentMin = firstMin;
                firstController = ViveControllerInputTest.controllerInput;
                initialRotate = true;
                prevController = firstController;
            }

            Debug.Log("rotating");
            currentTime = currentTime + Time.deltaTime;
            Debug.Log(currentTime);
            if(currentTime >= rotateTime)
            {
                Debug.Log("in rotating function");
                Vector2 currentController = ViveControllerInputTest.controllerInput;
                float angle = Vector2.SignedAngle(prevController, currentController);
                Debug.Log(angle);
                Debug.Log(currentHour.x);
            if (currentHour.x <= 360 && currentHour.x >= 270)
            {
                Debug.Log("piv rotating");
                Vector3 targetMin = new Vector3(currentMin.x + angle, 0, 0);
                Vector3 targetHour = new Vector3(currentHour.x + angle / 12, 0, 0);
                minPiv.transform.Rotate(targetMin);
                hourPiv.transform.Rotate(targetHour);
                angleTotal += angle;
                currentTime = 0f;
                currentMin = targetMin;
                currentHour = targetHour;
                
            }
                prevController = currentController;
            
            }
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == HAND_TAG)
        {
            clockRotate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == HAND_TAG)
        {
            clockRotate = false;
            initialRotate = false;
            minPiv.transform.eulerAngles = Vector3.Lerp(minPiv.transform.eulerAngles, firstMin, minSpeed * Time.deltaTime);
            hourPiv.transform.eulerAngles = Vector3.Lerp(hourPiv.transform.eulerAngles, firstHour, hourSpeed * Time.deltaTime);
            angleTotal = 0f;
        }
    }
}
