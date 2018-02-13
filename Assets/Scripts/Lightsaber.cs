using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightsaber : MonoBehaviour {

    public AudioSource blockSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet")
        {
            blockSound.Play();
            // animation? sparks
			var exp = GetComponent<ParticleSystem>();
			exp.Play ();
			Destroy(collision.gameObject);
        }
    }
}
