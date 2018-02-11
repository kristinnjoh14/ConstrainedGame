using System.Collections;
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
			//if (Mathf.Abs (GetComponentInParent<Rigidbody2D> ().transform.position.x - stack [0].transform.position.x) > 0.2) {
			Vector2 chef = GetComponentInParent<Rigidbody2D> ().transform.position;
			Debug.Log (chef);
			Vector3 temp = stack [0].transform.position;
			float x = Mathf.Lerp (temp.x, chef.x, 0.8f);
			Vector3 v = new Vector3 (x, temp.y);
			stack [0].transform.position = v;
			//}
			for (int i = stack.Count - 1; i > 0; i--) {
				//if (Mathf.Abs (stack[i].transform.position.x - item.transform.position.x) > 0.2) {
				Vector2 tmp1 = stack[i].transform.position;
				Vector3 temp1 = stack[i-1].transform.position;
				float x1 = Mathf.Lerp (tmp1.x, temp1.x, 0.8f);
				Vector3 v2 = new Vector3 (x1, tmp1.y);
				stack[i].transform.position = v2;
				//}
			}
			GetComponent<BoxCollider2D> ().transform.position = new Vector2 (stack[stack.Count-1].transform.position.x, stackTop.y);
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
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.CompareTag ("Ingredient")) {
			int ingredientType = ChefScript.findIngredientType (coll.gameObject.name);
			Destroy (coll.gameObject);
			addToStack (ingredientType);
		}
	}
}
