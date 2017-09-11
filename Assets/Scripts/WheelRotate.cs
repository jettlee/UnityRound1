using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotate : MonoBehaviour {

    public int current_number;
    //private int go_number;
    public float speed = 0.1F;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        //go_number = current_number;
    }
	
	//// Update is called once per frame
	void Update () {

        //transform.rotation = Quaternion.Lerp(transform.rotation, to.rotation, Time.time * speed);

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "Controller (right)" && Controller.GetHairTriggerDown())
        {

            current_number += 1;
            if(current_number > 7)
            {
                current_number = 0;
            }
        }
    }


}
