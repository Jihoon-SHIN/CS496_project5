﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true)
        {
            if (collision.CompareTag("OnePun")|| collision.CompareTag("KnifeMan")|| collision.CompareTag("Wizard")|| collision.CompareTag("Brook"))
            {
                collision.GetComponent<Player>().Damage(1);
                Destroy(gameObject);
            }
        }
    }
}

