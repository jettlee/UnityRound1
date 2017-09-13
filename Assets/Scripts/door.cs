using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public GameObject w1;
    public GameObject w2;
    public GameObject w3;

    public GameObject file;

    // Use this for initialization
    void Start () {
        



    }
	
	// Update is called once per frame
	void Update () {
        if(w1.GetComponent<test>().num == 3 && w1.GetComponent<test>().num == 3 && w1.GetComponent<test>().num == 3 )
        {
           // GameObject file = GameObject.Find("importantFile");
            file.SetActive(true);
            gameObject.SetActive(false);
        }

	}


}
