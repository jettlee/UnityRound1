using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSound : MonoBehaviour {

    private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        /*if (transform.position.x > 15 || transform.position.x <= 10)
        {
            audioSource.Stop();
        }

        if(transform.position.x == 15)
        {
            audioSource.Play();
        }*/
	}
}
