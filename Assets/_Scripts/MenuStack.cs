using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStack : MonoBehaviour
{
	public Transform[] ingredients;
	public List<GameObject> stack = new List<GameObject>();
	public Vector2 stackTop;
	public float stackStiffness;


	public float ingredientHeight;
	//References
	private GameManager myGM;
	private ScoreManager myScoreManager;

	// Use this for initialization
	void Start()
	{
		myScoreManager = GetComponentInParent<ScoreManager>();
		myGM = FindObjectOfType<GameManager>();

		stackTop = GetComponent<BoxCollider2D>().transform.position;
		stack.Add(Instantiate(ingredients[1], stackTop + new Vector2(0, ingredientHeight), Quaternion.identity).gameObject);
		stackTop = (Vector2)stack[0].transform.position;
		GetComponent<BoxCollider2D>().transform.position = new Vector2(GetComponent<BoxCollider2D>().transform.position.x, stackTop.y);
	}

	// Update is called once per frame
	void Update()
	{
		if (stack.Count > 0)
		{

			Vector2 chef = transform.parent.transform.position;
			Vector3 v = new Vector3(chef.x, stack[0].transform.position.y);
			stack[0].transform.position = v;

			for (int i = 1; i < stack.Count; i++)
			{
				Vector2 tmp1 = stack[i].transform.position;
				Vector3 temp1 = stack[i - 1].transform.position;
				float x1 = Mathf.LerpUnclamped(tmp1.x, temp1.x, stackStiffness);
				Vector3 v2 = new Vector3(x1, tmp1.y);
				stack[i].transform.position = v2;
			}
			GetComponent<BoxCollider2D>().transform.position = new Vector2(stack[stack.Count - 1].transform.position.x, stackTop.y);
		}
	}

	public void addToStack(int type)
	{
		if (type == 1)
		{
			foreach (GameObject item in stack)
			{
				Destroy(item);
			}
			stack.Clear();
			stackTop = (Vector2)transform.parent.position;
		}
		Transform newbie = Instantiate(ingredients[type], stackTop + new Vector2(0, ingredientHeight), Quaternion.identity);
		newbie.GetComponent<SpriteRenderer>().sortingOrder = stack.Count;
		stack.Add(newbie.gameObject);
		stackTop = newbie.position;
		GetComponent<BoxCollider2D>().transform.position = new Vector2(GetComponent<BoxCollider2D>().transform.position.x, stackTop.y);
		if (type == 5)
		{
			foreach (GameObject item in stack)
			{
				Destroy(item);
			}
			stack.Clear();
			stackTop = (Vector2)transform.parent.position;
			Transform botBread = Instantiate(ingredients[1], stackTop + new Vector2(0, ingredientHeight), Quaternion.identity);
			stack.Add(botBread.gameObject);
			stackTop = botBread.position;
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag("Ingredient"))
		{
			int ingredientType = ChefScript.findIngredientType(coll.gameObject.name);
			Destroy(coll.gameObject);
			addToStack(ingredientType);
		}
	}
}