using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour {

	public GameObject lifeSquare1;
	public GameObject lifeSquare2;
	public GameObject lifeSquare3;

	public void changeColor1(Material mat) {
		lifeSquare1.GetComponent<Renderer> ().material = mat;
	}

	public void changeColor2(Material mat) {
		lifeSquare2.GetComponent<Renderer> ().material = mat;
	}

	public void changeColor3(Material mat) {
		lifeSquare3.GetComponent<Renderer> ().material = mat;
	}
}
