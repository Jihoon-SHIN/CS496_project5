using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemaster : MonoBehaviour {

    public int points;

    public Text RhythmText;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {

            RhythmText.text = (Timecheck.getbeat()).ToString();

        }
    }
}
