using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosterAI : MonoBehaviour {

    //Integers
    public int CurHealth;
    public int MaxHealth = 15;
    //floats
    public float distance;
    public float wakeRange;
    public float shootInterval =1 ;
    public float bulletSpeed = 3;
    public float bulletTimer;

    //Booleans
    public bool attack = false;
    public bool lookingLeft = true;

    private bool dead = true;
    private bool isdead = false;
    //References
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;


    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        CurHealth = MaxHealth;
        Physics2D.IgnoreLayerCollision(8, 8, true);
    }
    void Update()
    {
        anim.SetBool("Attacking", attack);

        RangeCheck();

        if (target.transform.position.x < transform.position.x)
        {
            lookingLeft = true;
        }
        if (CurHealth <= 0)
        {
            anim.SetBool("Dead", true);
            StartCoroutine("destory_moster");
            //Destroy(gameObject);
            //gm.points += 20;
        }
    }

    void RangeCheck()
    {
        //target is a player
        distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < wakeRange)
        {
            attack = true;
            Attack(true);
        }

        if (distance > wakeRange)
        {
            attack = false;

        }


    }
    public void Attack(bool attackingLeft)
    {
        bulletTimer += Time.deltaTime;
        if (bulletTimer >= shootInterval)
        {
            Vector2 direction = target.transform.position - transform.position;
            direction.Normalize();
            if (attackingLeft && Timecheck.getbeat() == 0)
            {
                GameObject bulletClone;
                bulletClone = Instantiate(bullet, shootPointLeft.transform.position, shootPointLeft.transform.rotation) as GameObject;
                bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

                bulletTimer = 0;
            }

        }
    }

    public void Damage(int dmg)
    {
        CurHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Character_RedFlash");
    }

    IEnumerator destory_moster()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }



}
