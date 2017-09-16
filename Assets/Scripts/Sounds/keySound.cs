using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keySound : MonoBehaviour {

    private static AudioSource audioSource;
    private bool hasPlay = false;
    // Use this for initialization
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClip = Resources.Load<AudioClip>("key");
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("onCollision");
		if (ControllerGrabObject.objectInHand.name == "TimeClock-springKey" || ControllerGrabObject.objectInHand.name == "key" && !hasPlay)
        {
            Debug.Log(ControllerGrabObject.collidingObject.name);
            Debug.Log("inCollision");
            hasPlay = true;
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hasPlay = false;
    }

}

