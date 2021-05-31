using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControll : MonoBehaviour // Odniesienia do aktualnego obiektu
{

	public float Speed = 5f; //Parametr prędkości paletki
	public float RotationSpeed = 1f; // Parametr prędkości rotacji paletki

	private float rotationAngle = 0f; //kąt obrotu
	private Vector3 paddleStartPosition; // Parametr prędkości rotacji paletki
										 // Use this for initialization
	void Start () {
		paddleStartPosition = transform.position;
	}

	// Update wywoływany jest raz na klatkę
	void Update () {

		transform.Translate(Time.deltaTime*Speed*Input.GetAxis ("Horizontal"),0f,0f,Space.World); // Time.deltaTime zwraca nam czas ostatniej klatki w sek
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, -8f, 8f), 
				transform.position.y, transform.position.z);

		rotationAngle += Time.deltaTime * Input.GetAxis ("Vertical") * RotationSpeed;
		rotationAngle = Mathf.Clamp (rotationAngle, -45f, 45f);
		transform.rotation = Quaternion.Euler (0f, 0f, rotationAngle);
	}

	public void Restart()
	{
		transform.position = paddleStartPosition;
		transform.rotation = Quaternion.identity; // kwaterium zerowej rotacji
		rotationAngle = 0f; // reset wszystkich wartości
	}
}
