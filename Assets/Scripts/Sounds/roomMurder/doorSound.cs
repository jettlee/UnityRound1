using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorSound : MonoBehaviour {

    private static AudioSource audioSource;
    // Use this for initialization
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClip = Resources.Load<AudioClip>("doorclose");
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("door trigger");
        if (ControllerGrabObject.doorLock)
        {
            Debug.Log("in door trigger");
            audioSource.Play();
        }
    }

}
