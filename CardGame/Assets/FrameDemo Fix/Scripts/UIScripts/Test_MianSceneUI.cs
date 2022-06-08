using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestGameFrame
{
    public class Test_MianSceneUI : MonoBehaviour
    {
        public int Gold_P = 0, Gold_01 = 0,Gold_02 = 0, Gold_03 = 0;

        public Text GlodAmount;

        public Text Times;

        public Text Timem;

        public GameObject UI;

        public Button ReturnBtn;

        private Test_ResultData resultData;

        private void Awake()
        {
            GameEventCenter.AddEvent("P_Win", P_Win);
            GameEventCenter.AddEvent("E01_Win", E01_Win);
            GameEventCenter.AddEvent("E02_Win", E02_Win);
            GameEventCenter.AddEvent("E03_Win", E03_Win);
            GameEventCenter.AddEvent("Result", Result);
        }
        public void Result()
        {
            //結算 最多者+5 若相等?
           Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GlodAmount.text = Gold_P.ToString();
            UI.SetActive(true);
            ReturnBtn.onClick.AddListener(ButtonAddListener);
            GameDataManager.LabDataManager.SendData(resultData);
        }
        public void P_Win()
        {
            Gold_P += 1;
        }
        public void E01_Win()
        {
            Gold_01 += 1;
        }
        public void E02_Win()
        {
            Gold_02 += 1;
        }
        public void E03_Win()
        {
            Gold_03 += 1;
        }
        public void ButtonAddListener()
        {
            Debug.Log("按了return");
            GameApplication.Instance.GameApplicationDispose();
            GameSceneManager.Instance.Change2MainUI();
           
        }
    }
}
