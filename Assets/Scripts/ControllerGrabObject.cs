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

	[SerializeField]
	private GameObject hourPiv;

	[SerializeField]
	private GameObject minPiv;

	private GameObject collidingObject;
	private GameObject objectInHand;

	private SteamVR_Controller.Device Controller
	{
		get{ return SteamVR_Controller.Input ((int)trackedObj.index);}
	}

	void Awake()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		hourPiv = GetComponent<GameObject> ();
		minPiv = GetComponent<GameObject> ();
        
	}

	private void SetCollidingObject(Collider col)
	{	
		if (col.tag == CLOCK_TAG) 
		{
			clockRotate = true;
		}
		if (collidingObject || !col.GetComponent<Rigidbody> () || col.tag == CLOCK_TAG)
		{
			return;
		}

		collidingObject = col.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Controller.GetHairTriggerDown ()) {
			if (collidingObject) {
				GrabObject ();
			}

			if (clockRotate) 
			{	
				currentHourQ = hourPiv.transform.rotation;
				currentMinQ = minPiv.transform.rotation;
				if (!initialRotate) 
				{
					firstMinQ = currentMinQ;
					firstHourQ = currentHourQ;	
					initialRotate = true;
				}

				StartCoroutine(startRotate (currentMinQ, currentHourQ));
			}
				
		}

		if (Controller.GetHairTriggerUp ()) {
			if (objectInHand) {
				ReleaseObject ();
			}

			if (clockRotate) 
			{
				StartCoroutine (releaseRotate ());
				clockRotate = false;
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


	IEnumerator startRotate(Quaternion currentMinRotation, Quaternion currentHourRotation)
	{

		Quaternion controllerQ = trackedObj.transform.rotation;
		Quaternion minTargetRotation = Quaternion.Euler(controllerQ.x - currentMinRotation.x, controllerQ.y - currentMinRotation.y, controllerQ.z - currentMinRotation.z);
		Quaternion hourTargetRotation = Quaternion.Euler ((controllerQ.x - currentMinRotation.x) / 12, (controllerQ.y - currentMinRotation.y) / 12, (controllerQ.z - currentMinRotation.z) / 12);
		minPiv.transform.rotation = Quaternion.Lerp (currentMinRotation, minTargetRotation, Time.deltaTime * speed);
		hourPiv.transform.rotation = Quaternion.Lerp (currentHourRotation, hourTargetRotation, Time.deltaTime * speed);
		currentMinQ = controllerQ;

		yield return 0;

	}

	IEnumerator releaseRotate()
	{
		initialRotate = false;
		Quaternion lastQ = trackedObj.transform.rotation;
		if (lastQ.x - firstMinQ.x > 180) {
			minPiv.transform.rotation = Quaternion.Lerp (minPiv.transform.rotation, firstMinQ, Time.deltaTime * speed);
			hourPiv.transform.rotation = Quaternion.Lerp (hourPiv.transform.rotation, firstHourQ, Time.deltaTime * speed);

		} else 
		{
			Quaternion minTargetRotation = Quaternion.Euler (-360, -360, -360);
			Quaternion hourTargetRotation = Quaternion.Euler (firstHourQ.x - 30, firstHourQ.y, firstHourQ.z);
			minPiv.transform.rotation = Quaternion.Lerp (minPiv.transform.rotation, minTargetRotation, Time.deltaTime * speed);
			hourPiv.transform.rotation = Quaternion.Lerp (hourPiv.transform.rotation, hourTargetRotation, Time.deltaTime * speed);
		}

		yield return 0;
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
