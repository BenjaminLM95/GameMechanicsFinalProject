using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BallMovement : MonoBehaviour
{
    Vector3 dir = new Vector3();
    float bulletSpeed;
    float iBulletSpeed = 3f;
    public float raycastDistance;
    public RaycastHit2D hit;
    public LayerMask obstacles;
    private Vector3 initialPosition;
    public SpriteRenderer ballColor;
    [SerializeField] private int numState;
    public int currentNumState;
    public Rigidbody2D rb;
    public bool superBall;
    public AudioSource src;
    public AudioClip aClip;
    public LivesMagement liveManagement = null; 
   


    // Start is called before the first frame update
    void Start()
    {
        dir = new Vector3(1, 1, 0);
        initialPosition = this.gameObject.transform.position;
        bulletSpeed = iBulletSpeed;
        ballColor = gameObject.GetComponent<SpriteRenderer>();
        numState = 2;
        raycastDistance = iBulletSpeed / 10;
        superBall = false;       
        src.clip = aClip;
        liveManagement = GameObject.FindObjectOfType<LivesMagement>();


    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position += dir * bulletSpeed * Time.deltaTime);
        hit = Physics2D.Raycast(transform.position, dir, raycastDistance, obstacles);
        Debug.DrawLine(transform.position, transform.position + dir * raycastDistance, hit.collider == null ? Color.blue  : Color.red, 0.01f);

        if (hit)
        {
            dir = Vector3.Reflect(dir, hit.normal);
            src.Play();
        }

        if (this.gameObject.transform.position.y < -10)
        {
            if (this.name == "Ball")
            {
                Debug.Log("-1 point");
                liveManagement.ReduceLife(); 
                this.gameObject.transform.position = initialPosition;
                bulletSpeed = iBulletSpeed;
                dir = new Vector3(1, 1, 0);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if(numState != currentNumState) 
        {
            currentNumState = numState;
            changeBallColor(currentNumState); 
        }

    }

    public void ballfaster()
    {
        bulletSpeed *= 1.25f;
    }

    public void changeBallColor(int num) 
    {
        switch (num) 
        {
            case 1:
                ballColor.color = Color.blue;
                numState = 1;
                break;
            case 2:
                ballColor.color = Color.red;
                numState = 2;
                break;
            case 3:
                ballColor.color = Color.green;
                numState = 3;
                break;
            case 4:
                ballColor.color = Color.Lerp(Color.yellow, Color.grey, 0.25f);
                break;
                
            default:
                ballColor.color = Color.black;
                numState = 0; 
                break; 
        }

    }

    public void superBallActive() 
    {
        changeBallColor(4);
        superBall = true; 
        Invoke("defaultBallValues", 5f); 

    }

    public void defaultBallValues() 
    {
        changeBallColor(2);
        superBall = false; 
    }

    public Vector3 GetInitialPosition() 
    {
        return initialPosition; 
    }

    public void gettingMoreLives(int num) 
    {
        liveManagement.IncreaseLives(num); 
    }
}
