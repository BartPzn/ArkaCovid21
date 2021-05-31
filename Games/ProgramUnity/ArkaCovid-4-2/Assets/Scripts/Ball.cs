using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{

	private Rigidbody ballRigidbody;

	private Vector3 ballStartPosition;
	// Use this for initialization
	void Start()
	{
		ballStartPosition = transform.position;
		ballRigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Restart()
	{
		transform.position = ballStartPosition;
		ballRigidbody.Sleep();
	}

	public void StartBall()
	{
		ballRigidbody.AddForce(new Vector3(0f, 1000f, 0f)); // siła dzięki, której piłka się odbija
	}
}
