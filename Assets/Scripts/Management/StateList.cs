using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateList : MonoBehaviour
{
    public bool readState; 
    public List<GameObject> stateList;

    public void Update()
    {
        if (readState == true)
        {
            Debug.Log("if fired");
            foreach (var x in stateList)
            {
                var state = x.GetComponent<PlotStateManager>().currentState;
                Debug.Log(state.ToString());
            }
            readState = false;
        }
    }
}
