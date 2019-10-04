using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Range (0, 10)]
    public float speed;
    public GameObject myFeet;
    private float startTime;
    private bool TimeToStop;
    private float lastFrame;
    private int prevDir;
    private FootCheck groundCheck;
    public int jumpForce;
    
    
    // Start is called before the first frame update
    void Start()
    {
        startTime = 0;
        groundCheck = myFeet.GetComponent<FootCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            if (startTime == 0)
            {
                startTime = Time.time;
            }
            Move((int)Mathf.Sign(Input.GetAxis("Horizontal")), startTime);
            lastFrame = Input.GetAxis("Horizontal");
        }
        else
        {
            if (lastFrame != 0)
            {
                TimeToStop = true;
                startTime = Time.time;
                prevDir = (int)Mathf.Sign(lastFrame);
                lastFrame = 0;
            }
            if (TimeToStop)
            {
                Stop(prevDir, startTime);
            }
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }

    //Force = Mass times Acceleration
    void Move(int direction, float myTime)
    {
        this.GetComponent<Rigidbody2D>().velocity = (new Vector2(speed * direction * accelFunc(Time.time - myTime), this.GetComponent<Rigidbody2D>().velocity.y));
    }

    void Stop(int direction, float myTime)
    {
        if (deccelFunc(Time.time - myTime) > 0)
        {
            this.GetComponent<Rigidbody2D>().velocity = (new Vector2((speed/2) * direction * deccelFunc(Time.time - myTime), this.GetComponent<Rigidbody2D>().velocity.y));
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
            TimeToStop = false;
            startTime = 0;
        }
    }

    //Function that calculates the change in velocity as a function of time.
    //Ideally goes from 0 to top in about .5 sec
    //To get this behavior we have a(t) = 9.6(-.2*3.7^-2.6t - .5) + 1
    float accelFunc(float time)
    {
        return Mathf.Pow(4 * time, 2) > 1 ? 1 : Mathf.Pow(4 * time, 2);
    }


    //Another acceleration function which models the decay in velocity as the player lets off of the control.
    //Ideally goes from top speed to 0 in about .1 or .2 sec?
    float deccelFunc(float time)
    {
        return (float)System.Math.Round((double)Mathf.Exp(-64 * time), 2);
    }

    void jump()
    {
        if (!groundCheck.isGrounded)
        {
            return;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
        return;
    }
}
