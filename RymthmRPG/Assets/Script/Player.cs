using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //Floats
    public float speed = 50f;
    public float maxSpeed = 3;
    public bool isMove = false;
    public bool isRMove = false;
    public int Movetime = 0;
    public float jumpPower = 50f;
    private List<int> nulllist = new List<int>();

    //References
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool Fever;

    public int CurHealth;
    public int MaxHealth = 7;

    // Use this for initialization
    void Start() {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        CurHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));

        if (CurHealth <= 0)
        {
            Die();
        }
        if (CurHealth > MaxHealth)
        {
            CurHealth = MaxHealth;
        }

        Fever = Moveandjump.getisFiber();
    }

    void FixedUpdate()
    {

        float h = 0;
        if (isMove || Fever)
        {
            h = 1;

        }
        else if (isRMove)
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


        if (Timecheck.getbeat() == 0 && (!isMove || !isRMove))
        {
            if (Commandcheck.Commandis() == "124578")
            {
                rb2d.velocity = Vector2.zero;
                Vector2 jumpVelocity = new Vector2(0, 5);
                rb2d.AddForce(jumpVelocity, ForceMode2D.Impulse);
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
    void Die()
    {

        Destroy(gameObject);
    }

    public void Damage(int dmg)
    {
        CurHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Character_RedFlash");

    }

    public void Healing(int dmg)
    {
        CurHealth += dmg;
        gameObject.GetComponent<Animation>().Play("Character_Green");
        
    }

}
