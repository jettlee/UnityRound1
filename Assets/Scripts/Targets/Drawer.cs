using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	public bool isLocked;
    public GameObject battery2;
	public float min;
	public float max;


    private static AudioSource audioSource;
	private AudioClip audioClip;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioClip = Resources.Load<AudioClip>("opendrawer");
        audioSource.clip = audioClip;

    }

    void Update () {
		if (isLocked) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 1.316191f);
		} else {
            battery2.transform.parent = this.transform;
			transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, min, max));
			audioSource.PlayOneShot (audioSource.clip);
		}
			
	}
		
}
