using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Metronome : MonoBehaviour
{

    public int r_beat = 1;
    private Animator animator;
    private static bool Fibertimeis = false;


    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("BeatTime", r_beat);
        if (Fibertimeis)
        {
            animator.SetBool("FiberTime", true);
        }
        else
        {
            animator.SetBool("FiberTime", false);
        }
    }

    void FixedUpdate()
    {
        r_beat = Timecheck.getbeat();
    }

    public static void setfiberstate(bool fiber)
    {
        Fibertimeis = fiber;
    }

}
