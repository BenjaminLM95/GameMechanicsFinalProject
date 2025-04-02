using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesMagement : MonoBehaviour
{
    private int lives;
    private int currentLife; 
    public TextMeshProUGUI livesText; 

    // Start is called before the first frame update
    void Start()
    {
        lives = 5;
        currentLife = lives;
        livesText.text = "Lives: " + currentLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(lives != currentLife) 
        {
            currentLife = lives;
            livesText.text = "Lives: " + currentLife;
        }
           
    }

    public void ReduceLife() 
    {
        lives -= 1;
        if (lives < 0) 
        {
            lives = 0; 
        }
    }

    public void IncreaseLives(int num) 
    {
        lives += num;
    }

}
