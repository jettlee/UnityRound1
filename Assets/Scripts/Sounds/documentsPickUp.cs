using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class documentsPickUp : MonoBehaviour {

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
		if (!hasPick && ControllerGrabObject.objectInHand.name == "prototype002" || ControllerGrabObject.objectInHand.name == "backUp" ||
			ControllerGrabObject.objectInHand.name == "prototype001" || ControllerGrabObject.objectInHand.name == "theoryOfTime" || ControllerGrabObject.objectInHand.name == "importantFile")
        {
            hasPick = true;
            AudioClip audioClip = Resources.Load<AudioClip>("documents");
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasPick = false;
    }
}
