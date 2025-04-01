using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeCounting : MonoBehaviour
{
    private float gameTime;
    public TextMeshProUGUI textTimer; 
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 0f; 
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime; 

        textTimer.text = "Time: " + gameTime;
        
    }
}
