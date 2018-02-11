using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform shooterpos;
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "PlayerPlane")
        {
            Debug.Log("You've been hit!");
        }
        else if (collision.gameObject.name == "lightsaber")
        {
            Debug.Log("Nice block!");
        }
        mypos.position = Vector3.MoveTowards(mypos.position, shooterpos.position, 100000);
    }

}
