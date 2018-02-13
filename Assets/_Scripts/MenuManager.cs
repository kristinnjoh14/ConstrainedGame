using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Virkar");
			SceneManager.LoadScene ("MainScene");
		}
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit ();
		}
	}
}
