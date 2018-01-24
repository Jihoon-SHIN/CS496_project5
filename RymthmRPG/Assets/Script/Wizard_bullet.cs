using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard_bullet : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            if (collision.CompareTag("Turret"))
            {
                collision.GetComponent<TurretAI>().Damage(1);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<mosterAI>().Damage(1);
                Debug.Log("Hello");
                Destroy(gameObject);
            }
            if (collision.CompareTag("Wizard"))
            {
                collision.GetComponent<Player>().Healing(1);
            }
            if (collision.CompareTag("KnifeMan"))
            {
                collision.GetComponent<Player>().Healing(1);
                
            }
            if (collision.CompareTag("Brook"))
            {
                collision.GetComponent<Player>().Healing(1);
                Destroy(gameObject);
            }

        }
    }
}
