using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public Wheel w1;
    public Wheel w2;
    public Wheel w3;

    public GameObject file;
    private static AudioSource audioSource;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        AudioClip audioClip = Resources.Load<AudioClip>("opensafebox");
        audioSource.clip = audioClip;
    }

    void Update () {
        if(w1.num == 3 && w2.num == 3 && w3.num == 3 )
        {
            file.SetActive(true);
            anim.SetTrigger("open");
            w1.num = w2.num = w3.num = 0;
            audioSource.Play();
            //gameObject.SetActive(false);
        }

	}


}
