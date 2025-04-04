using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private bool hit;
    public GameObject BlockImage; 
    public SpriteRenderer spriteRenderer;
    public Sprite _spriteDefault;
    public Sprite _spriteEffect1;
    public Sprite _spriteEffect2;
    public Sprite _spriteEffect3;
    public Sprite _spriteEffect4;
    public Sprite _spriteEffect5;
    public GameObject playerBar;
    public BallMovement _ballMovement;
    public GameObject extraBall;
    

    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        spriteRenderer = BlockImage.gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _spriteDefault;
        playerBar = GameObject.Find("Paddle");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (!hit)
            {
                hit = true;
                GetAnEffect();                
            }
        }
    }

    private void GetAnEffect()
    {
        System.Random rnd = new System.Random();
        int number = rnd.Next(0, 100);
        Vector2 scaleChange = playerBar.gameObject.transform.localScale;
        scaleChange.x += 0.2f; 

        if (number < 20)
        {            
            spriteRenderer.sprite = _spriteEffect1;
            CreateSecondBall();
        }
        else if (number < 40)
        {
            spriteRenderer.sprite = _spriteEffect2;
            _ballMovement.ballfaster();
        }
        else if(number < 60) 
        {
            spriteRenderer.sprite = _spriteEffect3;
            _ballMovement.superBallActive(); 
        }
        else if(number < 80)
        {
            spriteRenderer.sprite = _spriteEffect4;
            playerBar.gameObject.transform.localScale = scaleChange; 
        }
        else 
        {
            spriteRenderer.sprite = _spriteEffect5;
            _ballMovement.gettingMoreLives(2); 
        }

        Debug.Log(number);
    }

    public void CreateSecondBall()
    {
        GameObject tempBall = Instantiate(extraBall, _ballMovement.GetInitialPosition(), this.transform.rotation) as GameObject;
        Rigidbody2D tempRigidBodyBall = tempBall.GetComponent<Rigidbody2D>();
        tempRigidBodyBall.gravityScale = 0f;
    }

    public void resumeTime() 
    {
        Time.timeScale = 1; 
    }
}
