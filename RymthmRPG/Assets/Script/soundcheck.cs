using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundcheck : MonoBehaviour {

    public AudioSource CommandS;
    public AudioSource S1357;
    public AudioSource S2468;
    public AudioSource S12357;



    // Use this for initialization
    void Start () {
        CommandS = GameObject.Find("커맨드").GetComponent<AudioSource>();
        S1357 = GameObject.Find("1357").GetComponent<AudioSource>();
        S2468 = GameObject.Find("2468").GetComponent<AudioSource>();
        S12357 = GameObject.Find("12357").GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        /*
        if (!Commandcheck.righttimming(time_list))
        {
            Debug.Log("Wrong Timming!");
        }
        beat_list = Commandcheck.timetobeat(time_list);
        if (Commandcheck.rightcommand(beat_list) == "Chr_1")
        {
            S12357.Play();
        }
        else if (Commandcheck.rightcommand(beat_list) == "Chr_2")
        {
            S1357.Play();
        }
        else if (Commandcheck.rightcommand(beat_list) == "Chr_3")
        {
            S2468.Play();
        }
        */
    }
}
