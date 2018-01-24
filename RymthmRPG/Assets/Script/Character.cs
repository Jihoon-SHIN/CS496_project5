using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    //Floats
    public float speed = 50f;
    public float maxSpeed = 3;
    public bool isMove = false;
    public bool isRMove = false;
    public int Movetime = 0;

    private List<int> nulllist = new List<int>();

    //References
    private Rigidbody2D rb2d;
    private bool Fevertime = false;


    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Fevertime = Moveandjump.getisFiber();
    }

    void FixedUpdate()
    {
        float h = 0;
        if(isMove || Fevertime)
        {
            h = 1;
        }
        else if(isRMove)
        {
            h = -1;
        }
        rb2d.AddForce(Vector2.right * speed * h);
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        else if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }


        if (Timecheck.getbeat() == 0)
        {
            if (Commandcheck.Commandis() == "12357")
            {

            }
            else if (Commandcheck.Commandis() == "1357")
            {
                isMove = true;
                Movetime = 0;
            }
            else if (Commandcheck.Commandis() == "2468")
            {
                isRMove = true;
                Movetime = 0;
            }

        }
        else
        {
            Movetime += 1;
            if (Movetime == 50)
            {
                isMove = false;
                isRMove = false;
                Movetime = 0;
            }
        }
    }
}