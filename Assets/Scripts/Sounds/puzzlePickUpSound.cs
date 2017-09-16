using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlePickUpSound : MonoBehaviour {

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


    //private void OnTriggerStay(Collider other)
    //{
    //    if (!hasPick && (ControllerGrabObject.collidingObject.name == "code2" || ControllerGrabObject.collidingObject.name == "code3" ||
    //        ControllerGrabObject.collidingObject.name == "code4" || ControllerGrabObject.collidingObject.name == "code1"))
    //    {
    //        hasPick = true;
    //        AudioClip audioClip = Resources.Load<AudioClip>("pickuppuzzle");
    //        audioSource.clip = audioClip;
    //        audioSource.Play();
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    hasPick = false;
    //}

}
