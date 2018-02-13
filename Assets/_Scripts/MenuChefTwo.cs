using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChefTwo : MonoBehaviour
{
	public float chefTwoSpeed;
	public Transform[] ingredients = new Transform[6];
	public MenuStack stack;

	public IngredientSpawner ingredientSpawner;

	private Animator myAnim;

	// Use this for initialization
	void Start()
	{
		myAnim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		InputHandler();
	}

	void InputHandler()
	{
		if (Input.GetKey(KeyCode.J))
		{
			if (!Input.GetKey(KeyCode.L))
			{
				//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefTwoSpeed, 0));
				GetComponent<Rigidbody2D>().velocity = new Vector2(-chefTwoSpeed, 0);
				myAnim.SetBool("Moving", true);
			}
			else
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				myAnim.SetBool("Moving", false);
			}
		}
		if (Input.GetKey(KeyCode.L))
		{
			if (!Input.GetKey(KeyCode.J))
			{
				//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefTwoSpeed, 0));
				GetComponent<Rigidbody2D>().velocity = new Vector2(chefTwoSpeed, 0);
				myAnim.SetBool("Moving", true);
			}
			else
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
				myAnim.SetBool("Moving", false);
			}
		}

		if (Input.GetKeyUp(KeyCode.J))
		{
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefTwoSpeed, 0));
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			myAnim.SetBool("Moving", false);
		}
		if (Input.GetKeyUp(KeyCode.L))
		{
			//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefTwoSpeed, 0));
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
			myAnim.SetBool("Moving", false);
		}
	}

	public static int findIngredientType(string falling)
	{
		//Debug.Log (falling.Substring(0, falling.Length - 14) + "Stacked");
		string type = falling.Substring(0, falling.Length - 14);
		switch (type)
		{
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
		case "Rotten":
			return 5;
		default:
			return -1;
		}
	}
}