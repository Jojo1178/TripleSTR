using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycleManager : MonoBehaviour
{
    public Light light;

    private bool day;
    private float currentPeriodDuration;
    private float currentLightIntensity;
    
    private float dayDuration = 15f;
    private float dayDurationVariator = 0.1f;
    private float daylightIntensity = 0.5f;
    private float daylightIntensityVariator = 0.01f;

    private float nightDuration = 15f;
    private float nightDurationVariator = 0.1f;
    private float nightlightIntensity = 0.05f;
    private float nightlightIntensityVariator = 0.01f;
    
    void Start()
    {
        day = false;
        currentPeriodDuration = nightDuration;
        currentLightIntensity = nightlightIntensity;

        StartCoroutine(onCoroutine());
    }

    IEnumerator onCoroutine()
    {
        while (true)
        {
            
            changeCycle();
            Debug.Log("Current cycle: day=" + day + ", duration=" + currentPeriodDuration+", intensity="+currentLightIntensity);
            yield return new WaitForSeconds(currentPeriodDuration);
        }
    }

    private void changeCycle()
    {
        if (day)
        {
            //Invoke Night:

            //Les nuits deviennent de plus en plus longues et de plus en plus sombres:
            nightDuration = nightDuration + nightDurationVariator;
            nightlightIntensity = nightlightIntensity - nightlightIntensityVariator;

            day = false;
            currentPeriodDuration = nightDuration;
            currentLightIntensity = nightlightIntensity;
        }
        else
        {
            //Invoke Day:

            //Les jours deviennent de plus en plus courts et de plus en plus sombres:
            dayDuration = dayDuration - dayDurationVariator;
            daylightIntensity = daylightIntensity - daylightIntensityVariator;

            day = true;
            currentPeriodDuration = dayDuration;
            currentLightIntensity = daylightIntensity;
        }

        //Change light intensity:
        light.intensity = currentLightIntensity;
    }
}
