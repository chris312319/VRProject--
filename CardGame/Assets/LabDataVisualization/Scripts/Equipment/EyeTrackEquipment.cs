using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LabVisualization;
using LabVisualization.EyeTracing;
using System;
using LabData;
#if USE_SRANIPAL
using ViveSR.anipal.Eye;
#endif

public class EyeTrackEquipment : MonoSingleton<EyeTrackEquipment>, IEquipment, IEyeTracingPos
{
    public SRanipal_Eye_Framework Sranipal { get; set; }

    private bool IsOpenEye = false;
    
    public Vector2 EyeData { get; set; }
    
    SingleEyeData LeftData { get; set; }
    SingleEyeData RightData { get; set; }
    SingleEyeData Combined { get; set; }

    string FocusName { get; set; }

    private readonly GazeIndex[] GazePriority = new GazeIndex[] { GazeIndex.COMBINE, GazeIndex.LEFT, GazeIndex.RIGHT };

    private FocusInfo FocusInfo;

    public bool IsStopEyeData = false;

    private bool _isHasFocused = false;


    public void EquipmentInit()
    {
        Debug.Log("EquipmentInit");
        IsStopEyeData = false;
#if USE_SRANIPAL
        if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING)
        {
             
            if (Sranipal == null)
            {
                Sranipal = gameObject.AddComponent<SRanipal_Eye_Framework>();
            }
            Sranipal = SRanipal_Eye_Framework.Instance;
            Sranipal.StartFramework();
            IsOpenEye = true;
        }
#endif
    }
    
    public void EquipmentStart()
    {
        Debug.Log("EquipmentStart");
        StartCoroutine(UpdateData());
    }

    public void EquipmentStop()
    {
        IsStopEyeData = true;
        if (IsOpenEye)
        {
            Sranipal.StopFramework();
            IsOpenEye = false;
        }
    }

    public Func<Vector2> GetEyeTracingPos()
    {
        return () => EyeData;
    }

    private IEnumerator UpdateData()
    {
        //Debug.Log("第一步");
        while (true)
        {
            //Debug.Log("第二步");
#if USE_SRANIPAL
            if (IsStopEyeData)
            {
                yield break;
            }
            if (SRanipal_Eye_Framework.Status == SRanipal_Eye_Framework.FrameworkStatus.WORKING)
            {
                //Debug.Log("第三步");
                VerboseData data;
                if (SRanipal_Eye.GetVerboseData(out data) &&
                    data.left.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_GAZE_DIRECTION_VALIDITY) &&
                    data.right.GetValidity(SingleEyeDataValidity.SINGLE_EYE_DATA_GAZE_DIRECTION_VALIDITY)
                    )
                {
                    //Debug.Log("第四步");
                    EyeData = data.left.pupil_position_in_sensor_area;
                    LeftData = data.left;
                    RightData = data.right;
                    Combined = data.combined.eye_data;
                    //Debug.Log("Left:" + data.left.pupil_position_in_sensor_area + "~O~O~" + "Right:" + data.right.pupil_position_in_sensor_area);
                    Ray GazeRay = new Ray();
                    if (SRanipal_Eye.Focus(GazePriority[0], out GazeRay, out FocusInfo, float.MaxValue))
                    {
                        FocusName = FocusInfo.collider.gameObject.name;                   
                        //GameEventCenter.DispatchEvent("ShowEyeFocus", FocusName);
                        //GameEventCenter.DispatchEvent("GetEyeContact", FocusName);
                        //GameEventCenter.DispatchEvent("GetFocusName", FocusName);

                        var eyepositiondata = new EyePositonData() //記錄eyedata
                        {
                            X = FocusInfo.point.x,
                            Y = FocusInfo.point.y,
                            Z = FocusInfo.point.z,
                            FocusObject = FocusName,
                            Pupil_Diameter_Left = LeftData.pupil_diameter_mm,
                            Eye_Openness_Left = LeftData.eye_openness,
                            Pupil_Diameter_Right = RightData.pupil_diameter_mm,
                            Eye_Openness_Right = RightData.eye_openness,
                            Pupil_Diameter_Combined = Combined.pupil_diameter_mm,
                            Eye_Openness_Combined = Combined.eye_openness
                        };
                        GameDataManager.LabDataManager.SendData(eyepositiondata);
                        //Debug.Log("FocusInfo:" + FocusName + " At (" + FocusInfo.point.x + "," + FocusInfo.point.y + "," + FocusInfo.point.z + ")");
                        //Debug.Log("PupilSize :" + data.left.pupil_diameter_mm);                       
                    }
                }
            }
            var cardgamedata = new CardGameData()
            {
                State = Test_DataCenter.State[Test_DataCenter.now],
                Round = Test_DataCenter.Round[Test_DataCenter.now],
                SayWant_RT = Test_DataCenter.SayWant_RT[Test_DataCenter.now],
                SayWant_RemindTimes = Test_DataCenter.SayWant_RemindTimes[Test_DataCenter.now],
                Pick_RT = Test_DataCenter.Pick_RT[Test_DataCenter.now],
                Pick_RemindTimes = Test_DataCenter.Pick_RemindTimes[Test_DataCenter.now],
                Play_RT = Test_DataCenter.Play_RT[Test_DataCenter.now],
                Play_RemindTimes = Test_DataCenter.Play_RemindTimes[Test_DataCenter.now],
                Flip_State = Test_DataCenter.Flip_State[Test_DataCenter.now],
                Flip_RT = Test_DataCenter.Flip_RT[Test_DataCenter.now],
                Flip_RemindTimes = Test_DataCenter.Flip_RemindTimes[Test_DataCenter.now],
                SaySorry_RT = Test_DataCenter.SaySorry_RT[Test_DataCenter.now],
                SaySorry_RemindTimes = Test_DataCenter.SaySorry_RemindTimes[Test_DataCenter.now],
                SayBig_RT = Test_DataCenter.SayBig_RT[Test_DataCenter.now],
                SayBig_RemindTimes = Test_DataCenter.SayBig_RemindTimes[Test_DataCenter.now],
                Show_RT = Test_DataCenter.Show_RT[Test_DataCenter.now],
                Show_RemindTimes = Test_DataCenter.Show_RemindTimes[Test_DataCenter.now],
                ChooseEmotion_RT = Test_DataCenter.ChooseEmotion_RT[Test_DataCenter.now],
                ChooseEmotion_RemindTimes = Test_DataCenter.ChooseEmotion_RemindTimes[Test_DataCenter.now],
                ChooseEmotion_Choice = Test_DataCenter.ChooseEmotion_Choice[Test_DataCenter.now],
                ChooseAction_RT = Test_DataCenter.ChooseAction_RT[Test_DataCenter.now],
                ChooseAction_RemindTimes = Test_DataCenter.ChooseAction_RemindTimes[Test_DataCenter.now],
                ChooseAction_Choice = Test_DataCenter.ChooseAction_Choice[Test_DataCenter.now],
                Discard_RT = Test_DataCenter.Discard_RT[Test_DataCenter.now],
                Discard_RemindTimes = Test_DataCenter.Discard_RemindTimes[Test_DataCenter.now]
            };
            if (TestGameFrame.Test_EnemyTask.transferdata)
            {
                Debug.Log("Transfer");
                GameDataManager.LabDataManager.SendData(cardgamedata);
                TestGameFrame.Test_EnemyTask.transferdata = false;
            }


            var cardgameresult = new CardGameResult()
            {
                GameTime = timer.minute * 60 + timer.second,
                Coins = TestGameFrame.Test_CoinTask.coinP - 1,
                Diamonds = TestGameFrame.Test_CoinTask.diamondP - 1,
                SayWant_Acc = -1,
                SayWant_MeanRT = Test_DataCenter.SayWant_RT[0],
                Pick_Acc = -1,
                Pick_MeanRT = Test_DataCenter.Pick_RT[3],
                Play_Acc = Test_DataCenter.Play_Acc / 5,
                Play_MeanRT = Test_DataCenter.Play_MeanRT / 5,
                Flip_Acc = Test_DataCenter.Flip_Acc / 5,
                Flip_MeanRT = Test_DataCenter.Flip_MeanRT / 5,
                SaySorry_Acc = -1,
                SaySorry_MeanRT = Test_DataCenter.SaySorry_MeanRT / Test_DataCenter.SaySorry_Acc,
                SayBig_Acc = Test_DataCenter.SayBig_Acc / 2,
                SayBig_MeanRT = Test_DataCenter.SayBig_MeanRT / 2,
                Show_Acc = Test_DataCenter.Show_Acc / 2,
                Show_MeanRT = Test_DataCenter.Show_MeanRT / 2,
                ChooseEmotion_Acc = Test_DataCenter.ChooseEmotion_Acc / 7,
                ChooseEmotion_MeanRT = Test_DataCenter.ChooseEmotion_MeanRT / 7,
                ChooseAction_Acc = Test_DataCenter.ChooseAction_Acc,
                ChooseAction_MeanRT = Test_DataCenter.ChooseAction_RT[0],
                Discard_Acc = Test_DataCenter.Discard_Acc / 5,
                Discard_MeanRT = Test_DataCenter.Discard_MeanRT / 5,
            };
            if (TestGameFrame.Test_EnemyTask.transferresult)
            {
                Debug.Log("TransferResult");
                GameDataManager.LabDataManager.SendData(cardgameresult);
                TestGameFrame.Test_EnemyTask.transferresult = false;
            }



            yield return new WaitForFixedUpdate();
#endif
        }
    }    
}
