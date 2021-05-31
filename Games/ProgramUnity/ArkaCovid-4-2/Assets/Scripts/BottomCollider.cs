using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour {

	private GameController gameController;
	// Use this for initialization
	void Start () {
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {

		if (other.tag == "Ball") {

			gameController.Restart ();
			gameController.DecrementLives ();

		}

	}
}
