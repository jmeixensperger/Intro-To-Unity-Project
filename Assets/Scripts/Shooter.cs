using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shooter : MonoBehaviour {

    public Bullet bullet;
	public AudioClip shootSound;
	public float volume = 1.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    // Make the bullet visible and begin its movement towards the player
    public bool Fire() {
		AudioSource.PlayClipAtPoint (shootSound, new Vector3(0,0,15));
        if (bullet.isActiveAndEnabled)
            return false;
        bullet.gameObject.SetActive(true);
        return true;
    }
}
