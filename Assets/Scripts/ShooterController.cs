using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour {

    public UIController gui;
    public Shooter[] shooters;
    private float delayTime;
    private float timeTaken;
    private bool active;
    private int score;
	public AudioClip LightsabreOff;

    // Use this for initialization
    void Start () {
        active = false;
        score = 0;
        delayTime = 8.0f;
    }

	// Update is called once per frame
	void Update () {
        // check delay time for next bullet's fire time
        timeTaken += Time.deltaTime;
        if (active && timeTaken > delayTime)
        {
            int index = Random.Range(0, shooters.Length);
            bool didFire = shooters[index].Fire();
            while (!didFire)
            {
                index = Random.Range(0, shooters.Length - 1);
                didFire = shooters[index].Fire();
            }
            timeTaken = 0;
        }
        // re-calculate delayTime based on score (increment every 3 blocks)
        if (score >= 3 && delayTime > 1.1f)
        {
            delayTime = delayTime * 0.8f;
            Debug.Log("delayTime reduced to: " + delayTime.ToString());
            if (delayTime < 1.1f)
                Debug.Log("Minimum delayTime reached for 5 shooters.");
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
		AudioSource.PlayClipAtPoint (LightsabreOff, new Vector3 (0, 0, 5));
        for (int i = 0; i < shooters.Length; i++)
            shooters[i].bullet.Deactivate();
	}
}
