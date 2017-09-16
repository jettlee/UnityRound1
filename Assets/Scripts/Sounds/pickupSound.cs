using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupSound : MonoBehaviour {

    private static AudioSource audioSource;
    private bool hasPick = false;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
		if (!hasPick && ControllerGrabObject.objectInHand.name == "myPhone" || ControllerGrabObject.objectInHand.name == "battery1" || ControllerGrabObject.objectInHand.name == "battery2")
        {
            hasPick = true;
            AudioClip audioClip = Resources.Load<AudioClip>("pickup");
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasPick = false;
    }

}
