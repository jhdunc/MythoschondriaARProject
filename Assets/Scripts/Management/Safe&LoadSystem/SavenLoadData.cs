using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SavenLoadData : MonoBehaviour
{
    SaveSystemManagement.Data data;

    public void OnLoadGame()//Add this to the button to load saved data from SaveSystemManagements
    {
        Debug.Log("Load");
        SceneManager.LoadScene("MainScene");
        SaveSystemManagement.Load(out data);
    }

    public void OnSaveGame()//Add this to the button to save data in SaveSystemManagements
    {
        Debug.Log("Going to Save");
        SaveSystemManagement.Save(new SaveSystemManagement.Data(SoilScript.seedPlacement));
    }
     
}
