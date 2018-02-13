using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    public Bullet bullet;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
    }

    // Make the bullet visible and begin its movement towards the player
    public bool Fire() {
        if (bullet.isActiveAndEnabled)
            return false;
        bullet.gameObject.SetActive(true);
        return true;
    }
}
