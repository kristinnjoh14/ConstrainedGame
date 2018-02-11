﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour {
	public Transform[] ingredients;
	public List<GameObject> stack = new List<GameObject> ();
	public Vector2 stackTop;

	public float ingredientHeight;
    //References
    private ScoreManager myScoreManager;

	// Use this for initialization
	void Start ()
	{
	    myScoreManager = GetComponentInParent<ScoreManager>();

		stackTop = GetComponent<BoxCollider2D> ().transform.position;
		stack.Add (Instantiate (ingredients[1], stackTop + new Vector2 (0, ingredientHeight), Quaternion.identity).gameObject);
		stackTop = (Vector2) stack[0].transform.position;
		GetComponent<BoxCollider2D> ().transform.position = new Vector2 (GetComponent<BoxCollider2D> ().transform.position.x, stackTop.y);
	}

	// Update is called once per frame
	void Update () {
		if (stack.Count > 0) {
			if (Mathf.Abs (GetComponentInParent<Rigidbody2D> ().transform.position.x - stack [0].transform.position.x) > 0.2) {
				Vector3 temp = Vector2.ClampMagnitude (new Vector2 ((GetComponentInParent<BoxCollider2D> ().transform.position.x - stack [0].transform.position.x), 0), 1000f);
				stack [0].transform.position += temp;
			}
			int i = 0;
			foreach (GameObject item in stack.GetRange(1, stack.Count-1)) {
				if (Mathf.Abs (stack[i].transform.position.x - item.transform.position.x) > 0.2) {
					Vector3 temp = Vector2.ClampMagnitude (new Vector2 ((stack[i].transform.position.x - item.transform.position.x), 0), 1000f);
					item.transform.position += temp;
				}
				i++;
			}
		}
	}

	public void addToStack (int type) {
		if (type == 1) {
			foreach (GameObject item in stack) {
				Destroy (item);
                myScoreManager.addToScore(100);
			}
			stack.Clear ();
			stackTop = (Vector2) transform.parent.position;
		}
		Transform newbie = Instantiate (ingredients[type], stackTop + new Vector2 (0,ingredientHeight), Quaternion.identity);
		stack.Add (newbie.gameObject);
		stackTop = newbie.position;
		GetComponent<BoxCollider2D> ().transform.position = new Vector2 (GetComponent<BoxCollider2D> ().transform.position.x, stackTop.y);
		if (type == 5) {
			foreach (GameObject item in stack) {
				Destroy (item);
			}
			stack.Clear ();
			stackTop = (Vector2) transform.parent.position;
			Transform botBread = Instantiate (ingredients[1], stackTop + new Vector2 (0,ingredientHeight), Quaternion.identity);
			stack.Add (botBread.gameObject);
			stackTop = botBread.position;
		}
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.CompareTag ("Ingredient")) {
			int ingredientType = ChefScript.findIngredientType (coll.gameObject.name);
			Destroy (coll.gameObject);
			addToStack (ingredientType);
		}
	}
}
