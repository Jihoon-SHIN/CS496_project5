using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon2_walking : MonoBehaviour {

    public float movePower = 0.5f;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;

    public bool isTracing = false;
    private bool isAttack;
    public GameObject traceTarget;

    private float moveTimer =0;
    private bool isMove= false;
    //Integers
    public int CurHealth;
    public int MaxHealth = 2;

    public bool mon2_attack = false;
    private float attackTimer = 0;

    Collider2D collider2d;
    private void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine("ChangeMovement");
        CurHealth = MaxHealth;
        Physics2D.IgnoreLayerCollision(8, 8, true);
    }
    private void Update()
    {

        if (CurHealth <= 0)
        {
            animator.SetBool("Dead", true);
            StartCoroutine("destory_moster");
        }
    }
    private void FixedUpdate()
    {
        Move();
        if (Timecheck.getbeat() == 0 && !isMove && !mon2_attack)
        {
            isMove = true;
        }



        
    }

    private void Move()
    {
        if (isMove && !mon2_attack)
        {
            Vector3 moveVelocity = Vector3.zero;
            string dist = "";

            if (isTracing)
            {
                Vector3 playerPos = traceTarget.transform.position;
                dist = "Left";
            }
            else
            {
                if (movementFlag == 1)
                {
                    dist = "Left";
                }
                else if (movementFlag == 2)
                {
                    dist = "Right";
                }
            }
            if (dist == "Left")
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (dist == "Right")
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(1, 1, 1);
            }
            transform.position += moveVelocity * movePower * Time.deltaTime;
            moveTimer += 1;

            if (moveTimer > 50)
            {
                isMove = false;
                moveTimer = 0;
            }
        }


    }
    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);
        if (movementFlag == 0)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }
        yield return new WaitForSeconds(1f);

        StartCoroutine("ChangeMovement");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && !mon2_attack)
        {
            if (collision.CompareTag("Character"))
            {
                traceTarget = collision.gameObject;
                StopCoroutine("ChangeMovement");
            }
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.isTrigger != true && !mon2_attack)
        {
            if (collision.CompareTag("Character"))
            {
                isTracing = true;
                animator.SetBool("isMoving", true);
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger != true && !mon2_attack)
        {
            if (collision.CompareTag("Character"))
            {
                isTracing = false;
                StartCoroutine("ChangeMovement");
            }
        }
    }
    public void mon2attack()
    {
        animator.SetBool("Attacking", true);
        mon2_attack = true;
        isMove = false;
        StopCoroutine("ChangeMovement");
    }

    public void stopattack()
    {
        animator.SetBool("Attacking", false);
    }
    public void mon2Trace()
    {
        animator.SetBool("Attacking", false);
        mon2_attack = false;
        isMove = true;
        animator.SetBool("isMoving", true);
    }
    IEnumerator destory_moster()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }
    public void Damage(int dmg)
    {
        CurHealth -= dmg;
        gameObject.GetComponent<Animation>().Play("Character_RedFlash");
    }
    
}
