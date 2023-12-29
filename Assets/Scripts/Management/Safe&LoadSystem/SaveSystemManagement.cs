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
        //File.Create(Application.persistentDataPath + "Save.json");
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
        public Data(Vector3 /*_position, int _items*/)
        {
            //position = _position;
            //Items = _items;
        }
        //public Vector3 position; //TODO get player Location
        //public int Items;
    }
}