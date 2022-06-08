using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LabData;
using GameData;
using UnityEngine.UI;

namespace TestGameFrame
{
    public class Test_MenuUI : MonoBehaviour
    {
        public Button StartButton;
        public string username;
        public string userID;
        public string BreathSec;
        public GameObject inputfield;
        public GameObject inputID;
        public GameObject inputSec;

        //public InputField InputEnemy;
        //public static int InputEnemyNumber;
        public void Start()
        {
            StartButton.onClick.AddListener(StartButtonClick);
            inputfield = GameObject.Find("InputField");
            inputID = GameObject.Find("InputID");
            inputSec = GameObject.Find("InputSec");
            inputfield.GetComponent<InputField>().onValueChanged.AddListener(ChangeValue);
            inputfield.GetComponent<InputField>().onEndEdit.AddListener(EndValue);
            inputID.GetComponent<InputField>().onValueChanged.AddListener(ChangeID);
            inputID.GetComponent<InputField>().onEndEdit.AddListener(EndID);
            inputSec.GetComponent<InputField>().onValueChanged.AddListener(ChangeSec);
            inputSec.GetComponent<InputField>().onEndEdit.AddListener(EndSec);
        }
        public void Update()
        {

        }
        public void StartButtonClick()
        {
            
  
             GameFlowData gameFlow = new GameFlowData();

             GameDataManager.FlowData = gameFlow;

            gameFlow.UserName = username;

            gameFlow.UserId = userID;

            gameFlow.BreathSec = float.Parse(BreathSec);

            GameDataManager.LabDataManager.LabDataCollectInit(() => gameFlow.UserId.ToString());
            timer.timestart = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            GameSceneManager.Instance.Change2MainScene();
        }

        private void ChangeValue(string value)
        {
            username = value;
        }
        private void EndValue(string value)
        {
            username = value;
        }
        private void ChangeID(string value)
        {
            userID = value;
        }
        private void EndID(string value)
        {
            userID = value;
        }
        private void ChangeSec(string value)
        {
            BreathSec = value;
        }
        private void EndSec(string value)
        {
            BreathSec = value;
        }


    }
}
