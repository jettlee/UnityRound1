﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretDoor: MonoBehaviour {

	public float min;
	public float max;

    private void Awake()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    void Update () {
		//transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, min, max));
		transform.rotation = new Quaternion(transform.rotation.x,
			transform.rotation.y,
			Mathf.Clamp(transform.position.z, min, max),
			transform.rotation.w);

	}
}
