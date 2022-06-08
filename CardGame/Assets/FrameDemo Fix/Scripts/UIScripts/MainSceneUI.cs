using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainSceneUI : MonoBehaviour
{
    public Text Text5sec;  // Timer5sec()
    public Text BreathText; // BreathTimer()
    public GameObject rebreathButton;
    public Button rebreathBtn;

    #region Timer5sec
    private float timer_f = 0f;
    private int timer_i = 0, minute = 0, second = 0, maxWaitingTime = 5;
    private bool _isOnce = false;


    # endregion

    #region BreathTimer
    private float timer_f4 = 0f;
    private int timer_i4 = 0;
    #endregion

    private void Awake()
    {
        GameEventCenter.AddEvent<bool>("Text5sec_isEnabled", Text5sec_isEnabled);
        GameEventCenter.AddEvent<bool>("BreathText_isEnabled", BreathText_isEnabled); 
        GameEventCenter.AddEvent("Timer5secReset", Timer5secReset);
        GameEventCenter.AddEvent("BreathTimerReset", BreathTimerReset);
        GameEventCenter.AddEvent<float>("setBreathTimer", setBreathTimer);
        GameEventCenter.AddEvent<bool>("rebreathButton_isEnabled", rebreathButton_isEnabled);
        Text5sec.enabled = false;
        BreathText.enabled = false;
    }

    void Update()
    {
        if (Text5sec.enabled)
        {
            Timer5sec();
        }
        if (BreathText.enabled)
        {
            BreathTimer();
        }
    }

    void Text5sec_isEnabled(bool judge)
    {
        Text5sec.enabled = judge;
    }

    void BreathText_isEnabled(bool judge)
    {
        BreathText.enabled = judge;
    }

    void Timer5secReset()
    {
        Debug.Log("5秒reset");
        TestGameFrame.Test_EnemyTask._is5secTimeUp = false;
        timer_f = 0;
    }

    void BreathTimerReset()
    {
        timer_f4 = 0;
    }

    public void Timer5sec()
    {
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        turn_time();

        if (minute == 0 && second >= maxWaitingTime) // 超過5秒，顯示時間到
        {
            Text5sec.text = "5秒時間到";
            Debug.Log("5秒時間到");
            TestGameFrame.Test_EnemyTask._is5secTimeUp = true;

            // 5秒到了都沒有深呼吸 rebreath改成true
            TestGameFrame.Test_EnemyTask._isRebreathButtonClick = true;
        }
        else if (!TestGameFrame.Test_EnemyTask._is5secTimeUp) // 未達5秒，顯示時間
        {
            if (second < 10)
            {
                Text5sec.text = "5秒計時:" + "" + minute + ":0" + second;
                Debug.Log("5秒計時: " + "" + minute + ":0" + second);
            }
            else
            {
                Text5sec.text = "5秒計時:" + "" + minute + ":" + second;
                Debug.Log("5秒計時:" + "" + minute + ":" + second);
            }
        }
        void turn_time()
        {
            // 顯示時間
            minute = timer_i / 60;
            second = timer_i % 60;

            //歸零
                // 如果秒數大於30 ex. 0:31 或是 ex. 1:30 就直接歸零
                // second = 31sec 因為大於30秒就會被歸零變成0秒，下一次就是1秒，所以不會有32秒
                if (second > maxWaitingTime || minute > 0)
                {
                    minute = 0;
                    second = 0;
                    timer_i = 0;
                    timer_f = 0;
                }

        }
    }

    public void BreathTimer()
    {
        timer_f4 += Time.deltaTime;

        if ((int)timer_f4 == GameDataManager.FlowData.BreathSec) // 4秒達成，顯示成功訊息
        {
            BreathText.text = "深呼吸finish!";
            TestGameFrame.Test_EnemyTask._isBreathFinish = true;
        }
        else // 未達4秒，顯示目前計時的秒數
        {
            timer_i4 = (int)timer_f4;
            BreathText.text = timer_i4.ToString();
            Debug.Log("timer_i4:" + timer_i4);
        }
    }

    public void setBreathTimer(float startTime)
    {
        timer_f4 = startTime;
    }

    public void rebreathButton_isEnabled(bool judge)
    {
        rebreathButton.SetActive(judge);
    }


}