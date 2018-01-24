using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Penestrate : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            if(collision.CompareTag("Brook"))
            {
                collision.GetComponent<Player>().Damage(1);
            }
            if (collision.CompareTag("KnifeMan"))
            {
                collision.GetComponent<Player>().Damage(1);
            }
            if (collision.CompareTag("Wizard"))
            {
                collision.GetComponent<Player>().Damage(1);
                Destroy(gameObject);
            }
        }
    }
}
