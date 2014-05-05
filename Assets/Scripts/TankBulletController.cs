using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class TankBulletController : MonoBehaviour {
    public AudioClip explodeSound;
	// Use this for initialization
	void Start () {
        //explodeSound = Resources.Load("explode.mp3") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up * 0.2f;
	}

    void OnTriggerEnter2D(Collider2D c) {
        if (c.collider2D.gameObject.name == "invader") {
            c.collider2D.gameObject.SetActive(false); // deactivate instead of destroy so you could later reactivate (respawn) him
            this.gameObject.SetActive(false);
            audio.Play();
        }
        
        //audio.PlayOneShot(explodeSound, 1.0f);
        //Debug.Log(c.collider2D.gameObject.name);
        //this.gameObject.SetActive(false);
    }

}
