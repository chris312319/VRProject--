using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using LabData;
using System.Globalization;

// 掛在場景中的GameObject(我取名叫BreathSensor)身上
public class SensorController : MonoBehaviour 
{
    private SerialPort stream = null; 
    private string val = null;
    private string sArray = "";
    private string sArr = "";
    private Thread myThread;
    private float currentPressure;
    private float breathVal = 0.0f;
    private float breathTotal = 0.0f;
    private int numOfVal = 0;

    // Use this for initialization
    public void ConnectionInit (string ComNum) {
        //if (LabTools.GetConfig<ApplicationConfig>().BlueTooth)
        //{
            Debug.Log("連接初始化");
            stream = new SerialPort("COM" + ComNum, 9600);//呼吸 9600 舌壓 12800 
            stream.Open(); //開啟serial port接口，才能收資料
            myThread = new Thread(new ThreadStart(GetArduino)); //物件宣告及呼叫GetArduino
            myThread.Start(); //這邊用thread
        //}
    }
    
    void Update(){
        //float.TryParse (val, out m);
        if(val != null){
            sArray = val; //舌壓
            //Debug.Log(sArray);
            if (sArray != "Pressure:")
            {
                sArr = sArray;
                Debug.LogError("呼吸綁帶數值: " + sArr);

                if(TestGameFrame.Test_EnemyTask._isCalBreathStart)
                {
                    // 取得呼吸綁帶數值 給breathVal, 儲存在breathArr裡
                    breathVal = float.Parse(sArr, CultureInfo.InvariantCulture.NumberFormat);
                    breathTotal += breathVal;
                    numOfVal++;
                }
            }
        }
    }

    public string getBreathStr()
    {
        return sArr;
    }

    public double getThreshold()
    {
        double baseline = 0.0f;
        double threshold = 0.0f;

        // 算這些值的平均
        baseline = breathTotal / numOfVal;
        threshold = baseline + (baseline * 0.02);
        return threshold;
    }

    private void GetArduino()
    {
        //Debug.Log(stream.IsOpen);
        while(myThread.IsAlive && stream.IsOpen)
        {
            //Debug.Log("進入完成");
            val = stream.ReadLine();
            //Debug.Log(val);
        }
    }
    //關閉thread&serial port，否則會死當
    void OnDisable()
    {
        if (stream != null)
        {
            stream.Close();
            myThread.Abort();
        }
    }
    void OnApplicationQuit()
    {
        if (stream != null)
        {
            stream.Close();
            myThread.Abort();
        }
    }
}