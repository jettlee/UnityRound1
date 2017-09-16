using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drawerKeySound : MonoBehaviour {

    private static AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (ControllerGrabObject.collidingObject != null)
    //    {
    //        AudioClip audioClip = Resources.Load<AudioClip>("key");
    //        audioSource.clip = audioClip;
    //        audioSource.Play();
    //    }
   
    //}
}
