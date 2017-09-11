using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSound : MonoBehaviour {

    private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    public static void playClockRotateSound()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("Clockgears");
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    public static void playRoomChangeSound()
    {
        AudioClip audioClip = Resources.Load<AudioClip>("timetravel_shortened");
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
