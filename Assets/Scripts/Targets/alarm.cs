using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : MonoBehaviour {

    public GameObject battery_1;
    public GameObject battery_2;
    public GameObject screen;
    public Material m;

    public HintManager hint;

    private static AudioSource audioSource;
    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {

        if(battery_1.activeSelf && battery_2.activeSelf)
        {
            hint.alarm_done = true;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "battery1" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject battery_1 = GameObject.Find("battery_1");
            battery_1.SetActive(true);
            AudioClip audioClip = Resources.Load<AudioClip>("pickup");
            audioSource.clip = audioClip;
        }
        if (other.gameObject.name == "battery2" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject battery_2 = GameObject.Find("battery_2");
            battery_2.SetActive(true);
            AudioClip audioClip = Resources.Load<AudioClip>("pickup");
            audioSource.clip = audioClip;
        }

        if (battery_1.activeSelf && battery_2.activeSelf)
        {
            AudioClip audioClip = Resources.Load<AudioClip>("alarmclock");
            audioSource.clip = audioClip;

            screen.GetComponent<Renderer>().material = m;
        }
    }
}
