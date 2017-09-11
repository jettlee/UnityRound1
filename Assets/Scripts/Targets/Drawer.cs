using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour {

	public bool isLocked;
	public float min;
	public float max;

	void Update () {
		if (isLocked) {
			transform.position = new Vector3 (5.31041f, 0.7175128f, 1.316191f);
		} else {
			transform.position = new Vector3(5.31041f,0.7175128f,Mathf.Clamp(transform.position.z, min, max));
		}
			
	}
}
