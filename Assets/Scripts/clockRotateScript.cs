using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockRotateScript : MonoBehaviour {

    public Rigidbody minPiv;
    public GameObject hourPiv;

    private Vector3 currMin;
    private Vector3 currHour;

    private void Awake()
    {
        minPiv = GetComponent<Rigidbody>();
        currHour = hourPiv.transform.eulerAngles ;
        currMin = minPiv.transform.eulerAngles ;
        //Debug.Log(currHour);
        //Debug.Log(currMin);
    }

    // Update is called once per frame
    void Update ()
    {
        //Debug.Log(ControllerGrabObject.rotateReset);
        //Debug.Log("getAxis and in update");

        
        Vector3 nextMin = minPiv.transform.eulerAngles ;
        //Debug.Log(nextMin);
        float minPivRotationX = nextMin.x - currMin.x;

        if (currHour.x - minPivRotationX / 12 > 359 || currHour.x - minPivRotationX / 12 < 300)
        {
            //Debug.Log("boundary conditions");
            minPiv.transform.eulerAngles = new Vector3(90, 0, 0);
            if (Mathf.Abs(currHour.x - minPivRotationX / 12 - 0) > Mathf.Abs(currHour.x - minPivRotationX / 12 - (-60)))
            {
                hourPiv.transform.eulerAngles = new Vector3(300, 0, 0);  
            }
            else
            {
                hourPiv.transform.eulerAngles = new Vector3(359, 0, 0);
            }
        }
        else
        {
            //Debug.Log("in rotating function");
            hourPiv.transform.eulerAngles = new Vector3(currHour.x - minPivRotationX / 12, 0, 0);
        }

        currMin = nextMin;
        currHour = hourPiv.transform.eulerAngles;

        if (ControllerGrabObject.rotateReset)
        {
            Debug.Log("doing");
            //ControllerGrabObject.rotateReset = false;
            minPiv.transform.eulerAngles = new Vector3(90, 0, 0);
            /*
            float hourFinalAngle;
            float hourTarget = Mathf.Min(Mathf.Abs(currHour.x - 359), Mathf.Abs(currHour.x - 330), Mathf.Abs(currHour.x - 300));
            if (hourTarget == Mathf.Abs(currHour.x - 0))
            {
                hourFinalAngle = 359;
            }
            else if (hourTarget == Mathf.Abs(currHour.x - 330))
            {
                hourFinalAngle = 330;
            }
            else
            {
                hourFinalAngle = 300;
            }
            ***/
            //hourPiv.transform.eulerAngles = new Vector3(hourFinalAngle, 0, 0);
            ControllerGrabObject.rotateReset = false;
        }
    }
}
