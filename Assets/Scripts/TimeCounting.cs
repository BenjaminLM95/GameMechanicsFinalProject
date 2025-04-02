using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounting : MonoBehaviour
{
    private float gameTime;
    public TextMeshProUGUI textTimer;
    int hours;
    int minutes;
    int seconds;
    string sHours;
    string sMinutes;
    string sSeconds;

    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime;

        hours = (int)(gameTime / 3600);
        minutes = (int)(gameTime / 60);
        seconds = (int)(gameTime % 60);

        sHours = hours.ToString("00");
        sMinutes = minutes.ToString("00");
        sSeconds = seconds.ToString("00"); 

        if (hours > 0)
        {
            textTimer.text = "Time: " + sHours + ":" + sMinutes + ":" + sSeconds;
        }
        else
        {
            textTimer.text = "Time: " + sMinutes + ":" + sSeconds;
        }
        
        
    }
}
