using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_Cone : MonoBehaviour {

    public TurretAI turretAI;
    public bool isLeft = true;

    private void Awake()
    {
        //turretAI = GameObject.FindGameObjectWithTag("Turret").GetComponent<TurretAI>();
        turretAI = gameObject.GetComponentInParent<TurretAI>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("OnePun") || collision.CompareTag("KnifeMan") || collision.CompareTag("Wizard") || collision.CompareTag("Brook"))
        {
            if (isLeft)
            {
                turretAI.Attack(true);
            }
        }
    }
}
