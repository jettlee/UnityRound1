using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour {

	//private Vector3 destination = new Vector3 (-4.653f, 0.5104f, 0.122f); //public

	public Vector3 destination;
	public string keyName;

	void OnTriggerStay(Collider other) {// will it always run?
		if (other.gameObject.name == keyName && other.transform.parent == null) {
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			other.gameObject.transform.position = destination; //Vector3.Lerp()
		}
	}
}
