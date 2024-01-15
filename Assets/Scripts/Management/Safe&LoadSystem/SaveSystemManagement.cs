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
        public Data(int[] _seedPlacement/*, GrowthState _currentState*/)
        {
            seedPlacement = _seedPlacement;
            //currentState = _currentState;
        }
 
        int[] seedPlacement = SoilScript.seedPlacement;
        public GrowthState currentState;
    }
}