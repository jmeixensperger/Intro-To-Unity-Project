using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {

	public GameObject lifeSquare1;
	public GameObject lifeSquare2;
	public GameObject lifeSquare3;
	private int count;
	public ShooterController shooterController;

	void Start() {
		count = 0;
	}

	public int getCount() {
		return count;
	}

	public void changeColor1(Material mat) {
		lifeSquare1.GetComponent<Renderer> ().material = mat;
		count += 1;
	}

	public void changeColor2(Material mat) {
		lifeSquare2.GetComponent<Renderer> ().material = mat;
		count += 1;
	}

	public void changeColor3(Material mat) {
		lifeSquare3.GetComponent<Renderer> ().material = mat;
		count += 1;
		shooterController.StopShooting ();
        GameObject handle = GameObject.Find("handle");
        handle.GetComponent<AudioSource>().Stop();
	}
}
