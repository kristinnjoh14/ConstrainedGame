using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour {
	public Transform[] ingredients;
	public List<GameObject> stack = new List<GameObject> ();
	public Vector2 stackTop;

	// Use this for initialization
	void Start () {
		stackTop = (Vector2) transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (stack.Count > 0) {
			if (Mathf.Abs (GetComponentInParent<Rigidbody2D> ().position.x - stack [0].transform.position.x) > 0.2) {
				Vector2 temp = new Vector2 ((GetComponentInParent<Rigidbody2D> ().position.x - stack [0].transform.position.x)*Time.deltaTime, stack [0].transform.position.y);
				stack [0].transform.position = temp;
			}
			int i = 0;
			foreach (GameObject item in stack.GetRange(1, stack.Count-1)) {
				if (Mathf.Abs (stack[i].transform.position.x - item.transform.position.x) > 0.2) {
					Vector2 temp = new Vector2 ((stack[i].transform.position.x - item.transform.position.x)*Time.deltaTime, item.transform.position.y);
					item.transform.position = temp;
				}
				i++;
			}
		}
	}

	public void addToStack (int type) {
		Transform newbie = Instantiate (ingredients[type], stackTop + new Vector2(0.5f*Random.value-0.25f,0.15f), Quaternion.identity);
		stack.Add (newbie.gameObject);
		stackTop = newbie.position;
	}
}
