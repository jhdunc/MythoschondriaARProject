using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{

    [SerializeField] GameObject statusTextHolder;
    [SerializeField] GameObject timerUI;
    [SerializeField] GameObject slider;
    [SerializeField] Image timerFill;

    private float timeElapsed;
    public float maxTime;

    [SerializeField] PlantScript parentPlantScript;
    void Start()
    {
        timerUI.SetActive(false);
        timeElapsed = 0f;
        SetMaxTime(parentPlantScript.growTime);
        slider.GetComponent<Slider>().maxValue = maxTime;
    }
    public void SetMaxTime(float growTime)
    {
        maxTime = growTime;
    }    
    public void ResetTimer(float timeNull)
    {
        timeElapsed = 0;
    }    
        
    void Update()
    {
        
        if (timeElapsed < maxTime && parentPlantScript.growthActive)
        {
            timerUI.SetActive(true);
            statusTextHolder.GetComponent<TextMeshProUGUI>().text = "Groeien";
            timeElapsed += Time.deltaTime;
            slider.GetComponent<Slider>().value = timeElapsed;
        }
        else
        {
            timerUI.SetActive(false);
            
        }
    }
}
