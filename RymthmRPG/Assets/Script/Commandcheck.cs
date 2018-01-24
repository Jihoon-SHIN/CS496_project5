using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Commandcheck : MonoBehaviour
{

    public static Dictionary<string, List<int>> skill_template = new Dictionary<string, List<int>>();
    public static List<string> keylist;
    public static List<List<int>> valuelist;
    List<int> someoneskill = new List<int>();
    public static List<int> mkbeatlist;
    private static float BPM = 0;
    private static float BPM1 = 130;
    private static float BPM2 = 140;
    public static string Command = null;
    public static string returnvalue = null;
    public static bool Fibercheck = false;
    public static float Beat;


    // Use this for initialization
    void Start()
    {
        someoneskill.Add(1);
        someoneskill.Add(2);
        someoneskill.Add(3);
        //someoneskill.Add(4);
        someoneskill.Add(5);
        //someoneskill.Add(6);
        someoneskill.Add(7);
        //someoneskill.Add(8);
        skill_template.Add("12357", someoneskill);
        someoneskill = new List<int>();
        someoneskill.Add(1);
        //someoneskill.Add(2);
        someoneskill.Add(3);
        //someoneskill.Add(4);
        someoneskill.Add(5);
        //someoneskill.Add(6);
        someoneskill.Add(7);
        //someoneskill.Add(8);
        skill_template.Add("1357", someoneskill);
        someoneskill = new List<int>();
        //someoneskill.Add(1);
        someoneskill.Add(2);
        //someoneskill.Add(3);
        someoneskill.Add(4);
        //someoneskill.Add(5);
        someoneskill.Add(6);
        //someoneskill.Add(7);
        someoneskill.Add(8);
        skill_template.Add("2468", someoneskill);
        someoneskill = new List<int>();
        someoneskill.Add(1);
        someoneskill.Add(2);
        someoneskill.Add(3);
        someoneskill.Add(4);
        someoneskill.Add(5);
        someoneskill.Add(6);
        someoneskill.Add(7);
        someoneskill.Add(8);
        skill_template.Add("12345678", someoneskill);
        someoneskill = new List<int>();
        someoneskill.Add(1);
        //someoneskill.Add(2);
        someoneskill.Add(3);
        someoneskill.Add(4);
        //someoneskill.Add(5);
        someoneskill.Add(6);
        someoneskill.Add(7);
        someoneskill.Add(8);
        skill_template.Add("134678", someoneskill);
        someoneskill = new List<int>();
        //someoneskill.Add(1);
        someoneskill.Add(2);
        //someoneskill.Add(3);
        someoneskill.Add(4);
        someoneskill.Add(5);
        //someoneskill.Add(6);
        someoneskill.Add(7);
        //someoneskill.Add(8);
        skill_template.Add("2457", someoneskill);
        someoneskill = new List<int>();
        //someoneskill.Add(1);
        //someoneskill.Add(2);
        someoneskill.Add(3);
        someoneskill.Add(4);
        //someoneskill.Add(5);
        someoneskill.Add(6);
        //someoneskill.Add(7);
        someoneskill.Add(8);
        skill_template.Add("3468", someoneskill);
        someoneskill = new List<int>();
        someoneskill.Add(1);
        someoneskill.Add(2);
        //someoneskill.Add(3);
        someoneskill.Add(4);
        someoneskill.Add(5);
        //someoneskill.Add(6);
        someoneskill.Add(7);
        someoneskill.Add(8);
        skill_template.Add("124578", someoneskill);
        someoneskill = new List<int>();

        keylist = new List<string>(skill_template.Keys);
        valuelist = new List<List<int>>(skill_template.Values);
    }

    public static List<int> timetobeat(List<float> timelist)
    {
        if (!Fibercheck)
        {
            BPM = BPM1;
            Beat = 8;
        }
        else
        {
            BPM = BPM2;
            Beat = 8;
        }
        mkbeatlist = new List<int>();
        for (int i = 0; i < timelist.Count; i++)
        {
            if (timelist[i] % (30f / BPM) < (15f / BPM))
            {
                if ((timelist[i] * BPM * 2f / (60f)) % Beat <= 0)
                {
                    mkbeatlist.Add(1);
                }
                else
                {
                    float k = (timelist[i] * BPM * 2f / (60f)) % Beat + 1;

                    mkbeatlist.Add((int)k);
                }
            }
            else
            {
                float k = (timelist[i] * BPM * 2f / (60f)) % Beat + 2;
                mkbeatlist.Add((int)k);
            }
        }
        return mkbeatlist;
    }

    public static void rightcommand(List<int> beatlist)
    {

        Command = null;
        for (int i = 0; i < keylist.Count; i++)
        {
            if (beatlist.Count == valuelist[i].Count)
            {
                for (int j = 0; j < beatlist.Count; j++)
                {
                    if (beatlist[j] != valuelist[i][j])
                    {
                        break;
                    }
                    else
                    {
                        if (j == beatlist.Count - 1)
                        {
                            Command = keylist[i];

                        }
                    }
                }
            }
        }

    }


    public static bool fibercommandcheck(List<int> beatlist, List<int> Fibercommand)
    {
        if (beatlist.Count == Fibercommand.Count)
        {
            for (int i = 0; i < beatlist.Count; i++)
            {
                if (beatlist[i] != Fibercommand[i])
                {
                    break;
                }
                else
                {
                    if (i == beatlist.Count - 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        return false;
    }

    public static string Commandis()
    {
        returnvalue = Command;

        return returnvalue;
    }

    public static void setFiber(bool fiber)
    {
        Fibercheck = fiber;
    }
}
