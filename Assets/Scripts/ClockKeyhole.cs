using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockKeyhole : MonoBehaviour {

	public GameObject clockKey;
	public Clock left;
	public Clock right;

    private static AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void OnTriggerStay(Collider other)
	{
		if (other.gameObject.name == "TimeClock-springKey" && other.transform.parent == null)
		{
			other.gameObject.SetActive(false);
			clockKey.SetActive(true);

            StartCoroutine(Rotate());
            AudioClip audioClip = Resources.Load<AudioClip>("activateclock");
            audioSource.clip = audioClip;
            audioSource.Play();

            left.isActive = true;
			right.isActive = true;

        }

	}

    IEnumerator Rotate()
    {
        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(new Vector3(-1, 0, 0));
            yield return 0;
        }
    }
}
