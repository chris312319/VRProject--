using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_CardTurnTask : MonoBehaviour
{
    static public float time = 0,time2 = 0;
    static public int cardturn = 0,count = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(TestGameFrame.Test_EnemyTask.startcardturn == 1)
        {
            time += Time.deltaTime;
            if(TestGameFrame.Test_PlayerEntity.rightcard == 1 && TestGameFrame.Test_PlayerEntity.righttable == 1)
            {
                TestGameFrame.Test_EnemyTask.FlipRT = 0;
                cardturn = 1;
                Debug.Log(time + "秒");
                Test_GameData.timearray[TestGameFrame.Test_EnemyTask.j + 3] = time;
                time = 0;
                TestGameFrame.Test_EnemyTask.Green.SetActive(false);
                TestGameFrame.Test_EnemyTask.earlycardturn = 1;
                TestGameFrame.Test_EnemyTask.startcardturn = 0;
            }
        }
        if (TestGameFrame.Test_EnemyTask.startcardturn2 == 1)
        {
            time2 += Time.deltaTime;
            if (TestGameFrame.Test_PlayerEntity.rightcard == 1 && TestGameFrame.Test_PlayerEntity.righttable == 1)
            {
                TestGameFrame.Test_EnemyTask.FlipRT = 0;
                cardturn = 1;
                Debug.Log((3+time2) + "秒");
                Test_GameData.timearray[TestGameFrame.Test_EnemyTask.j + 3] = time2 + 3;
                if ( time2 > 2) TestGameFrame.Test_EnemyTask.latecardturn = 1;
                if (time2 <= 2) TestGameFrame.Test_EnemyTask.acccardturn = 1;
                time2 = 0;
                TestGameFrame.Test_EnemyTask.waitforjudge = 0;
                TestGameFrame.Test_EnemyTask.Green.SetActive(false);
                TestGameFrame.Test_EnemyTask.startcardturn2 = 0;
            }
        }
    }
}
