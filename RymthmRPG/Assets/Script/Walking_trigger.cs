using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking_trigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.isTrigger!= true)
        {
            if (collision.CompareTag("Character"))
            {
               
            }
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
