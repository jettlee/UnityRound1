using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour {

    int status;
    //0 - alarm
    //1 - file
    //2 - phone

    public bool alarm_done;
    public bool file_done;
    public bool phone_done;

    public GameObject alarm_hint;
    public GameObject file_hint;
    public GameObject phone_hint;
    public GameObject leave_hint;




    // Use this for initialization
    void Start () {
        status = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(status == 0)
        {
            if(alarm_done)
            {

                //audio

                alarm_hint.SetActive(false);
                file_hint.SetActive(true);
                phone_hint.SetActive(false);
                leave_hint.SetActive(false);

                status = 1;
            }
        }

        if(status == 1)
        {
            if(file_done)
            {
                alarm_hint.SetActive(false);
                file_hint.SetActive(false);
                phone_hint.SetActive(true);
                leave_hint.SetActive(false);

                status = 2;

            }
        }
		
        if(status == 2)
        {
            if(phone_done)
            {
                //audio
                Debug.Log("status 2 phone done");
                alarm_hint.SetActive(false);
                file_hint.SetActive(false);
                phone_hint.SetActive(false);
                leave_hint.SetActive(true);
                status = 3;
            }
        }

	}
}
