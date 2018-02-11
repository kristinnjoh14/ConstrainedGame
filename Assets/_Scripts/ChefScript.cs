using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefScript : MonoBehaviour {
	public float chefSpeed;
	public Transform[] ingredients = new Transform[6];
	public Stack stack;
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

	/*void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.CompareTag ("Ingredient")) {
			int ingredientType = findIngredientType (coll.gameObject.name);
			Destroy (coll.gameObject);
			stack.addToStack (ingredientType);
		}
	}*/

	public static int findIngredientType (string falling) {
		//Debug.Log (falling.Substring(0, falling.Length - 14) + "Stacked");
		string type = falling.Substring(0, falling.Length - 14);
		switch (type) {
		case "Bacon":
			return 0;
		case "Bread":
			return 1;
		case "Fried Egg":
			return 2;
		case "Lettuce":
			return 3;
		case "Tomato":
			return 4;
		default:
			return -1;
		}
	}

	//void addToStack (string ingredientType) {
		//TODO: Implement or rethink
		//GameObject newbie = Instantiate (ingredients[x], new Vector2 ((Random.value*17.2f-8.6f), 5), Quaternion.identity);
		//stack.Add (newbie);
	//}
}


