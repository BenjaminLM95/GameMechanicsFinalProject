using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrickCountManagement : MonoBehaviour
{
    public int points;
    public TextMeshProUGUI pointCountText;
    public int currentPoints;
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        currentPoints = points; 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints != points) 
        {
            currentPoints = points;
            pointCountText.text = "Points:  " + currentPoints; 
        }
    }

    public void getOnePoint() 
    {
        points++; 
    }
}
