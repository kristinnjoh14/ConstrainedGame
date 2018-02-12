using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{

    private float throwCountdown;
    public float throwRate;
    public float enemySpeed;
    public IngredientSpawner ingredientSpawner;
    public Text countdownText;
    private GameManager manager;

    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        throwCountdown = throwRate;
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = "Countdown " + throwCountdown.ToString("f1");
        if (throwCountdown > 0)
        {
            throwCountdown -= Time.deltaTime;
        }

        if (throwCountdown < 0)
        {
            throwCountdown = 0;
        }

        InputHandler();
    }

    void InputHandler()
    {

        if (manager.round == 1)
        {
            if (Input.GetKey(KeyCode.J))
            {
                if (!Input.GetKey(KeyCode.L))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            if (Input.GetKey(KeyCode.L))
            {
                if (!Input.GetKey(KeyCode.J))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            if (Input.GetKeyUp(KeyCode.J))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if (throwCountdown == 0)
                {
                    Instantiate(ingredientSpawner.ingredients[ingredientSpawner.ingredients.Length - 1], new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
                    throwCountdown += throwRate;
                }
            }
        }
        else if (manager.round == 2)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if (!Input.GetKey(KeyCode.D))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-enemySpeed, 0);
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            if (Input.GetKey(KeyCode.D))
            {
                if (!Input.GetKey(KeyCode.A))
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(enemySpeed, 0);
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                }
            }
            if (Input.GetKeyUp(KeyCode.A))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
            if (Input.GetKeyUp(KeyCode.D))
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (throwCountdown == 0)
                {
                    Instantiate(ingredientSpawner.ingredients[ingredientSpawner.ingredients.Length - 1], new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
                    throwCountdown += throwRate;
                }
            }
        }
    }
}