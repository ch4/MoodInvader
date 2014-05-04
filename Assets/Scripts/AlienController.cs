using UnityEngine;
using System.Collections;

public class AlienController : MonoBehaviour {

    TGCConnectionController controller;
    private int meditation1 = 0;
    private int tickRate = 1; // tens of milliseconds
    private int BASELINE_MEDITATION = 40;

	// Use this for initialization
	void Start () {
        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        controller.UpdateMeditationEvent += OnUpdateMeditation;
	}

    void OnUpdateMeditation(int value) {
        meditation1 = value;
        Invoke("MoveD", (0.1f * tickRate));
    }
	
	// Update is called once per frame
	void Update () {
        if (meditation1 < BASELINE_MEDITATION) {
            //speed up
            tickRate++;
        } else {
            //slow down
            tickRate--;
        }
	}

    void MoveLR(bool isRight) {

    }

    void MoveD() {
        transform.position -= transform.up * 1.0f;
    }
}
