using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class TankGunController : MonoBehaviour {
    public Object bullet;
    public AudioClip fireSound;
	// Use this for initialization
	void Start () {
        //bullet = Instantiate(GameObject.Find("tankBullet"), transform.position, transform.rotation);
        bullet = GameObject.Find("tankBullet");
        //fireSound = Resources.Load("laser.mp3") as AudioClip;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fire() {
        //GameObject newBullet = new GameObject("bullet" + this.transform.position.x.ToString());
        //newBullet.transform.position = this.transform.position;
        //newBullet.gameObject.SetActive(true);
        Object newBullet = Instantiate(bullet, transform.position, transform.rotation);
        (newBullet as GameObject).AddComponent<TankBulletController>();
        //audio.PlayOneShot(fireSound,1.0f);
        audio.Play();
    }
}
