using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public AudioClip blockSound;
    public Transform shooterpos;
    public Transform camerapos;
    private Transform mypos;
    private float speed;
    private bool hasCollided;
	public UIController gui;
	public Material material;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        mypos = this.transform;
        speed = 20.0f;
	}
	
	// Update is called once per frame
	void Update () {
        var moveAmount = speed * Time.deltaTime;
        if (isActiveAndEnabled && !hasCollided)
            mypos.position = Vector3.MoveTowards(mypos.position, camerapos.position, moveAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
        if (collision.gameObject.name == "PlayerPlane")
        {
            Debug.Log("You've been hit!");
            if (gui.getCurrentHealth() < gui.getMaxHealth())
                gui.changeColor();
        }
        else if (collision.gameObject.name == "outside saber")
        {
            Debug.Log("Nice block!");
            AudioSource.PlayClipAtPoint(blockSound, mypos.position);
            gui.incrementScore();
        }
        // move bullet back to shooter position and de-activate (make invisible)
        mypos.position = Vector3.MoveTowards(mypos.position, shooterpos.position, 100000);
        gameObject.SetActive(false);
        hasCollided = false;
    }

}
