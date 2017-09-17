using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endingTalk : MonoBehaviour {


	private float currentTime = 0.0f;
	public float waitTime = 5.0f;
	private static AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;

		if (currentTime > waitTime) 
		{
			//play conversation
		}
	}
}
