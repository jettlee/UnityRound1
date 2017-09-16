using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSound : MonoBehaviour {

    private GameObject player;
    private Vector3 currentPos;
    private Vector3 nextPos;
    private static AudioSource audioSource;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("VR");
        currentPos = player.transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        nextPos = player.transform.position;
        if (nextPos != currentPos && !audioSource.isPlaying)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("footstep");
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
}
