using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : MonoBehaviour {

    public GameObject battery_1;
    public GameObject battery_2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "battery1" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject battery_1 = GameObject.Find("battery_1");
            battery_1.SetActive(true);
        }
        if (other.gameObject.name == "battery2" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            //GameObject battery_2 = GameObject.Find("battery_2");
            battery_2.SetActive(true);
        }
    }
}
