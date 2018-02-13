using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour {
	public float spawnRate;
	public Transform[] ingredients = new Transform[7];

	private float spawnCountdown;
	// Use this for initialization
	void Start () {
		spawnCountdown = spawnRate;
	}
	
	// Update is called once per frame
	void Update () {
		spawnCountdown -= Time.deltaTime;
		if (spawnCountdown < 0) {
			//Spawn random ingredient
			int index = Random.Range (0, ingredients.Length-1);
			Vector2 topLeft = Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height*0.8f, 0));
			Vector2 topRight = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height*0.8f, 0));
			topLeft.x += (1024 / 600) + 4.1f;
			topRight.x -= 1024 / 600 + 4.1f;
			Instantiate (ingredients[index], new Vector2 (topLeft.x+2*Random.value*topRight.x,topLeft.y), Quaternion.identity);
			
			//Reset counter, += to include what little time was overkill for counter to reach 0
			spawnCountdown += spawnRate;
		}
	}
}
