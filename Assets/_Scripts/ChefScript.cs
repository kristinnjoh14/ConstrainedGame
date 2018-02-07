using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefScript : MonoBehaviour {
	public float chefSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		InputHandler ();
	}

	void InputHandler () {
		if (Input.GetKey (KeyCode.A)) {
			if (!Input.GetKey (KeyCode.D)) {
				//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefSpeed, 0));
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (-chefSpeed, 0);
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}
		}
		if (Input.GetKey (KeyCode.D)) {
			if (!Input.GetKey (KeyCode.A)) {
				//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (chefSpeed, 0);
			} else {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
			}
		}
		if (Input.GetKeyUp (KeyCode.A)) {
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefSpeed, 0));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}
		if (Input.GetKeyUp (KeyCode.D)) {
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		Debug.Log (coll.otherCollider.name);
	}
}


