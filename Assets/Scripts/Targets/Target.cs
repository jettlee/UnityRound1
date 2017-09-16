using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public GameObject phone;

    public HintManager hint;

    private void Update()
    {
        if (phone.activeSelf)
        {
            hint.phone_done = true;
        }
    }

    void OnTriggerStay(Collider other) {// will it always run?
        if (other.gameObject.name == "myPhone" && other.transform.parent == null)
        {
            other.gameObject.SetActive(false);
            phone.SetActive(true);
        }
    }
}
