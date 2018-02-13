using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlane : MonoBehaviour {
	GameObject gameObject;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
		Color newColor = new Color (230, 30, 20, 1);
		MeshRenderer gameObjectRenderer = gameObject.GetComponent<MeshRenderer> ();
		Material newMaterial = new Material(Shader.Find("Assets/Art/Materials/RedLines"));
		newMaterial.color = newColor;
		gameObjectRenderer.material = newMaterial;
	}	
}
