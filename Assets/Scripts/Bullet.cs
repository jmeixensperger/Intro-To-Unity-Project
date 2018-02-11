using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    private Transform mypos;
    private Transform camerapos;
    public GameObject cam;
    public float speed;

	// Use this for initialization
	void Start () {
        camerapos = cam.transform;
        mypos = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        var moveAmount = speed * Time.deltaTime;
        mypos.position = Vector3.MoveTowards(mypos.position, camerapos.position, moveAmount);
    }

}
