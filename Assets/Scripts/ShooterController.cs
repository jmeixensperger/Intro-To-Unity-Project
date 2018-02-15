using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {

    public Shooter[] shooters;
    public float delayTime;
    private float timeTaken;
    private bool active;

	// Use this for initialization
	void Start () {
        active = false;
    }
	
	// Update is called once per frame
	void Update () {
        // check delay time for next bullet's fire time
        timeTaken += Time.deltaTime;
        if (active && timeTaken > delayTime)
        {
            int index = Random.Range(0, shooters.Length - 1);
            bool didFire = shooters[index].Fire();
            while (!didFire)
            {
                index = Random.Range(0, shooters.Length - 1);
                didFire = shooters[index].Fire();
            }
            timeTaken = 0;
        }
	}

    // Bullets will only fire when the controller is "active"
    public void StartShooting() {
        active = true;
    }

	public void StopShooting() {
		active = false;
	}
}
