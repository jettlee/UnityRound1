using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeController : MonoBehaviour {

	public GameObject controllerLeft;
	public GameObject controllerRight;
	// Use this for initialization
	void Awake () {
		controllerLeft.SetActive (true);
		controllerRight.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
