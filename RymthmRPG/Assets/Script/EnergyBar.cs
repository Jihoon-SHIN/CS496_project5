using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnergyBar : MonoBehaviour {

    public Sprite[] energyBar_Brook;
    public Sprite[] energyBar_Knife;
    public Sprite[] energyBar_Wizard;
    public Sprite[] energyBar_OnePun;

    public Image HearUI_Brook;
    public Image HearUI_Knife;
    public Image HearUI_Wizard;
    public Image HearUI_OnePun;

    private int temp;
    private int temp1;

    private Player player_Brook;
    private Player player_Knife;
    private Player player_Wizard;
    private Player player_OnePun;

    private void Start()
    {
        player_Brook = GameObject.FindGameObjectWithTag("Brook").GetComponent<Player>();
        player_Knife = GameObject.FindGameObjectWithTag("KnifeMan").GetComponent<Player>();
        player_Wizard = GameObject.FindGameObjectWithTag("Wizard").GetComponent<Player>();
        //player_OnePun = GameObject.FindGameObjectWithTag("OnePun").GetComponent<Player>();
    }

    private void Update()
    {
        if (player_Brook.CurHealth <= 0)
        {
            player_Brook.CurHealth = 0;
        }
        if (player_Knife.CurHealth <= 0)
        {
            player_Knife.CurHealth = 0;
        }
        if (player_Brook.CurHealth >= 7)
        {
            temp = 7;
        }
        else
        {
            temp = player_Brook.CurHealth;
        }
        HearUI_Brook.sprite = energyBar_Brook[temp];

        if(player_Wizard.CurHealth > 7)
        {
            temp1 = 7;
        }
        else
        {
            temp1 = player_Wizard.CurHealth;
        }
        HearUI_Knife.sprite = energyBar_Knife[player_Knife.CurHealth];

        if (player_Wizard.CurHealth == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            HearUI_Wizard.sprite = energyBar_Wizard[temp1];
        }
        //HearUI_OnePun.sprite = energyBar_OnePun[player_OnePun.CurHealth];

    }
}
