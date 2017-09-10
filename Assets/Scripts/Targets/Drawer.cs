using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3(-0.02434119f,0f,
			Mathf.Clamp(transform.position.y, -0.006F, -0.005F));
		
	}
}
