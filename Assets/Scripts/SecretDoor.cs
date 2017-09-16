using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor: MonoBehaviour {

	public float min;
	public float max;

    private static AudioSource audioSource;
	private static AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("secretdoor");
        audioSource.clip = audioClip;
    }

    void Update () {
		//transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, min, max));
		transform.rotation = new Quaternion(transform.rotation.x,
			transform.rotation.y,
			Mathf.Clamp(transform.position.z, min, max),
			transform.rotation.w);
		audioSource.PlayOneShot(audioSource.clip);
	}
}
