using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class EndCredits : MonoBehaviour
{
    public GameObject _gameManager = null;
    public TimeCounting theTime = null;
    private string finalTime;
    public TextMeshProUGUI finalTimeText; 
    // Start is called before the first frame update
    void Start()
    {
        theTime = GameObject.FindObjectOfType<TimeCounting>();
        finalTime = theTime.getTheFinalTime(); 
        finalTimeText.text = finalTime; 
        _gameManager = GameObject.Find("GameManager");
        _gameManager.SetActive(false);
        Invoke("EndGame", 10f); 
    }

    void EndGame() 
    {
        Application.Quit(); 
    }
}
