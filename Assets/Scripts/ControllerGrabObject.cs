using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrabObject : MonoBehaviour {


	public static bool clockRotate = false;
	private SteamVR_TrackedObject trackedObj;
    public static bool doorLock = false;
    public static bool inDoorArea = false;


	private GameObject player;
//    private float px;


	public static GameObject collidingObject;
	public static GameObject objectInHand;

	private SteamVR_Controller.Device Controller
	{
		get{ return SteamVR_Controller.Input ((int)trackedObj.index);}
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		player = GameObject.Find("VR");

	}

	private void SetCollidingObject(Collider col)
	{	
		if (collidingObject || !col.GetComponent<Rigidbody>())
		{
			return;
		}
		collidingObject = col.gameObject;
	}

	void Update () {
		if (Controller.GetHairTriggerDown ()) {
            if(inDoorArea)
            {
                doorLock = true;
            }
			if (collidingObject) {
				GrabObject ();
			}
		}

		if (Controller.GetHairTriggerUp ()) {
            doorLock = false;
			if (objectInHand) {
				ReleaseObject ();
			}
		
		}
	}

	public void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Door")
        {
            inDoorArea = true;
        }
		SetCollidingObject (other);
	}

	public void OnTriggerStay(Collider other)
	{
        if (other.tag == "Door")
        {
            inDoorArea = true;
        }
        SetCollidingObject (other);
	}

	public void OnTriggerExit(Collider other)
	{
		if (!collidingObject) 
		{
			return;
		}

        if (inDoorArea)
        {
            inDoorArea = false;
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
        if (objectInHand.name == "battery2")
        {
            Destroy(objectInHand.GetComponent<FixedJoint>());
        }

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
