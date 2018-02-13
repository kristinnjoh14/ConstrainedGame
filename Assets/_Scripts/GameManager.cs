using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private Timer timer;
    public int round;
    public Text roundSwitch;
    private string roundSwitchPromter;
    private bool paused;
	private ChefScript chef;
	private EnemyScript enemy;

    private Stack stack; 

    // Use this for initialization
    void Start()
    {
		Time.timeScale = 1;
        timer = GetComponentInParent<Timer>();
        stack = FindObjectOfType<Stack>();
		chef = FindObjectOfType<ChefScript> ();
		enemy = FindObjectOfType<EnemyScript> ();
        round = 1;
        paused = false;
        roundSwitchPromter = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.t < 0)
        {
            roundSwitchPromter = "Switching sides, press SPACE to continue";
            roundSwitch.text = roundSwitchPromter;
			var fallingStuff = GameObject.FindGameObjectsWithTag ("Ingredient");
			foreach (GameObject item in fallingStuff) {
				Destroy (item);
			}
            paused = true;
        }
        if (paused && round != 2)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
				chef.SwitchBodies ();
				enemy.SwitchBodies ();
                paused = false;
                round = 2;
                roundSwitchPromter = "";
                roundSwitch.text = roundSwitchPromter;
                Time.timeScale = 1;
                foreach (GameObject item in stack.stack)
                {
                    Destroy(item);
                }
                stack.stack.Clear();
                stack.stackTop = (Vector2)stack.transform.parent.position;
                Transform botBread = Instantiate(stack.ingredients[1], stack.stackTop + new Vector2(0, stack.ingredientHeight), Quaternion.identity);
                stack.stack.Add(botBread.gameObject);
                stack.stackTop = botBread.position;
            }
        }
        else if (paused && round == 2)
        {
			
            Time.timeScale = 0;

            roundSwitchPromter = "ESCAPE to quit\nSpace or R to return to main menu";
            roundSwitch.text = roundSwitchPromter;
            /*if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
			}*/ 
			if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.R)) {
				SceneManager.LoadScene ("MenuScene");
			}

        }
    }
}