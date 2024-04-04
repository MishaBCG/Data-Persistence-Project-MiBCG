using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ForSave : MonoBehaviour
{
    public static ForSave instance { get; private set; }

    public string namePlayer;
    public int ScoreToSave;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

    }

   public void SaveGame()
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.score = ScoreToSave;
        data.name = namePlayer;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("I save");
    }

   public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            namePlayer = data.name;
            ScoreToSave = data.score;
            Debug.Log("I load");
        }
        else
            Debug.Log("No Save Data");

    }


    [System.Serializable]
    class SaveData
    {
        public int score;
        public string name;

    }





}
