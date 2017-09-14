﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyhole : MonoBehaviour {
    public GameObject key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "key" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject key = GameObject.Find("key_in_hole");
            key.SetActive(true);
            GameObject drawer = GameObject.Find("drawer_withKeyHole");
            Drawer d = drawer.GetComponent<Drawer>();


            //rotate:
            StartCoroutine(Rotate());

            d.isLocked = false;

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
