using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI PlayerName;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI Time;

    private void Start()
    {
        LoadFile();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData)bf.Deserialize(file);
        file.Close();

        TimeSpan text = TimeSpan.FromSeconds(data.time);

        PlayerName.text = "Player name: " + data.name;
        Score.text = "Score:" + data.points;
        Time.text = "Czas: " + text.ToString("mm':'ss':'ff");
    }
}
