using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockKeyhole : MonoBehaviour {

	public GameObject clockKey;
	public Clock left;
	public Clock right;

    private GameObject clockInterface;
    public static bool isActive = false;
    public Material texture12;
    public GameObject hint;

    Animator animator;

    private static AudioSource audioSource;

    private void Awake()
    {
        animator = GameObject.Find("timeClock").GetComponent<Animator>();
        clockInterface = GameObject.Find("TimeClockInterface");
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
            animator.SetBool("activation", true);
            StartCoroutine(waitAndActive());


            //         left.isActive = true;
            //right.isActive = true;
            //         hint.SetActive(true);
            //         clock.GetComponent<Renderer>().material = texture12;
            //         isActive = true;

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

    IEnumerator waitAndActive() 
    {
        yield return new WaitForSeconds(5);
        animator.SetBool("activation", false);
        animator.StopPlayback();
        yield return new WaitForSeconds(3);
        animator.enabled = false;
        left.isActive = true;
        right.isActive = true;
        hint.SetActive(true);
        clockInterface.GetComponent<Renderer>().material = texture12;
        isActive = true;
    }
}
