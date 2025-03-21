using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 pos = new Vector3();
    float bulletSpeed;
    float iBulletSpeed = 1.0f;
    public RaycastHit2D hit;
    public LayerMask obstacles;
    private Vector3 initialPosition;
    public SpriteRenderer ballColor;
    private int numState;
    public int currentNumState; 


    // Start is called before the first frame update
    void Start()
    {
        pos = new Vector3(1, 1, 0);
        initialPosition = this.gameObject.transform.position;
        bulletSpeed = iBulletSpeed;
        ballColor = gameObject.GetComponent<SpriteRenderer>();
        currentNumState = 2; 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += pos * bulletSpeed * Time.deltaTime;
        hit = Physics2D.Raycast(transform.position, pos, 0.1f, obstacles);

        if (hit)
        {
            pos = Vector3.Reflect(pos, hit.normal);


        }

        if (this.gameObject.transform.position.y < -10)
        {
            if (this.name == "Ball")
            {
                Debug.Log("-1 point");
                this.gameObject.transform.position = initialPosition;
                bulletSpeed = iBulletSpeed;
                pos = new Vector3(1, 1, 0);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }

        if(numState != currentNumState) 
        {
            numState = currentNumState;
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
                break;
            case 2:
                ballColor.color = Color.red;
                break;
            case 3:
                ballColor.color = Color.green;
                break;
            default:
                ballColor.color = Color.black;
                break; 
        }

    }
}
