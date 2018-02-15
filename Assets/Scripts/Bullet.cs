using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public AudioSource blockSound;
    public Transform shooterpos;
    public Transform camerapos;
    private Transform mypos;
    public float speed;
    private bool hasCollided;
	public Lifebar lifeBar; 
	public Material material;
	public int count = 0;

	// Use this for initialization
	void Start () {
        mypos = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        var moveAmount = speed * Time.deltaTime;
        if (!hasCollided)
            mypos.position = Vector3.MoveTowards(mypos.position, camerapos.position, moveAmount);
		//material = GetComponent<Renderer> ().material;
	}

    private void OnCollisionEnter(Collision collision)
    {
        hasCollided = true;
        if (collision.gameObject.name == "PlayerPlane")
        {
            Debug.Log("You've been hit!");

			if (count == 0) {
				lifeBar.changeColor1 (material);
			}
			if (count == 1) {
				lifeBar.changeColor2 (material);
			}
			if (count == 2) {
				lifeBar.changeColor3 (material);
				Debug.Log ("Game Over!");
				// End game here
			}
			count += 1;
        }
        else if (collision.gameObject.name == "outside saber")
        {
            Debug.Log("Nice block!");
            //blockSound.Play();
        }
        // move bullet back to shooter position
        mypos.position = Vector3.MoveTowards(mypos.position, shooterpos.position, 100000);
        hasCollided = false;
    }

}
