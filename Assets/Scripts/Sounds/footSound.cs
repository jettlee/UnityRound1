using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSound : MonoBehaviour {

    private GameObject player;
    private Vector3 currentPos;
    private Vector3 nextPos;
    private static AudioSource audioSource;
	private static AudioClip audioClip;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("VR");
        currentPos = player.transform.position;
        audioSource = GetComponent<AudioSource>();
		audioClip = Resources.Load<AudioClip>("footstep");
    }

    // Update is called once per frame
    void Update()
    {
   
    }

	void FixedUpdate()
	{
		nextPos = player.transform.position;
		if (nextPos != currentPos && !audioSource.isPlaying) 
		{
			audioSource.clip = audioClip;
			audioSource.PlayOneShot (audioSource.clip);
		}
		currentPos = nextPos;
	}
}
