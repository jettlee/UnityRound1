using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static AudioSource audioGears;

    // Use this for initialization
    void Start()
    {
        audioGears.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ControllerGrabObject.clockRotate)
        {
            AudioClip audioClipgears = Resources.Load<AudioClip>("Clockgears");
            audioGears.clip = audioClipgears;
            audioGears.Play();
        }
    }
}
