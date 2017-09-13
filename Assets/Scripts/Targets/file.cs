using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class file : MonoBehaviour {

    public GameObject importantfile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "importantFile" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject file = GameObject.Find("importantFile_in");
            importantfile.SetActive(true);
        }
        
    }
}
