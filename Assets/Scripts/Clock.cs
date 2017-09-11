using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{


	private GameObject player;
	private float px;
	bool in_range = false;

	public int direction;


	private SteamVR_TrackedObject trackedObj;

	private SteamVR_Controller.Device Controller {
		get { return SteamVR_Controller.Input ((int)trackedObj.index); }
	}

	void Awake ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		player = GameObject.Find ("VR");
		px = player.transform.position.x;
	}

	void Update ()
	{

		if (in_range) {
			if (Controller.GetHairTriggerDown ()) {
				//Debug.Log (gameObject.name + " Trigger Press");
				if (direction == -1) { //back
					if (px > 0)
						px -= 5f;
				} else { //forward
					if (px < 15)
						px += 5f;
				}

				player.transform.position = new Vector3 (px, 0f, -0.3f);

			}
		}
	
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Clock")
			in_range = true;
	}

	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "Clock")
			in_range = false;
	}
		

}
