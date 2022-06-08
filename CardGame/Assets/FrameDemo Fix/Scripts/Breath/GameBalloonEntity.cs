using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 掛在氣球上，AnimatorController初始State為Null，另外剪一個氣球飛走動畫(291-400)
public class GameBalloonEntity : GameEntityBase
{
    // 控制氣球縮小或放大的狀態
    public static bool balloonStatus = false;

    // 控制氣球變大或變小的定值，後續要用算的得到
    private float scale = 0.0f;
    private float FramePerSec = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        GameEventCenter.AddEvent("getBalloonScale", getBalloonScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EntityDispose()
    {

    }

    public void CtrlBalloonScale()
    {
        // 控制balloon的scale
        scale = 0.7f / (GameDataManager.FlowData.BreathSec/FramePerSec);
        Debug.Log("scale:" + scale);

        // 0.5 - 1.2
        // 根據balloonStatus控制氣球Scale放大縮小
        if (balloonStatus)
        {
            // 氣球放大
            Debug.Log("氣球放大");
            this.gameObject.transform.localScale += new Vector3(scale, scale, scale);
        }
        else
        {
            if (this.gameObject.transform.localScale != new Vector3(0.5f, 0.5f, 0.5f))
            {
                // 氣球縮小
                Debug.Log("氣球縮小");
                this.gameObject.transform.localScale += new Vector3(-scale, -scale, -scale);
            }
        }
    }

    public void getBalloonScale()
    {
        // 先拿到氣球當下的scale
        float setTime = (this.gameObject.transform.localScale.x - 0.5f) / 0.7f * GameDataManager.FlowData.BreathSec;
        Debug.Log("setTime:" + setTime);
        GameEventCenter.DispatchEvent("setBreathTimer", setTime);
    }
}
