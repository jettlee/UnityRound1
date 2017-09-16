using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phone : MonoBehaviour {

    // Use this for initialization

    public HintManager hint;

    //void Awake () {
    //       hint.phone_done = true;

    //}

    private void Update()
    {
        if(gameObject.activeSelf)
        {
            hint.phone_done = true;
        }
    }

}
