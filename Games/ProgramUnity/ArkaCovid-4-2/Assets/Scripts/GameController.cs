using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour
{

	public Ball GameBall;
	public PaddleControll Paddle;

	public Text PointsText;
	public Text LivesText;
	public Text TimeText;
	public int Lives = 3;
	public GameObject endGameScreen;
	public InputField name;

	private int points = 0;
	private bool isGameActive = false;
	public TimeSpan timePlaying;
	private bool timerGoing;
	private float elapsedTime;
	private GameObject[] gameObjects;
	public int numberOfPoints;
	
	// Use this for initialization
	void Start()
	{

		LivesText.text = "Życia: " + Lives;
		TimeText.text = "Czas: 00:00:00";
		timerGoing = false;
		gameObjects = GameObject.FindGameObjectsWithTag("Point");
		numberOfPoints = gameObjects.Length;
		endGameScreen.SetActive(false);
	}

	void Update()
	{
		if (isGameActive == false && Input.GetKeyDown(KeyCode.Space))
		{
			isGameActive = true;
			GameBall.StartBall();
			timerGoing = true;
			BeginTimer();
		}

		if (numberOfPoints == 0)
        {
			timerGoing = false;
			isGameActive = false;
			endGameScreen.SetActive(true);
        }
	}

	public void DecrementLives()
	{
		Lives -= 1;
		LivesText.text = "Życia:  " + Lives;
		if (Lives <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	public void Restart()
	{
		isGameActive = false;
		GameBall.Restart();
		Paddle.Restart();
	}

	public void AddPoints(int points)
	{
		this.points += points;
		PointsText.text = "Punkty: " + this.points;
	}

	public void BeginTimer()
    {
		timerGoing = true;
		elapsedTime = 0f;

		StartCoroutine(UpdateTimer());
    }

	private void EndTimer()
    {
		timerGoing = false;
    }

	private IEnumerator UpdateTimer()
    {
		while (timerGoing)
        {
			elapsedTime += Time.deltaTime;
			timePlaying = TimeSpan.FromSeconds(elapsedTime);
			string timePlayingStr = "Czas: " + timePlaying.ToString("mm':'ss':'ff");
			TimeText.text = timePlayingStr;

			yield return null;
        }
    }

	public void SaveName()
    {
		string destination = Application.persistentDataPath + "/save.dat";
		FileStream file;

		if (File.Exists(destination)) file = File.OpenWrite(destination);
		else file = File.Create(destination);

		GameData data = new GameData(Lives, points, elapsedTime, name.text);

		BinaryFormatter bf = new BinaryFormatter();
		bf.Serialize(file, data);
		file.Close();

		SceneManager.LoadScene("Menu");
	}
}
