using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moveandjump : MonoBehaviour
{

    private int Movetime = 0;
    public float movePower = 0.1f;
    public float jumpPower = 1f;
    public AudioSource BGM;
    public AudioSource FiberBgm;
    public AudioSource playingbgm;
    public AudioSource CommandS;
    public AudioClip audioclip;
    private float time = 0;
    bool Caninputcommand = true;
    public List<float> time_list = new List<float>();
    public List<int> beat_list;
    public float BPM = 0;
    public float BPM1 = 130;
    public float BPM2 = 140;
    Rigidbody2D rigid;

    Vector3 movement;
    bool isJumping = false;
    bool isMove = false;
    bool isRMove = false;
    bool ischeck = false;
    private List<int> nulllist = new List<int>();

    public AudioSource S1357;
    public AudioSource S2468;
    public AudioSource S12357;
    public AudioSource S12345678;
    public AudioSource S134678;
    public AudioSource S124578;
    public AudioSource S3468;
    public AudioSource S2457;

    //피~버~
    public int Comboscore = 0;
    private static bool Fibertime = false;
    private List<int> FiberFirstCommand;
    private List<int> FiberSecondCommand;
    private string string2;
    private string Firstfiberliststr = "";
    private string Secondfiberliststr = "";


    public Text FiberText;
    public Text FiberText2;
    public Text ComboText;
    public Text FeverText;
    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();


        BGM = gameObject.GetComponent<AudioSource>();
        FiberBgm = GameObject.Find("The Game Corner by Schtiffles").GetComponent<AudioSource>();

        playingbgm = BGM;

        CommandS = GameObject.Find("커맨드").GetComponent<AudioSource>();
        S1357 = GameObject.Find("1357").GetComponent<AudioSource>();
        S2468 = GameObject.Find("2468").GetComponent<AudioSource>();
        S12357 = GameObject.Find("12357").GetComponent<AudioSource>();
        S12345678 = GameObject.Find("12345678").GetComponent<AudioSource>();
        S134678 = GameObject.Find("134678").GetComponent<AudioSource>();
        S124578 = GameObject.Find("124578").GetComponent<AudioSource>();
        S3468 = GameObject.Find("3468").GetComponent<AudioSource>();
        S2457 = GameObject.Find("2457").GetComponent<AudioSource>();
        //renderer = gameObject.GetComponent<Renderer>();
        playingbgm.Play();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Caninputcommand)
        {
            CommandS.Play();
            isJumping = true;
            
        }
    }


    void FixedUpdate()
    {

        if (Timecheck.getbeat() >= 9)
        {
            Caninputcommand = false;
        }
        else
        {
            Caninputcommand = true;
        }
        time = playingbgm.time;
        Timecheck.setbeat(playingbgm.time);
        Move();
        Jump();
    }


    public static bool getisFiber()
    {
        return Fibertime;
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (isRMove)
        {
            //왼쪽으로 움직임
            moveVelocity = Vector3.left;

            //왼쪽으로 보게끔 방향 돌리는것
            transform.localScale = new Vector3(-1, 1, 1);
            //renderer.flipX = true;
            Movetime += 1;
            if (Movetime == 18)
            {
                isRMove = false;
                Movetime = 0;
            }
        }
        if (isMove)
        {
            //오른쪽으로 움직임
            moveVelocity = Vector3.right;

            //오른쪽을 보게끔 하는거
            transform.localScale = new Vector3(1, 1, 1);
            //renderer.flipX = false;
            Movetime += 1;
            if (Movetime == 18)
            {
                isMove = false;
                Movetime = 0;
            }
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    static string FiberBeatString(List<int> Fiberlist)
    {
        string str = "";
        int countnum = 1;
        for (int i = 0; i < Fiberlist.Count; i++)
        {
            while (countnum != Fiberlist[i] && countnum <= 8)
            {
                countnum += 1;
                str += "◇";
            }
            if (countnum <= 8)
            {
                countnum += 1;
                str += "◆";
            }
        }
        while(countnum<=8)
        {
            str += "◇";
            countnum += 1;
        }
        return str;
    }

    void Jump()
    {
        if (Timecheck.getbeat() == 1 && Fibertime)
        {
            Timecheck.setfibertime(true);
            Metronome.setfiberstate(true);
            Commandcheck.setFiber(true);
            if (playingbgm == BGM)
            { 
                playingbgm.Stop();
                playingbgm = FiberBgm;
                playingbgm.Play();
            }
        }
        else
        {
            if (!Fibertime)
            {
                Timecheck.setfibertime(false);
                Metronome.setfiberstate(false);
                Commandcheck.setFiber(false);
                if (playingbgm == FiberBgm)
                {
                    playingbgm.Stop();
                    playingbgm = BGM;
                    playingbgm.Play();
                }
            }

        }

        if (isJumping)
        {
            if (playingbgm == BGM)
            {
                BPM = BPM1;
            }
            else
            {
                BPM = BPM2;
            }
            time_list.Add(time % (60 * 4 / BPM) - 5 * Time.deltaTime);
            isJumping = false;
        }
        else if ((Timecheck.getbeat() == 0 || (Fibertime && Timecheck.getbeat() == 0)) && time_list.Count != 0)
        {
            beat_list = Commandcheck.timetobeat(time_list);
            if (!Fibertime)
            {
                
                Commandcheck.rightcommand(beat_list);
                if (Commandcheck.Commandis() != null)
                {
                    Comboscore += 1;
                    if (Comboscore >= 3)
                    {
                        FeverText.text = ("GO FEVER");
                    }
                    ComboText.text = ("COMBO!! " + Comboscore.ToString());
                    if (Commandcheck.Commandis() == "12357")
                    {
                        S12357.Play();
                        
                    }
                    else if (Commandcheck.Commandis() == "1357")
                    {
                        S1357.Play();
                    }
                    else if (Commandcheck.Commandis() == "2468")
                    {
                        S2468.Play();
                    }
                    else if (Commandcheck.Commandis() == "2457")
                    {
                        Debug.Log("2457");
                        S2457.Play();
                    }
                    else if (Commandcheck.Commandis() == "3468")
                    {
                        S3468.Play();
                    }
                    else if (Commandcheck.Commandis() == "124578")
                    {
                        S124578.Play();
                    }
                    else if (Commandcheck.Commandis() == "134678")
                    {
                        S134678.Play();
                    }
                    else if (Commandcheck.Commandis() == "12345678")
                    {
                        S12345678.Play();
                        if (Comboscore >= 3)
                        {
                            Fibertime = true;
                            FeverText.text = "";
                            //피버타임 알림창 띄우기
                            //피버타임 첫 두 커맨드 가져오고 세트하기
                            FiberFirstCommand = new List<int>();
                            FiberSecondCommand = new List<int>();
                            while (FiberFirstCommand.Count == 0)
                            {
                                int count = 0;
                                for (int i = 5; i < 8; i++)
                                {
                                    if (Random.Range(0, 2) == 1)
                                    {
                                        count += 1;
                                        int k = i + 1;
                                        FiberFirstCommand.Add(k);
                                        string2 += (i + 1).ToString();
                                        string2 += "  ";
                                    }

                                }
                                Debug.Log(string2);
                                string2 = "";
                            }
                            while (FiberSecondCommand.Count == 0)
                            {
                                for (int i = 0; i < 8; i++)
                                {
                                    if (Random.Range(0, 2) == 1)
                                    {
                                        FiberSecondCommand.Add(i + 1);
                                        string2 += (i + 1).ToString();
                                        string2 += "  ";
                                    }

                                }
                                Debug.Log(string2);
                                string2 = "";
                            }
                            //피버타임 커맨드 알림
                            Firstfiberliststr = FiberBeatString(FiberFirstCommand);
                            Secondfiberliststr = FiberBeatString(FiberSecondCommand);

                            FiberText.text = Firstfiberliststr;
                            FiberText2.text = Secondfiberliststr;
                        }

                    }
                }

                else
                {
                    Comboscore = 0;
                    FeverText.text = "";

                    ComboText.text = "";
                    Fibertime = false;
                    Debug.Log("Wrong Command!");

                }
            }
            else
            {
                //Fiber Time command check
                if (Commandcheck.fibercommandcheck(beat_list, FiberFirstCommand))
                {
                    Comboscore += 1;
                    ComboText.text = ("COMBO!! " + Comboscore.ToString());
                    FiberFirstCommand = FiberSecondCommand;
                    FiberSecondCommand = new List<int>();
                    while (FiberSecondCommand.Count == 0)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            if (Random.Range(0, 2) == 1)
                            {
                                FiberSecondCommand.Add(i + 1);
                                string2 += (i + 1).ToString();
                                string2 += "  ";
                            }

                        }
                        Debug.Log(string2);
                        string2 = "";
                    }
                    //피버 커맨드 알림
                    Firstfiberliststr = FiberBeatString(FiberFirstCommand);
                    Secondfiberliststr = FiberBeatString(FiberSecondCommand);
                    FiberText.text = Firstfiberliststr;
                    FiberText2.text = Secondfiberliststr;
                }
                else
                {
                    Comboscore = 0;
                    ComboText.text = "";
                    Fibertime = false;
                    FiberFirstCommand = new List<int>();
                    FiberSecondCommand = new List<int>();
                    FiberText.text = "";
                    FiberText2.text = "";
                    FeverText.text = "";

                    Debug.Log("Wrong Fiober Command!");
                }
            }
            time_list = new List<float>();
            beat_list = new List<int>();
            isJumping = false;
            ischeck = true;
        }
        else if (( Timecheck.getbeat() == 0 || (Fibertime && Timecheck.getbeat() == 0)) && time_list.Count == 0 && !ischeck)
        {
            //커맨드 입력 아무것도 안했을 때
            
            Comboscore = 0;
            FeverText.text = "";

            ComboText.text = "";
            Fibertime = false;
            Commandcheck.rightcommand(nulllist);
        }
        
        else if (Timecheck.getbeat() == 1&&!Fibertime)
        {
            ischeck = false;
            Commandcheck.rightcommand(nulllist);
        }

        else if (((!Fibertime && Timecheck.getbeat() == 0) || (Fibertime && Timecheck.getbeat() == 0)))
        {
            ischeck = false;
        }

    }

}
