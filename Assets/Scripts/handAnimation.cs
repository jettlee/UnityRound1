using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handAnimation : MonoBehaviour {

    Animator anim;
    private static string CLOCK_TAG = "Clock";
    private static string KEY_TAG = "Key";
    private static string DOOR_TAG = "Door";
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == KEY_TAG || other.tag == DOOR_TAG)
        {
            anim.SetBool("holdOBJ", true);
        }

        if (other.tag == CLOCK_TAG)
        {
            anim.SetBool("pointAtClock", true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("holdOBJ", false);
        anim.SetBool("pointAtClock", false);
    }
}
