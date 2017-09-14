using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {


	private const string CLOCK_TAG = "Clock";
	public static bool clockRotate = false;
	private SteamVR_TrackedObject trackedObj;
	private Quaternion currentMinQ;
	private Quaternion firstMinQ;
	private Quaternion currentHourQ;
	private Quaternion firstHourQ;
	public float speed = 1.0f;
	private bool initialRotate = false;

	private GameObject player;
//    private float px;


	private GameObject collidingObject;
	private GameObject objectInHand;

	private SteamVR_Controller.Device Controller
	{
		get{ return SteamVR_Controller.Input ((int)trackedObj.index);}
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		player = GameObject.Find("VR");
//		px = player.transform.position.x;
	}

	private void SetCollidingObject(Collider col)
	{	
		if (collidingObject || !col.GetComponent<Rigidbody> () || col.tag != "Key")
		{
			return;
		}
		collidingObject = col.gameObject;
	}

	void Update () {
		if (Controller.GetHairTriggerDown ()) {
			if (collidingObject) {
				GrabObject ();
			}
		}

		if (Controller.GetHairTriggerUp ()) {
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
        Debug.Log("grabing");
		//set objectinhand parent to player
		objectInHand.transform.parent = player.transform;
        Debug.Log(objectInHand.name);
        if (objectInHand.GetComponent<FixedJoint>())
        {
            Debug.Log("has joint");
            objectInHand.GetComponent<FixedJoint>().connectedBody = null;
            Destroy(objectInHand.GetComponent<FixedJoint>());
        }

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

			//objectInHand.GetComponent<Rigidbody> ().velocity = Controller.velocity;
			//objectInHand.GetComponent<Rigidbody> ().angularVelocity = Controller.angularVelocity;
		}

		//detach from parent
		objectInHand.transform.parent = null;
		objectInHand = null;
	}
		
}
