using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifebar : MonoBehaviour {

	public GameObject lifeSquare1;
	public GameObject lifeSquare2;
	public GameObject lifeSquare3;
	/*public Material[] material;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer> ();
		renderer.enabled = true;
		renderer.sharedMaterial = material [1];
	}
	
	// Update is called once per frame
	void Update () {
		renderer.sharedMaterial = material [2];
	}*/

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
