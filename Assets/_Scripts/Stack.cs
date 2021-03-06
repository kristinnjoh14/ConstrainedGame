﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stack : MonoBehaviour
{
    public Transform[] ingredients;
    public List<GameObject> stack = new List<GameObject>();
    public Vector2 stackTop;
    public float stackStiffness;
    public Text scoreText;
    public Text playerOneScore;
    public Text playerTwoScore;

    public float ingredientHeight;

    private int numberOfMeat;
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
		Debug.Log (stack.Count);
        if (stack.Count > 0)
        {

            GameObject plate = GameObject.FindGameObjectWithTag("Plate");
            Vector2 chef = plate.transform.position;
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
        scoreText.text = "Score multiplier x" + stack.Count;
        playerOneScore.text = "Player 1:" + myScoreManager.score;
        playerTwoScore.text = "Player 2: " + myScoreManager.scoreTwo;
    }

    public void addToStack(int type)
    {

        if (type == 5)
        {
            numberOfMeat++;
        }

        if (type == 1)
        {
            foreach (GameObject item in stack)
            {
                Destroy(item);
                if (myGM.round == 1)
                {
                    if (numberOfMeat > 0)
                    {
                        float scoreToGive = -1000.0f * (stack.Count / 10.0f);
                        myScoreManager.addToScore(scoreToGive);
                    }
                    else
                    {
                        float scoreToGive = 1000.0f * (stack.Count / 10.0f);
                        myScoreManager.addToScore(scoreToGive);
                    }
                }
                else if (myGM.round == 2)
                {
                    if (numberOfMeat > 0)
                    {
                        float scoreToGive = -1000.0f * (stack.Count / 10.0f);
                        myScoreManager.addToScoreTwo(scoreToGive);
                    }
                    else
                    {
                        float scoreToGive = 1000.0f * (stack.Count / 10.0f);
                        myScoreManager.addToScoreTwo(scoreToGive);
                    }
                }
            }
            if (numberOfMeat > 0 && stack.Count > 1)
            {
                SoundBase.Instance.PlaySound(SoundBase.Instance.eww);
            }
            else if (numberOfMeat == 0 && stack.Count > 0)
            {
                SoundBase.Instance.PlaySound(SoundBase.Instance.nom);
            }
            stack.Clear();
            numberOfMeat = 0;
            stackTop = (Vector2)transform.parent.position;
        }
        Transform newbie = Instantiate(ingredients[type], stackTop + new Vector2(0, ingredientHeight), Quaternion.identity);
        newbie.GetComponent<SpriteRenderer>().sortingOrder = stack.Count;
        stack.Add(newbie.gameObject);
        stackTop = newbie.position;
        GetComponent<BoxCollider2D>().transform.position = new Vector2(GetComponent<BoxCollider2D>().transform.position.x, stackTop.y);
        SoundBase.Instance.PlaySound(SoundBase.Instance.ingSplat);
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

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Trash") && stack.Count > 1)
        {
            SoundBase.Instance.PlaySound(SoundBase.Instance.trash);
            if (myGM.round == 1) {
				float scoreToGive = 500.0f * (stack.Count / 10.0f);
				myScoreManager.addToScoreTwo (scoreToGive);
				foreach (GameObject item in stack) {
					Destroy (item);
				}
			} else {
				float scoreToGive = 500.0f * (stack.Count / 10.0f);
				myScoreManager.addToScore (scoreToGive);
				foreach (GameObject item in stack) {
					Destroy (item);
				}
			}
            stack.Clear();
            numberOfMeat = 0;
            stackTop = (Vector2)transform.parent.position;
            Transform botBread = Instantiate(ingredients[1], stackTop + new Vector2(0, ingredientHeight), Quaternion.identity);
            stack.Add(botBread.gameObject);
            stackTop = botBread.position;
        }
    }
}