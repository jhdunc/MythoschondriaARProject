using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSystemManagement
{
    public static void Save(Data data)
    {
        string save = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/Save.json", save);
    }

    public static bool Load(out Data data)
    {
        data = null;

        if (!File.Exists(Application.persistentDataPath + "/Save.json"))
            return false;
        string save = File.ReadAllText(Application.persistentDataPath + "/Save.json");
        data = JsonUtility.FromJson<Data>(save);
        if (data != null) return true;
        else return false;
    }

    [Serializable]
    public class Data
    {

        public Data(bool _tilled, GrowthState _currentState)
        {
             tilled = _tilled;
             currentState = _currentState;
        }

        //Soil patch 
        public bool tilled;
        public GrowthState currentState;
    }
}