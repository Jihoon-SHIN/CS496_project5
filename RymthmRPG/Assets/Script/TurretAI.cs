using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {

    //Integers
    public int CurHealth;
    public int MaxHealth=5;
    //floats
    public float distance;
    public float wakeRange;
    public float shootInterval;
    public float bulletSpeed;
    public float bulletTimer;

    //Booleans
    public bool awake = false;
    public bool lookingLeft = true;

    //References
    public GameObject bullet;
    public Transform target;
    public Animator anim;
    public Transform shootPointLeft, shootPointRight;

    //private gameMaster gm;

    void Awake()
    {
        //gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<gameMaster>();
        anim = gameObject.GetComponent<Animator>();    
    }
    void Start()
    {
        CurHealth = MaxHealth;    
    }
    void Update()
    {
        anim.SetBool("Awake", awake);
        anim.SetBool("LookingLeft", lookingLeft);

        RangeCheck();

        if(target.transform.position.x < transform.position.x)
        {
            lookingLeft = true;
        }
        if(CurHealth <= 0)
        {
            Destroy(gameObject);
            //gm.points += 20;
        }
    }

    void RangeCheck()
    {
        //target is a player
        distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance < wakeRange)
        {
            awake = true;
        }

        if (distance > wakeRange)
        {
            awake = false;
            
        }


    }
    public void Attack(bool attackingLeft)
    {
        bulletTimer += Time.deltaTime;
        if(bulletTimer>= shootInterval)
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

}
