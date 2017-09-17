using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockTextureChange : MonoBehaviour {

	public Material texture12;
	public Material texture11;
	public Material texture10;
	public Material texture9;
	public Material texture8;
	private int time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		time = Clock.time;

		if (time == 12) 
		{
			//load texture12;
			//gameobject.GetComponent<Renderer>().material = texture12;
		} else if (time == 11) 
		{
			//load texture11;
		} else if (time == 10) 
		{
			//load texture10;
		} else if (time == 9)
		{
			//load texture9;
		} else if (time == 8)
		{
			//load texture8;
		}
	}
}
