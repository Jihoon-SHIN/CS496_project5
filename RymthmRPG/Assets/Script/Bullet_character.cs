using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_character : MonoBehaviour {

    public Transform Range;
    public float BulletRange;

    private float distance;
    private bool checking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            if (collision.CompareTag("Turret"))
            {
                collision.GetComponent<TurretAI>().Damage(2);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<mosterAI>().Damage(2);
                Destroy(gameObject);
            }
            if (collision.CompareTag("Walking_enemy"))
            {
                collision.GetComponent<mon2_walking>().Damage(2);
                Destroy(gameObject);
            }

        }
    }

}
