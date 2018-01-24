using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timecheck : MonoBehaviour
{

    static float beat = 0;
    static float memory = 0;
    static bool Fiber = false;

    // Update is called once per frame
    public static void setbeat(float timelap)
    {

        if (Fiber)
        {
            memory = beat;
            beat = (timelap * 140 * 2f / (60f)) % 8 + 1;
        }
        else
        {
            memory = beat;
            beat = (timelap * 130 * 2f / (60f)) % 8 + 1;
        }
    }

    public static void setfibertime(bool fiber)
    {
        Fiber = fiber;
    }


    public static int getbeat()
    {
        if (memory > beat)
        {
            return 0;
        }
        return (int)beat;
    }

}
