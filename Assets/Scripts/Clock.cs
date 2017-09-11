using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{


    private GameObject player;
    private float px;
    bool in_range = false;
    public GameObject minHand;
    public GameObject hourHand;

    public int direction;


    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        player = GameObject.Find("VR");
        px = player.transform.position.x;
    }

    void Update()
    {
        if (in_range)
        {
            if (Controller.GetHairTriggerDown())
            {
                //Debug.Log (gameObject.name + " Trigger Press");
                Debug.Log("trigger");
                px = player.transform.position.x;
                if (direction == -1)
                { //back
                    Debug.Log("back");
                    Debug.Log(px);
                    if (px > 0f)
                    {
                        StartCoroutine(backMinRotate());
                        StartCoroutine(backHourRotate());
                        px -= 5f;
                        Debug.Log(px);
                        player.transform.position = new Vector3(px, 0f, -0.3f);
                    }

                }
                else if (direction == 1)
                { //forward
                    Debug.Log("for");

                    if (px < 15f)
                    {
                        StartCoroutine(forMinRotate());
                        StartCoroutine(forHourRotate());
                        px += 5f;
                        Debug.Log(px);
                        player.transform.position = new Vector3(px, 0f, -0.3f);
                    }

                }
                //Debug.Log(px);


            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Clock")
            in_range = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Clock")
            in_range = false;
    }

    IEnumerator forMinRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            minHand.transform.Rotate(new Vector3(-4, 0, 0));
            yield return 0;
        }
    }

    IEnumerator forHourRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            hourHand.transform.Rotate(new Vector3(-1 / 3f, 0, 0));
            yield return 0;
        }
    }

    IEnumerator backMinRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            minHand.transform.Rotate(new Vector3(4, 0, 0));
            yield return 0;
        }
    }

    IEnumerator backHourRotate()
    {
        for (int i = 0; i < 90; i++)
        {
            hourHand.transform.Rotate(new Vector3(1 / 3f, 0, 0));
            yield return 0;
        }
    }

}
