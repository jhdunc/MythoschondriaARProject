using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavenLoadData : MonoBehaviour
{
    SaveSystemManagement.Data data;

    public void OnLoadGame()
    {
        Debug.Log("Load");
        SceneManager.LoadScene("MainScene");
        SaveSystemManagement.Load(out data);
    }

    public void OnSaveGame()
    {
        Debug.Log("Going to Save");
        //SaveSystemManagement.Save(new SaveSystemManagement.Data(bool _tilled, GrowthState _currentState));
    }

}
