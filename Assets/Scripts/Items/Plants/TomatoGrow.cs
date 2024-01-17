using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoGrow : MonoBehaviour
{
    [SerializeField] GameObject[] plantToGrow;
    private Vector3 growSproutScalar;

    private void Start()
    {
        growSproutScalar = new Vector3(0.08f, 0.08f, 0.08f);
    }
    public void StartGrowing()
    {
        if(plantToGrow != null)
        { 
            for (int i = 0; i < plantToGrow.Length; i++)
            {
                if (plantToGrow[i].transform.localScale.x < 1)
                {
                    plantToGrow[i].transform.localScale += growSproutScalar * Time.deltaTime;
                }
            }
        }
    }

}
