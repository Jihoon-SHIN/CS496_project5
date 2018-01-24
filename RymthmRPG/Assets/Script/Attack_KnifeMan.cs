using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_KnifeMan : MonoBehaviour {
    private bool attacking = false;
    private bool isattack = false;

    private List<int> nulllist = new List<int>();


    private float attackTimer = 0;
    private float attackCd = 0.7f;

    //Projectile for player
    public float shootInterval;
    public float bulletSpeed = 5;
    public float bulletTimer;
    private int Fevertime = 0;

    public GameObject bullet;
    public Transform ShootPoint;

    private Animator anim;
    private bool Fever;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        Fever = Moveandjump.getisFiber();
        if (isattack && !attacking||Fever)
        {
            if (Fever)
            {
                Fevertime += 1;
                if (Fevertime < 10)
                {
                    attacking = true;
                    attackTimer = attackCd;
                    Attack();
                }
                else if (Fevertime > 30)
                {
                    Fevertime = 0;
                }
            }
            else
            {
                attacking = true;
                attackTimer = attackCd;
                Attack();
            }


        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
        anim.SetBool("Attacking", attacking);

        if (Timecheck.getbeat() == 0 && !isattack)
        {
            if (Commandcheck.Commandis() == "2457")
            {
                isattack = true;
            }
            else if(Commandcheck.Commandis() == "134678")
            {
                isattack = true;
            }
        }
        else
        {
            isattack = false;
        }
    }

    public void Attack()
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            //Vector2 direction = -transform.position;
            //direction.Normalize();
            GameObject bulletClone;
            bulletClone = Instantiate(bullet, ShootPoint.transform.position, ShootPoint.transform.rotation) as GameObject;
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0);
            bulletTimer = 0;
        }
    }
}
