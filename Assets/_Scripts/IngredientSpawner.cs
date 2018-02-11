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
			Instantiate (ingredients[index], new Vector2 ((Random.value*17.2f-8.6f), 4), Quaternion.identity);
			
			//Reset counter, += to include what little time was overkill for counter to reach 0
			spawnCountdown += spawnRate;
		}
	}
}
