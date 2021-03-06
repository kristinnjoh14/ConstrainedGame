﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefScript : MonoBehaviour
{
    public float chefSpeed;
    public Transform[] ingredients = new Transform[6];
    public Stack stack;


    private GameManager manager;
    public IngredientSpawner ingredientSpawner;
    private float throwCountdown;
    public float throwRate;

    private Animator myAnim;
    private Animator evilAnim;

    // Use this for initialization
    void Start()
    {
        myAnim = GetComponent<Animator>();
        manager = FindObjectOfType<GameManager>();
        GameObject evil = GameObject.Find("EvilBoyChef");
        evilAnim = evil.GetComponent<Animator>();
        evil.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
    }

    void InputHandler()
    {
        if (manager.round == 1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (!Input.GetKey(KeyCode.D))
                {
                    //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefSpeed, 0));
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-chefSpeed, 0);
                    myAnim.SetBool("Moving", true);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    myAnim.SetBool("Moving", false);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (!Input.GetKey(KeyCode.A))
                {
                    //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
                    GetComponent<Rigidbody2D>().velocity = new Vector2(chefSpeed, 0);
                    myAnim.SetBool("Moving", true);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    myAnim.SetBool("Moving", false);
                }
            }
            /*if (Input.GetKey (KeyCode.D)) {
				if (!Input.GetKey (KeyCode.A)) {
					//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (chefSpeed, 0);
					myAnim.SetBool ("Moving", true);
					// transform.rotation = Quaternion.Euler(0, 0, 0);
				} else {

					GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
					myAnim.SetBool ("Moving", false);
				}
			}*/
            if (Input.GetKeyUp(KeyCode.A))
            {
                //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefSpeed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                myAnim.SetBool("Moving", false);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                myAnim.SetBool("Moving", false);
            }

        }
        else if (manager.round == 2)
        {
            if (Input.GetKey(KeyCode.J))
            {
                if (!Input.GetKey(KeyCode.L))
                {
                    //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefSpeed, 0));
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-chefSpeed, 0);
                    evilAnim.SetBool("Moving", true);
                    myAnim.SetBool("Moving", true);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    evilAnim.SetBool("Moving", false);
                    myAnim.SetBool("Moving", false);
                }
            }
            if (Input.GetKey(KeyCode.L))
            {
                if (!Input.GetKey(KeyCode.J))
                {
                    //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
                    GetComponent<Rigidbody2D>().velocity = new Vector2(chefSpeed, 0);
                    evilAnim.SetBool("Moving", true);
                    myAnim.SetBool("Moving", true);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    evilAnim.SetBool("Moving", false);
                    myAnim.SetBool("Moving", false);
                }
            }
            /*if (Input.GetKey (KeyCode.D)) {
				if (!Input.GetKey (KeyCode.A)) {
					//GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
					GetComponent<Rigidbody2D> ().velocity = new Vector2 (chefSpeed, 0);
					myAnim.SetBool ("Moving", true);
					// transform.rotation = Quaternion.Euler(0, 0, 0);
				} else {

					GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
					myAnim.SetBool ("Moving", false);
				}
			}*/
            if (Input.GetKeyUp(KeyCode.J))
            {
                //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-chefSpeed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                evilAnim.SetBool("Moving", false);
                myAnim.SetBool("Moving", false);
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                //GetComponent<Rigidbody2D> ().AddForce (new Vector2 (chefSpeed, 0));
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                evilAnim.SetBool("Moving", false);
                myAnim.SetBool("Moving", false);
            }
        }
    }

    /*void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.CompareTag ("Ingredient")) {
			int ingredientType = findIngredientType (coll.gameObject.name);
			Destroy (coll.gameObject);
			stack.addToStack (ingredientType);
		}
	}*/

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

    public void SwitchBodies()
    {
        foreach (Transform child in transform)
        {
            if (child.CompareTag("VisualEvil"))
            {
                Debug.Log("Fer inn í visual evil");
                child.gameObject.SetActive(true);
            }
            if (child.CompareTag("VisualChef"))
            {
                Debug.Log("Fer inn í visual chef");
                child.gameObject.SetActive(false);
            }
        }
    }

    //void addToStack (string ingredientType) {
    //TODO: Implement or rethink
    //GameObject newbie = Instantiate (ingredients[x], new Vector2 ((Random.value*17.2f-8.6f), 5), Quaternion.identity);
    //stack.Add (newbie);
    //}
}