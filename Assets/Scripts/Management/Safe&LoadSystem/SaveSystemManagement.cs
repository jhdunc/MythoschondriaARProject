using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveSystemManagement
{
    public static void Save(Data data)//Takes data which is going to be saved, turns it into json replacing data already saved, then saves it on pc
    {
        string save = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/Save.json", save);
    }

    public static bool Load(out Data data)//Takes data which is saved as json, and reads it. UNLESS it doesn't exist
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
    public class Data//What data is being saved > only saves the placement of the seeds
    {
        public Data(int[] _seedPlacement/*, GrowthState _currentState*/)
        {
            seedPlacement = _seedPlacement;
            //currentState = _currentState;
        }
 
        int[] seedPlacement = SoilScript.seedPlacement;
        //public GrowthState currentState;
    }
}