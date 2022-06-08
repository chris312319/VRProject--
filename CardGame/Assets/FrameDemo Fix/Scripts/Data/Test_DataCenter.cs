using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_DataCenter : MonoBehaviour
{
    public float timer1 = 0, timer2 = 0, timer3 = 0, timer4 = 0, timer5 = 0, timer6 = 0, timer7 = 0, timer8 = 0, timer9 = 0, timer10 = 0;

    static public int now = 0;

    static public string[] State = new string[10];

    static public int[] Round = new int[10];

    static public float[] SayWant_RT = new float[10];

    static public int[] SayWant_RemindTimes = new int[10];

    static public float SayWant_MeanRT = 0;

    static public float SayWant_Acc = 0;


    static public float[] Pick_RT = new float[10];

    static public int[] Pick_RemindTimes = new int[10];

    static public float Pick_MeanRT = 0;

    static public float Pick_Acc = 0;



    static public float[] Play_RT = new float[10];

    static public int[] Play_RemindTimes = new int[10];

    static public float Play_MeanRT = 0;

    static public float Play_Acc = 0;


    static public string[] Flip_State = new string[10];

    static public float[] Flip_RT = new float[10];

    static public int[] Flip_RemindTimes = new int[10];

    static public float Flip_MeanRT = 0;

    static public float Flip_Acc = 0;


    static public float[] SaySorry_RT = new float[10];

    static public int[] SaySorry_RemindTimes = new int[10];

    static public float SaySorry_MeanRT = 0;

    static public float SaySorry_Acc = 0;


    static public float[] SayBig_RT = new float[10];

    static public int[] SayBig_RemindTimes = new int[10];

    static public float SayBig_MeanRT = 0;

    static public float SayBig_Acc = 0;


    static public float[] Show_RT = new float[10];

    static public int[] Show_RemindTimes = new int[10];

    static public float Show_MeanRT = 0;

    static public float Show_Acc = 0;


    static public float[] ChooseEmotion_RT = new float[10];

    static public int[] ChooseEmotion_RemindTimes = new int[10];

    static public float ChooseEmotion_MeanRT = 0;

    static public float ChooseEmotion_Acc = 0;

    static public float[] ChooseEmotion_AccList = new float[10];

    static public string[] ChooseEmotion_Choice = new string[10];




    static public float[] ChooseAction_RT = new float[10];

    static public int[] ChooseAction_RemindTimes = new int[10];

    static public float ChooseAction_MeanRT = 0;

    static public float ChooseAction_Acc = -1;

    static public string[] ChooseAction_Choice = new string[10];


    static public float[] Discard_RT = new float[10];

    static public int[] Discard_RemindTimes = new int[10];

    static public float Discard_MeanRT = 0;

    static public float Discard_Acc = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            State[i] = "-1";
            Round[i] = -1;
            SayWant_RT[i] = -1;
            SayWant_RemindTimes[i] = -1;
            Pick_RT[i] = -1;
            Pick_RemindTimes[i] = -1;
            Play_RT[i] = -1;
            Play_RemindTimes[i] = -1;
            Flip_State[i] = "-1";
            Flip_RT[i] = -1;
            Flip_RemindTimes[i] = -1;
            SaySorry_RT[i] = -1;
            SaySorry_RemindTimes[i] = -1;
            SayBig_RT[i] = -1;
            SayBig_RemindTimes[i] = -1;
            Show_RT[i] = -1;
            Show_RemindTimes[i] = -1;
            ChooseEmotion_RT[i] = -1;
            ChooseEmotion_RemindTimes[i] = -1;
            ChooseEmotion_Choice[i] = "-1";
            ChooseAction_RT[i] = -1;
            ChooseAction_RemindTimes[i] = -1;
            ChooseAction_Choice[i] = "-1";
            Discard_RT[i] = -1;
            Discard_RemindTimes[i] = -1;
            ChooseEmotion_AccList[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {       
        //Round
        if (TestGameFrame.Test_EnemyTask.j == -1)
        {
            now = TestGameFrame.Test_EnemyTask.i;
        }
        else now = TestGameFrame.Test_EnemyTask.j + 3;
        //State
        if (TestGameFrame.Test_EnemyTask.j == -1)
        {
            State[TestGameFrame.Test_EnemyTask.i] = "Waiting";
            Round[TestGameFrame.Test_EnemyTask.i] = TestGameFrame.Test_EnemyTask.i + 1;
        }
        else
        {
            State[TestGameFrame.Test_EnemyTask.j + 3] = "Playing";
            Round[TestGameFrame.Test_EnemyTask.j + 3] = TestGameFrame.Test_EnemyTask.j + 1;
        }
        //SayWant
        if(TestGameFrame.Test_EnemyTask.SayWantRT == 1)
        {
            timer1 += Time.deltaTime;
            SayWant_RT[TestGameFrame.Test_EnemyTask.i] = timer1;
        }
        else
        {
            timer1 = 0;
        }
        //Pick
        if (TestGameFrame.Test_EnemyTask.PickRT == 1)
        {
            timer2 += Time.deltaTime;
            Pick_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer2;
        }
        else
        {
            timer2 = 0;
        }
        //Play
        if (TestGameFrame.Test_EnemyTask.PlayRT == 1)
        {
            timer3 += Time.deltaTime;
            Play_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer3;
        }
        else
        {
            timer3 = 0;
        }
        Play_RemindTimes = Test_GameData.outcard;
        //Flip
        /*if (TestGameFrame.Test_EnemyTask.FlipRT == 1)
        {
            timer4 += Time.deltaTime;
            Flip_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer4;
        }
        else
        {
            timer4 = 0;
        }*/
        Flip_RT = Test_GameData.timearray;
        Flip_RemindTimes = Test_GameData.turncard;
        //SaySorry
        if (TestGameFrame.Test_EnemyTask.SaySorryRT == 1)
        {
            timer5 += Time.deltaTime;
            SaySorry_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer5;
        }
        else
        {
            timer5 = 0;
        }
        //SayBig
        if (TestGameFrame.Test_EnemyTask.SayBigRT == 1)
        {
            timer6 += Time.deltaTime;
            SayBig_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer6;
        }
        else
        {
            timer6 = 0;
        }
        SayBig_RemindTimes = Test_GameData.saybig;
        //Show
        if (TestGameFrame.Test_EnemyTask.ShowRT == 1)
        {
            timer7 += Time.deltaTime;
            Show_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer7;
        }
        else
        {
            timer7 = 0;
        }
        Show_RemindTimes = Test_GameData.showcard;
        //ChooseEmotion
        if (TestGameFrame.Test_EnemyTask.ChooseEmotionRT == 1)
        {
            timer9 += Time.deltaTime;
            if(TestGameFrame.Test_EnemyTask.j == -1) ChooseEmotion_RT[TestGameFrame.Test_EnemyTask.i] = timer9;
            if (TestGameFrame.Test_EnemyTask.j != -1) ChooseEmotion_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer9;
        }
        else
        {
            if (timer9 != 0)
            {
                Debug.Log("待輸入:" + timer9);
                Debug.Log("已輸入:" + ChooseEmotion_RT[TestGameFrame.Test_EnemyTask.j + 3]);
            }
            timer9 = 0;
        }
        //ChooseAction
        if (TestGameFrame.Test_EnemyTask.ChooseActionRT == 1)
        {
            timer10 += Time.deltaTime;
            ChooseAction_RT[TestGameFrame.Test_EnemyTask.i] = timer10;
            ChooseAction_RT[0] = timer10;
        }
        else
        {
            timer10 = 0;
        }
        //Discard
        if (TestGameFrame.Test_EnemyTask.DiscardRT == 1)
        {
            timer8 += Time.deltaTime;
            Discard_RT[TestGameFrame.Test_EnemyTask.j + 3] = timer8;
        }
        else
        {
            timer8 = 0;
        }
        Discard_RemindTimes = Test_GameData.abacard;
    }
}
