using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {

    public UIController gui;
    public Shooter[] shooters;
    public float delayTime;
    private float timeTaken;
    private bool active;
    private int score;

    // Use this for initialization
    void Start () {
        active = false;
        score = 0;
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
        // re-calculate delayTime based on score (increment every 5 blocks)
        if (score >= 5)
        {
            delayTime = delayTime * 0.75f;
            Debug.Log("delayTime reduced to: " + delayTime.ToString());
            score = 0;
        }
	}

    public void incrementScore()
    {
        score++;
    }

    public bool isActive() {
        return active;
    }

    // Bullets will only fire when the controller is "active"
    public void StartShooting() {
        active = true;
    }

	public void StopShooting() {
		active = false;
	}
}
