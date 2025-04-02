using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrickCountManagement : MonoBehaviour
{
    private int points;
    public TextMeshProUGUI pointCountText;
    public TextMeshProUGUI WinText;
    private int currentPoints;
    public int numberForNextLevel;
    public string nextSceneName;
    
    
    // Start is called before the first frame update
    void Start()
    {
        points = 0;
        currentPoints = points;
        pointCountText.text = "Bricks:  " + currentPoints + " / " + numberForNextLevel;
        WinText.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        if(currentPoints != points) 
        {
            currentPoints = points;
            pointCountText.text = "Bricks:  " + currentPoints + " / " + numberForNextLevel;

            if (currentPoints >= numberForNextLevel)
            {
                WinText.gameObject.SetActive(true);
                Invoke("GoToNextLevel", 2f);
            }
        }
    }

    public void getOnePoint() 
    {
        points++; 
    }

    public void GoToNextLevel() 
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
