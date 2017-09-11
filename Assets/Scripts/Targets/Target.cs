using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

	public Vector3 dest_pos;
	public Vector3 dest_rot;
	public string keyName;

	void OnTriggerStay(Collider other) {// will it always run?
		if (other.gameObject.name == keyName && other.transform.parent == null) {
			other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
			other.gameObject.transform.position = dest_pos; //Vector3.Lerp()
			other.gameObject.transform.eulerAngles = dest_rot;
		}
	}
}
