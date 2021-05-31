using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

	private GameController gameController;

	public GameObject Collectible;
	// Use this for initialization
	void Start()
	{
		gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.tag == "Ball")
		{
			Destroy(gameObject);
			gameController.AddPoints(1);
			gameController.numberOfPoints--;

			if (Random.Range(0f, 10f) < 2f)
			{   //losujemy szansę na wypadnięcie dodatkowego obiektu
				GameObject col = Instantiate(Collectible, transform.position, Quaternion.identity);
			}
		}
	}
}
