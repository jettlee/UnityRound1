﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {

    public static bool hasTrigger = false;
    private const string CLOCK_TAG = "Clock";
	private SteamVR_TrackedObject trackedObj;

	private bool initialRotate = false;


	private GameObject collidingObject;
	private GameObject objectInHand;

	private SteamVR_Controller.Device Controller
	{
		get{ return SteamVR_Controller.Input ((int)trackedObj.index);}
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	}

	private void SetCollidingObject(Collider col)
	{	
	
		if (collidingObject || !col.GetComponent<Rigidbody> () || col.tag == CLOCK_TAG)
		{
			return;
		}

		collidingObject = col.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown ()) {
            hasTrigger = true;
			if (collidingObject) {
				GrabObject ();
			}
				
		}

		if (Controller.GetHairTriggerUp ()) {
            hasTrigger = false;
			if (objectInHand) {
				ReleaseObject ();
			}
		}
	}

	public void OnTriggerEnter(Collider other)
	{
		SetCollidingObject (other);
	}

	public void OnTriggerStay(Collider other)
	{
		SetCollidingObject (other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject) 
		{
			return;
		}

		collidingObject = null;
	}


	private void GrabObject()
	{
		objectInHand = collidingObject;
		collidingObject = null;

		var joint = AddFixedJoint ();
		joint.connectedBody = objectInHand.GetComponent<Rigidbody> ();
	}

	private FixedJoint AddFixedJoint()
	{
		FixedJoint fx = gameObject.AddComponent<FixedJoint> ();
		fx.breakForce = 20000;
		fx.breakTorque = 20000;
		return fx;
	}

	private void ReleaseObject()
	{
		if (GetComponent<FixedJoint> ())
		{
			GetComponent<FixedJoint> ().connectedBody = null;
			Destroy (GetComponent<FixedJoint> ());

			objectInHand.GetComponent<Rigidbody> ().velocity = Controller.velocity;
			objectInHand.GetComponent<Rigidbody> ().angularVelocity = Controller.angularVelocity;
		}

		objectInHand = null;
	}
		
}
