using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounting : MonoBehaviour
{
    private float gameTime;
    public TextMeshProUGUI textTimer;
    private int hours;
    private int minutes;
    private int seconds;
    private string sHours;
    private string sMinutes;
    private string sSeconds;
    private string finalTime;
    private bool counting; 

    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0f;
        counting = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(counting)
        gameTime += Time.deltaTime;

        hours = (int)(gameTime / 3600);
        minutes = (int)(gameTime / 60);
        seconds = (int)(gameTime % 60);

        sHours = hours.ToString("00");
        sMinutes = minutes.ToString("00");
        sSeconds = seconds.ToString("00"); 

        if (hours > 0 && counting)
        {
            textTimer.text = "Time: " + sHours + ":" + sMinutes + ":" + sSeconds;
        }
        else if (counting)
        {
            textTimer.text = "Time: " + sMinutes + ":" + sSeconds;
        }
        
        
    }

    public string getTheFinalTime() 
    {
        counting = false;
        return "Time: " + sHours + ":" + sMinutes + ":" + sSeconds;
    }
}
