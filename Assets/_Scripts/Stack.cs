using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour {
	public Transform[] ingredients;
	public List<GameObject> stack = new List<GameObject> ();
	public Vector2 stackTop;

	// Use this for initialization
	void Start () {
		stackTop = GetComponentInParent<BoxCollider2D> ().transform.position;
		stack.Add (Instantiate (ingredients[1], stackTop + new Vector2 (0, 0.2f), Quaternion.identity).gameObject);
		stackTop = (Vector2) stack[0].transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (stack.Count > 0) {
			if (Mathf.Abs (GetComponentInParent<Rigidbody2D> ().transform.position.x - stack [0].transform.position.x) > 0.2) {
				Vector3 temp = new Vector2 ((GetComponentInParent<BoxCollider2D> ().transform.position.x - stack [0].transform.position.x), 0);
				stack [0].transform.position += temp;
			}
			int i =0;
			foreach (GameObject item in stack.GetRange(1, stack.Count-1)) {
				if (Mathf.Abs (stack[i].transform.position.x - item.transform.position.x) > 0.2) {
					Vector3 temp = new Vector2 ((stack[i].transform.position.x - item.transform.position.x), 0);
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
			}
			stack.Clear ();
			stackTop = (Vector2) transform.position;
		}
		Transform newbie = Instantiate (ingredients[type], stackTop + new Vector2 (0,0.2f), Quaternion.identity);
		stack.Add (newbie.gameObject);
		stackTop = newbie.position;

	}
}
