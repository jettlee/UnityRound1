using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	Vector3 targetAngle;

    private Vector3 currentAngle;
    bool rotating = false;

    public int num = 1;
    float speed = 10f;

    void Start()
    {
        transform.eulerAngles = new Vector3(-90f, 0f, -180f);
        currentAngle = transform.eulerAngles;
    }

	public void StartRotate() {
		//Debug.Log ("space");
		rotating = true;
		num += 1;

		if (num > 7) {
			num = 0;
		}   

		targetAngle = new Vector3((num-1) * 45f - 90f, 0f, -180f);
		Debug.Log(num);
	}

    public void Update()
    {

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    StartRotate();

        //}

        if (rotating)
        {

            currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime*speed),
            0f,
            -180f);

            transform.eulerAngles = currentAngle;
            if(transform.eulerAngles == targetAngle)
            {
                rotating = false;
            }
        }
    }



}
