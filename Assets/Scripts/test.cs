using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    public Vector3 targetAngle;

    private Vector3 currentAngle;
    bool rotating = false;

    int num = 0;
    float speed = 10f;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotating = true;
            num += 1;
           
            targetAngle = new Vector3(num * 30f, 0, 0);
            Debug.Log(targetAngle);
        }

        if (rotating)
        {

            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime*speed),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime*speed),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime*speed));

            transform.eulerAngles = currentAngle;
            if(transform.eulerAngles == targetAngle)
            {
                rotating = false;
            }
        }
    }



}
