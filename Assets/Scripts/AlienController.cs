using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class AlienController : MonoBehaviour {
    public AudioClip explodeSound;
    TGCConnectionController controller;
    private int meditation1 = 0;
    private int tickRate = 900; 
    private int BASELINE_MEDITATION = 30;
    private bool directionIsRight = true; //start off moving right
    private int tickCount = 0;
    Object relaxText, hiText, lowText, midText, waitingText;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        controller.UpdateMeditationEvent += OnUpdateMeditation;
        InvokeRepeating("ScheduleTick", 0.01f, .25f);
        relaxText = GameObject.Find("relaxText");
        hiText = GameObject.Find("hiText");
        lowText = GameObject.Find("lowText");
        midText = GameObject.Find("midText");
        waitingText = GameObject.Find("waitingText");
        (relaxText as GameObject).SetActive(false);
        (hiText as GameObject).SetActive(false);
        (lowText as GameObject).SetActive(false);
	}

    void OnUpdateMeditation(int value) {
        meditation1 = value;
        //Invoke("MoveD", (0.1f * tickRate));
        if (meditation1 < BASELINE_MEDITATION) {
            //speed up
            tickRate+=500;
        } else {
            //slow down
            tickRate-=300;
        }
        if (meditation1 > 0) {
            (waitingText as GameObject).SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (meditation1 < BASELINE_MEDITATION) {
            //speed up
            tickRate++;
        } else {
            //slow down
            tickRate-=3;
        }
        (relaxText as GameObject).SetActive(tickRate > 1500);
        if (tickRate > 1250) {
            //GameObject.Find("hiText").SetActive(true);
            //GameObject.Find("lowText").SetActive(false);
            (hiText as GameObject).SetActive(true);
            (lowText as GameObject).SetActive(false);
            (midText as GameObject).SetActive(false);
        } else if (tickRate > 750) {
            //GameObject.Find("hiText").SetActive(false);
            //GameObject.Find("lowText").SetActive(true);
            (hiText as GameObject).SetActive(false);
            (lowText as GameObject).SetActive(false);
            (midText as GameObject).SetActive(true);
        } else {
            //GameObject.Find("hiText").SetActive(false);
            //GameObject.Find("lowText").SetActive(true);
            (hiText as GameObject).SetActive(false);
            (lowText as GameObject).SetActive(true);
            (midText as GameObject).SetActive(false);
        }
	}

    void ScheduleTick() {
        if (meditation1 < BASELINE_MEDITATION) {
            //speed up
            //tickRate--;
            Debug.Log("Speed up. Tickrate: " + tickRate.ToString());
        } else {
            //slow down
            //tickRate++;
            Debug.Log("Slow down. Tickrate: " + tickRate.ToString());
        }
        
        if (tickRate < 500) tickRate = 500;
        if (tickRate > 2000) tickRate = 2000;

        tickCount += (tickCount >= 65530 ? 0 : 1);

        //if (tickCount > 500) {
        //    if (tickCount % 3 == 0)
        //        Invoke("Move", (tickRate * 0.001f));
        //} else Invoke("Move", (tickRate * 0.001f));
        Move();
        
    }

    void Move() {
        if (directionIsRight) {
            transform.position += (transform.right * 0.001f * tickRate);
        } else {
            transform.position -= (transform.right * 0.001f * tickRate);
        }

        if (transform.position.x > 15) {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
            directionIsRight = false;
            MoveD();
        } else if (transform.position.x < -15) {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
            directionIsRight = true;
            MoveD();
        }
    }

    void MoveD() {
        transform.position -= transform.up * 1.0f;
    }
}
