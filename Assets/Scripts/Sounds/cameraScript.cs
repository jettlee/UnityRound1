using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    public static UnityStandardAssets.ImageEffects.ColorCorrectionCurves script;

    // Use this for initialization
    void Awake () {
        script = GetComponent<UnityStandardAssets.ImageEffects.ColorCorrectionCurves>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
