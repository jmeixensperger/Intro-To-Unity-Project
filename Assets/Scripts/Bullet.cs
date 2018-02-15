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
	public LifeBar lifeBar;
	public Material material;
	public int count = 0;

	// Use this for initialization
	void Start () {
        gameObject.SetActive(false);
        mypos = this.transform;
        speed = 15.0f;
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

			if (count == 0)
				lifeBar.changeColor1 (material);
			if (count == 1)
				lifeBar.changeColor2 (material);
			if (count == 2) {
				lifeBar.changeColor3 (material);
				Debug.Log ("Game Over");
				// end game here
			}
			count += 1;
        }
        else if (collision.gameObject.name == "outside saber")
        {
            Debug.Log("Nice block!");
            AudioSource.PlayClipAtPoint(blockSound, mypos.position);
        }
        // move bullet back to shooter position and de-activate (make invisible)
        mypos.position = Vector3.MoveTowards(mypos.position, shooterpos.position, 100000);
        gameObject.SetActive(false);
        hasCollided = false;
    }

}
