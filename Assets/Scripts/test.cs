using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	Vector3 targetAngle;

    private Vector3 currentAngle;
    bool rotating = false;

    int num = 1;
    float speed = 10f;

    public void Start()
    {
        currentAngle = transform.eulerAngles;
    }

	public void StartRotate() {
		//Debug.Log ("space");
		rotating = true;
		num += 1;

		if (num > 7) {
			num = 0;
		}   

		targetAngle = new Vector3((num-1) * 45f - 90, 0, -180);
		Debug.Log(num);
	}

    public void Update()
    {

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//			
//        }

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
