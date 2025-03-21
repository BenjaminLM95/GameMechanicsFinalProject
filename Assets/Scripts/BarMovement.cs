using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour
{
    private float speed;
    private Vector3 movement;
    private Vector3 initialScale;
    public SpriteRenderer spriteRenderer;
    public Sprite _spriteDefault;
    public Sprite _BlueBar;
    public Sprite _RedBar;
    public Sprite _GreenBar;
    public BallMovement _ball; 
    
    private Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        movement = new Vector3(0, 0, 0);
        initialScale = this.transform.localScale;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _spriteDefault;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement = new Vector2(1, 0);
             
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement = new Vector2(-1, 0);
           
        }

        if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
            barStatic(); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeSprite(1);
            _ball.changeBallColor(1); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            changeSprite(2);
            _ball.changeBallColor(2);
        }


        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            changeSprite(3);
            _ball.changeBallColor(3);
        }

    }

    private void FixedUpdate()
    {
        rigidbody2d.velocity = movement * speed; 
    }

    private void barStatic() 
    {
        movement = new Vector2(0, 0); 
    }

    public void originalScale()
    {
        this.transform.localScale = initialScale;
    }

    public void changeSprite(int n) 
    {
        switch (n) 
        {
            case 1:
                spriteRenderer.sprite = _BlueBar;
                break;
            case 2:
                spriteRenderer.sprite = _RedBar;
                break;
            case 3:
                spriteRenderer.sprite = _GreenBar;
                break;
            default:
                spriteRenderer.sprite = _spriteDefault;
                break; 

        }
    }
}
