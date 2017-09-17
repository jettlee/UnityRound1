using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
	public bool isActive;
	public static bool clockDone = false;
	public static int time = 12;

    private GameObject player;
    private GameObject clock;
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
        clock = GameObject.FindGameObjectWithTag("Clock");
        px = player.transform.position.x;
    }

    void Update()
    {
		if (isActive) {
			if (in_range) {
				if (Controller.GetHairTriggerDown ()) {
					//Debug.Log (gameObject.name + " Trigger Press");
					Debug.Log ("trigger");
					px = player.transform.position.x;
					if (direction == -1) { //back
						Debug.Log ("back");
						Debug.Log (px);
						if (px > 0f || HintManager.status != 3) { //make sure when status == 3, guest can't travel back
                            
							clockSound.playClockRotateSound ();
							StartCoroutine (backMinRotate ());
							StartCoroutine (backHourRotate ());
							px -= 5f;
							time--;
                            if (px <= 17f)
                            {
                                playerSound.playBackBGM();
                                cameraScript.script.saturation = 0.12f;
                            }
                            Debug.Log (px);
                            clock.transform.parent = player.transform;
                            player.transform.position = new Vector3 (px, 0f, -0.3f);
						}

					} else if (direction == 1) { //forward
						Debug.Log ("for");

						if (px < 20f) {
                            
							clockSound.playClockRotateSound ();
							StartCoroutine (forMinRotate ());
							StartCoroutine (forHourRotate ());
							time++;
							if (HintManager.status != 3) 
							{
								px += 5f;
							}

							if (px > 16f || HintManager.status == 3)
                            {
								cameraScript.script.saturation = 1.0f;

								if (HintManager.status != 3)
								{
									playerSound.playMurderBGM();
								}
                                
								if (HintManager.status == 3) 
								{
									clockDone = true;
								}

                            }
                            Debug.Log (px);
                            clock.transform.parent = player.transform;
                            player.transform.position = new Vector3 (px, 0f, -0.3f);
						}

					}
                    //Debug.Log(px);
                   
                   // clock.transform.position = new Vector3(px, clock.transform.position.y, clock.transform.position.z);

                }
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
