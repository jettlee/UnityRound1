using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(-0.3f, 0.75f,
			Mathf.Clamp(transform.position.z, 0.6F, 1F));
       
		
	}
}
