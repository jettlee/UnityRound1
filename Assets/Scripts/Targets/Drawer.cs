using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	public bool isLocked;
	public float min;
	public float max;

	void Update () {
		if (isLocked) {
			transform.position = new Vector3 (transform.position.x, transform.position.y, 1.316191f);
		} else {
			transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, min, max));
		}
			
	}
}
