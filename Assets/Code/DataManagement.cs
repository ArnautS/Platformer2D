using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManagement : MonoBehaviour {

	public static DataManagement dataManagement;
	public int deathCount = 0;
	private string saveFileLocation;

	void Start() {
		saveFileLocation = Application.persistentDataPath + "/gameInfo.dat";
	}

	// redundant? maybe just use static variables / methods
	void Awake() {
		if (dataManagement == null) {
			DontDestroyOnLoad(gameObject);
			dataManagement = this;
		} else if (dataManagement != this) {
			Destroy(gameObject);
		}
	}

	public void SaveData() {
		BinaryFormatter binForm = new BinaryFormatter();
		FileStream file = File.Create(saveFileLocation); //creates save file
		GameData data = new GameData(); //container for data
		data.highscore = deathCount;
		binForm.Serialize(file, data);
		file.Close();
	}

	public void LoadData() {
		if (File.Exists(saveFileLocation)) {
			BinaryFormatter binForm = new BinaryFormatter();
			FileStream file = File.Open(saveFileLocation, FileMode.Open);
			GameData data = (GameData)binForm.Deserialize(file);
			file.Close();
			deathCount = data.highscore;
		}
	}
}

[Serializable]
class GameData {
	public int highscore;
}
