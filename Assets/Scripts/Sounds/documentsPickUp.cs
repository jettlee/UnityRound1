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
        if (ControllerGrabObject.collidingObject.name == "prototype002" || ControllerGrabObject.collidingObject.name == "backUp" ||
     ControllerGrabObject.collidingObject.name == "prototype001" || ControllerGrabObject.collidingObject.name == "theoryOfTime" || ControllerGrabObject.collidingObject.name == "importantFile")
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
