using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frame : MonoBehaviour {

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;

    private static AudioSource audioSource;

    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClip = Resources.Load<AudioClip>("putdownpuzzle");
        audioSource.clip = audioClip;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "code1" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject p1 = GameObject.Find("codePiece1");
            p1.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.name == "code2" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject p2 = GameObject.Find("codePiece2");
            p2.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.name == "code3" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject p3 = GameObject.Find("codePiece3");
            p3.SetActive(true);
            audioSource.Play();
        }
        if (other.gameObject.name == "code4" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject p4 = GameObject.Find("codePiece4");
            p4.SetActive(true);
            audioSource.Play();
        }
    }
}
