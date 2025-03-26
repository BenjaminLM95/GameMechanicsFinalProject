using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int maxHp;
    [SerializeField] private int currentHp;
    public int hp;
    public SpriteRenderer spriteRenderer;
    public Sprite _spriteHP1;
    public Sprite _spriteHP2;
    public Sprite _spriteDefault;
    [SerializeField] private int hitBallColor;
    private string colorName;
    public BrickCountManagement pointManagement = null; 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        hp = maxHp;
        currentHp = maxHp;

        pointManagement = GameObject.FindObjectOfType<BrickCountManagement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (hp != currentHp)
        {
            hp = currentHp;
            if (hp > 0)
                UpdateSprite(hp);
            else
            {
                pointManagement.getOnePoint(); 
                this.gameObject.SetActive(false);
            }
        }
    }

    public void UpdateSprite(int health)
    {
        switch (health)
        {
            case 2:
                spriteRenderer.sprite = _spriteHP2;
                break;
            case 1:
                spriteRenderer.sprite = _spriteHP1;
                break;
            default:
                spriteRenderer.sprite = _spriteDefault;
                break;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hitBallColor = collision.gameObject.GetComponent<BallMovement>().currentNumState;

            if (isColorMatches(hitBallColor))
            {
                currentHp--;
                if (currentHp < 0)
                    currentHp = 0;
            }
        }
    }

    public bool isColorMatches(int ballState) 
    {
        switch (ballState) 
        {
            case 1:
                colorName = "Blue";
                break;
            case 2:
                colorName = "Red";
                break;
            case 3:
                colorName = "Green";
                break;
            default:
                colorName = "Black";
                break;
        }

        if (colorName == this.gameObject.tag)
            return true;
        else
            return false; 
    }
}
