using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mon2_attack : MonoBehaviour {

    private bool attacking = false;
    private float attackTimer = 0;
    private float attackCd = 0.3f;
    private bool isattacking = false;
    private bool isWalk = false;
    public mon2_walking mon22;
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponentInParent<Animator>();
        mon22 = gameObject.GetComponentInParent<mon2_walking>();
    }
    private void Update()
    {
        if (Timecheck.getbeat() == 0 && !isattacking)
        {
            attacking = true;
            isattacking = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.isTrigger != true && attacking)
        {
            if(collision.CompareTag("KnifeMan")|| collision.CompareTag("Wizard") || collision.CompareTag("Brook"))
            {
                
                mon22.mon2attack();
                attackTimer += 1;

                if (attackTimer > 20)
                {
                    collision.GetComponent<Player>().Damage(2);
                    isattacking = false;
                    attacking = false;
                    attackTimer = 0;
                    mon22.stopattack();
                }
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            if (collision.CompareTag("KnifeMan") || collision.CompareTag("Wizard") || collision.CompareTag("Brook"))
            {
                mon22.mon2Trace();
            }
        }
    }
}

