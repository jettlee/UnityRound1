﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hint1 : MonoBehaviour {

    private static AudioSource audioSource;
    private bool hasHint = false;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!hasHint)
        {
            hasHint = true;
            audioSource.Play();
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        hasHint = false;
    }
}
