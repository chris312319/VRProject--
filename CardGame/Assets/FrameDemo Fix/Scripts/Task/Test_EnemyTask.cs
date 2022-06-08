using RootMotion.FinalIK;
using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using LabData;
using TestGameFrame;
using System.Globalization;

namespace TestGameFrame
{

    public class Test_EnemyTask : TaskBase
    {
        private int CurrentWave = 0, CurrentRound = 0;

        static public int Round = 0, trueans = 0, waitforout = 0, waitforspeak = 0, waitforjudge = 0, waitforaba = 0, qstart = 0, earlycardturn = 0, startcardturn = 0, startcardturn2 = 0, latecardturn = 0,acccardturn = 0,apologize = 0,showtouch = 0,test = 0,coinordia = 0,count3 = 0;

        static public int i = 0,j = -1;

        static public int SayWantRT = 0;

        static public int PickRT = 0;

        static public int PlayRT = 0;

        static public int FlipRT = 0;

        static public int SaySorryRT = 0;

        static public int SayBigRT = 0;

        static public int ShowRT = 0;

        static public int ChooseEmotionRT = 0;

        static public int ChooseActionRT = 0;

        static public int DiscardRT = 0;

        static public bool transferdata = false;

        static public bool transferresult = false;

        static public bool calresult = false;


        static public bool _isCalBreathStart = false;

        static public bool _is5secTimeUp = false;

        static public bool _isRebreathButtonClick = false;

        static public bool _isBreathFinish = false;

        public Test_MainScneRes MainScneRes { get; set; }

        public GameObject OC;

        public GameObject Player;
        public GameObject Enemy01G { get; set; }
        public GameObject Enemy01 { get; set; }
        public GameObject Enemy02 { get; set; }

        public GameObject Enemy02Arrange;
        public GameObject Enemy03 { get; set; }
        public GameObject Enemy { get; set; }

        public GameObject Teacher;

        public GameObject Question;

        public GameObject Answer1;

        public GameObject Answer2;

        public GameObject Answer3;

        public GameObject GreenRec;

        public GameObject RedRec;

        static public GameObject Green;

        public GameObject Red;

        public Test_WaveConfig WaveConfig { get; set; }

        public Animator PlayerA;

        public Animator Enemy01GA;

        public Animator Enemy01A ;
        
        public Animator Enemy02A ;

        public Animator Enemy02AA;

        public Animator Enemy03A ;

        public Animator TeacherA;

        public GameObject Card;

        public GameObject[] PlayerC = new GameObject[5];

        public GameObject[] Enemy01C = new GameObject[5];

        public GameObject[] Enemy02C = new GameObject[5];

        public GameObject[] Enemy03C = new GameObject[5];

        public GameObject GoldP;

        public GameObject Gold1;
        
        public GameObject Gold2;
        
        public GameObject Gold3;

        public GameObject VideoPlayer;

        public GameObject balloon;

        public GameObject Handcard;

        public GameObject Handcard01;

        public GameObject Handcard02;

        public GameObject Handcard03;

        public GameObject DiaP;

        public GameObject Dia1;

        public GameObject Dia2;

        public GameObject Dia3;

        public GameObject sensorObject;

        public Button RebreathButton;






        public override IEnumerator TaskInit()
        {
            MainScneRes = GameEntityManager.Instance.GetCurrentSceneRes<Test_MainScneRes>();
            WaveConfig = LabTools.GetConfig<Test_WaveConfig>();
            LabVisualization.VisualizationManager.Instance.VisulizationInit();
            LabVisualization.VisualizationManager.Instance.StartDataVisualization();
            yield return null;
        }

        public override IEnumerator TaskStart()
        {
            Test_EnemyEntity.gamestart = 1;

            sensorObject = GameObject.Find("BreathSensor");
            sensorObject.GetComponent<SensorController>().ConnectionInit("9");
            Enemy = GameObject.Find("Enemy");
            Player = GameObject.Find("Player2n");
            OC = GameObject.Find("OC");
            Teacher = GameObject.Find("teacher");
            Green = GameObject.Find("Green");
            Red = GameObject.Find("Red");
            GoldP = GameObject.Find("GoldP");
            Gold1 = GameObject.Find("Gold1");
            Gold2 = GameObject.Find("Gold2");
            Gold3 = GameObject.Find("Gold3");
            DiaP = GameObject.Find("DiaP");
            Dia1 = GameObject.Find("Dia1");
            Dia2 = GameObject.Find("Dia2");
            Dia3 = GameObject.Find("Dia3");
            VideoPlayer = GameObject.Find("VideoPlayer");
            balloon = GameObject.Find("balloon");
            OC.SetActive(false);
            Green.SetActive(false);
            Red.SetActive(false);
            GoldP.SetActive(false);
            Gold1.SetActive(false);
            Gold2.SetActive(false);
            Gold3.SetActive(false);
            DiaP.SetActive(false);
            Dia1.SetActive(false);
            Dia2.SetActive(false);
            Dia3.SetActive(false);
            VideoPlayer.SetActive(false);
            balloon.SetActive(false);
            Enemy03 = GameObject.Instantiate(MainScneRes.Enemy03.gameObject, new Vector3((float)2.469, (float)0.036, (float)2.995), Quaternion.Euler(0,-90,0),Enemy.transform);
            Enemy01G = GameObject.Instantiate(MainScneRes.Enemy01give.gameObject, new Vector3((float)1.889, (float)0.033, (float)3.591), Quaternion.Euler(0,180,0),Enemy.transform);
            Enemy01 = GameObject.Instantiate(MainScneRes.Enemy01.gameObject, new Vector3((float)1.889, (float)0.036, (float)3.591), Quaternion.Euler(0, 180, 0), Enemy.transform);
            Enemy02 = GameObject.Instantiate(MainScneRes.Enemy02.gameObject, new Vector3((float)1.258, (float)0.036, (float)2.97), Quaternion.Euler(0,90,0), Enemy.transform);
            Enemy02Arrange = GameObject.Instantiate(MainScneRes.Enemy02arrange.gameObject, new Vector3((float)1.258, (float)0.036, (float)2.97), Quaternion.Euler(0, 90, 0), Enemy.transform);
            Enemy01GA = GameObject.Find("enemy01gg(Clone)").GetComponent<Animator>();
            Enemy01A = GameObject.Find("enemy01nn(Clone)").GetComponent<Animator>();
            Enemy02A = GameObject.Find("enemy02(Clone)").GetComponent<Animator>();
            Enemy02AA = GameObject.Find("enemy02nn(Clone)").GetComponent<Animator>();
            Enemy03A = GameObject.Find("enemy03nn(Clone)").GetComponent<Animator>();
            TeacherA = GameObject.Find("teacher").GetComponent<Animator>();
            Card = GameObject.Find("card001");
            Answer1 = GameObject.Find("Answer1");
            Answer2 = GameObject.Find("Answer2");
            Answer3 = GameObject.Find("Answer3");
            GreenRec = GameObject.Find("GreenRec");
            RedRec = GameObject.Find("RedRec");
            Enemy01GA.Play("a09");
            Enemy01A.Play("a09");
            Enemy02A.Play("d09");
            Enemy03A.Play("c09");
            Answer1.SetActive(false);
            Answer2.SetActive(false);
            Answer3.SetActive(false);

            PlayerC = GameObject.FindGameObjectsWithTag("Playercard");
            for (int start = 0; start < 5; start++)
            {
                PlayerC[start].SetActive(false);
            }
            Enemy01C = GameObject.FindGameObjectsWithTag("Enemy01card");
            for(int start = 0; start < 5; start++)
            {
                Enemy01C[start].SetActive(false);
            }
            Enemy03C = GameObject.FindGameObjectsWithTag("Enemy03card");
            for (int start = 0; start < 5; start++)
            {
                Enemy03C[start].SetActive(false);
            }
            Enemy02C = GameObject.FindGameObjectsWithTag("Enemy02card");
            for (int start = 0; start < 5; start++)
            {
                Enemy02C[start].SetActive(false);
            }
            Enemy01.SetActive(false);
            Enemy02Arrange.SetActive(false);
            OC.SetActive(true);        
            AudioClip clip = Resources.Load<AudioClip>("Audios/Host開始");
            GameAudioController.Instance.PlayOneShot(clip);
            TeacherA.Play("teacher2");
            Test_EnemyEntity.cardtoplay = 1;
            yield return new WaitForSeconds(clip.length+1);
            clip = Resources.Load<AudioClip>("Audios/Host一起玩");
            GameAudioController.Instance.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length + 1);
            Test_PlayerEntity.preparetostart = 1;
            TeacherA.Play("teacher1");
            SayWantRT = 1;
            yield return new WaitUntil(() => Test_PlayerEntity.play == 1); 
            SayWantRT = 0;
            clip = Resources.Load<AudioClip>("Audios/NPC_等待");
            Enemy02A.Play("dhappy");
            GameAudioController.Instance.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length + 1);
            Enemy02A.Play("dstop");
            clip = Resources.Load<AudioClip>("Audios/Host開始情緒");
            GameAudioController.Instance.PlayOneShot(clip);
            TeacherA.Play("teacher2");
            yield return new WaitForSeconds(clip.length + 1);
            clip = Resources.Load<AudioClip>("Audios/Host深呼吸");
            GameAudioController.Instance.PlayOneShot(clip);
            yield return new WaitForSeconds(clip.length + 1);
            TeacherA.Play("teacher1");

            VideoPlayer.SetActive(true);
            balloon.SetActive(true);           
            GameEventCenter.DispatchEvent("Timer5secReset");
            GameEventCenter.DispatchEvent("rebreathButton_isEnabled", true);
            do {
                _isRebreathButtonClick = false;

                balloon.SetActive(true);

                // 等待5秒反應
                GameEventCenter.DispatchEvent("Text5sec_isEnabled", true);

                // 用數值控制氣球scale縮放，停在這邊做完才出來
                yield return BreathCtrlBalloon(balloon);

                // 達到目標後要播放氣球飛走動畫
                if (_isBreathFinish) // 成功
                {
                    // 氣球內dummy的scale
                    balloon.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

                    //播放氣球飛走動畫
                    balloon.GetComponent<Animator>().Play("fly");
                    yield return new WaitForSeconds(3.2f);
                }
            balloon.SetActive(false);

                if (_isRebreathButtonClick) // 失敗
                {
                    // 主持人: 有時候深呼吸一次還沒辦法把這股生氣的氣吐完，讓我們再練習一次!
                    TeacherA.Play("teacher2");
                    clip = Resources.Load<AudioClip>("Audios/Host再練習一次");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                }
                GameEventCenter.DispatchEvent("BreathTimerReset");
                GameEventCenter.DispatchEvent("BreathText_isEnabled", false);
            } while (_isRebreathButtonClick);
            GameEventCenter.DispatchEvent("rebreathButton_isEnabled", false);
            VideoPlayer.SetActive(false);
            

            clip = Resources.Load<AudioClip>("Audios/Host說明");
            GameAudioController.Instance.PlayOneShot(clip);
            TeacherA.Play("teacher2");
            yield return new WaitForSeconds(clip.length + 1);
            TeacherA.Play("teacher1");

            for (i = 0; i < 3; i++) //等待流程，共三輪
            {
                Debug.Log("準備");
                Enemy01GA.Play("a09");
                Enemy02A.Play("d09");
                Enemy03A.Play("c09");
                yield return new WaitForSeconds(1);
                if (i == 2) Test_EnemyEntity.gamestart = 0;
                Test_EnemyEntity.cardtoplay = 1;
                Test_EnemyEntity.cardnum -= 1;
                yield return new WaitForSeconds(3);
                clip = Resources.Load<AudioClip>("Audios/Host開始出牌");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Debug.Log("出牌");
                Enemy01GA.Play("a10");
                Enemy02A.Play("d10");
                Enemy03A.Play("c10");
                yield return new WaitForSeconds(2);
                Test_EnemyEntity.cardtoplay = 0;
                Test_EnemyEntity.cardontable = 1;
                yield return new WaitForSeconds(4);
                if (i == 0) clip = Resources.Load<AudioClip>("Audios/Host出完牌了");
                if (i == 1) clip = Resources.Load<AudioClip>("Audios/Host出完牌了2");
                if (i == 2) clip = Resources.Load<AudioClip>("Audios/Host出完牌了3");
                TeacherA.Play("teacher2");
                GameAudioController.Instance.PlayOneShot(clip);
                yield return new WaitForSeconds(clip.length + 1);
                if (i == 0)
                    {
                        clip = Resources.Load<AudioClip>("Audios/Host注意開始數");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                    }
                TeacherA.Play("teacher1");
                clip = Resources.Load<AudioClip>("Audios/NPC_紅1");
                GameAudioController.Instance.PlayOneShot(clip);
                clip = Resources.Load<AudioClip>("Audios/NPC_綠1");
                GameAudioController.Instance.PlayOneShot(clip);
                clip = Resources.Load<AudioClip>("Audios/NPC_花1");
                GameAudioController.Instance.PlayOneShot(clip);
                GameObject.Find("Command").GetComponent<Text>().text = "1";
                yield return new WaitForSeconds(1);
                clip = Resources.Load<AudioClip>("Audios/NPC_紅2");
                GameAudioController.Instance.PlayOneShot(clip);
                clip = Resources.Load<AudioClip>("Audios/NPC_綠2");
                GameAudioController.Instance.PlayOneShot(clip);
                clip = Resources.Load<AudioClip>("Audios/NPC_花2");
                GameAudioController.Instance.PlayOneShot(clip);
                GameObject.Find("Command").GetComponent<Text>().text = "2";
                if (i == 0)
                {
                    Enemy02A.Play("d11");
                    Test_EnemyEntity.Card02table.transform.Rotate(180, 0, 180);
                }
                yield return new WaitForSeconds(1);
                clip = Resources.Load<AudioClip>("Audios/NPC_紅3");
                GameAudioController.Instance.PlayOneShot(clip);
                clip = Resources.Load<AudioClip>("Audios/NPC_綠3");
                GameAudioController.Instance.PlayOneShot(clip);
                clip = Resources.Load<AudioClip>("Audios/NPC_花3");
                GameAudioController.Instance.PlayOneShot(clip);
                GameObject.Find("Command").GetComponent<Text>().text = "3";
                count3 = 1;
                Debug.Log("開牌");
                Enemy01GA.Play("a11");
                if(i != 0) Enemy02A.Play("d11");
                if(i != 1) Enemy03A.Play("c11");
                if(i == 1) Enemy03A.Play("cmis");
                yield return new WaitForSeconds(1);
                if (i == 0) //第一輪
                {
                    Test_EnemyEntity.cardturn = 1;
                    Test_EnemyEntity.Card02table.transform.Rotate(180, 0, 180);
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/Host小花早翻");
                    TeacherA.Play("teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.c1 = 1;
                    CoinorDia.c3 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/NPC_小花早翻");
                    Enemy01GA.Play("a02");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy01GA.Play("astop");
                    clip = Resources.Load<AudioClip>("Audios/Host才剛開始");
                    TeacherA.Play("teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    clip = Resources.Load<AudioClip>("Audios/NPC_小花對不起");
                    Enemy02A.Play("d02");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy02A.Play("dstop");
                    clip = Resources.Load<AudioClip>("Audios/Host小花寶石2");
                    TeacherA.Play("teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.d2 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/NPC_小綠沒關係");
                    Enemy01GA.Play("a02");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy01GA.Play("astop");
                    clip = Resources.Load<AudioClip>("Audios/Host說我最大");
                    TeacherA.Play("teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    clip = Resources.Load<AudioClip>("Audios/NPC_開心");
                    Enemy03A.Play("cshow");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Test_EnemyEntity.Card03table.SetActive(false);
                    Handcard03 = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy03Card[Test_EnemyEntity.currentcard] - 1) * 2].gameObject, Test_EnemyEntity.LeftHand03.transform.position, Quaternion.Euler(0, 90, 90), Test_EnemyEntity.LeftHand03.transform);
                    yield return new WaitForSeconds(3);
                    Test_EnemyEntity.Card03table.SetActive(true);
                    Destroy(Handcard03);
                    yield return new WaitForSeconds(clip.length -1);
                    Enemy03A.Play("cstop");
                    clip = Resources.Load<AudioClip>("Audios/Host小紅寶石");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    CoinorDia.d3 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/Host說小紅大");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.c3 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/NPC_難過2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Enemy01GA.Play("a15");
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy01GA.Play("astop");
                    clip = Resources.Load<AudioClip>("Audios/Host提問");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length);
                    Round = 0;
                    clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                    Answer2.SetActive(true);
                    clip = Resources.Load<AudioClip>("Audios/Host還是生氣呢");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                    TeacherA.Play("teacher1");
                    Answer1.SetActive(true);
                    qstart = 1;
                    ChooseEmotionRT = 1;
                    yield return new WaitUntil(() => trueans == 1);
                    qstart = 0;
                    Answer1.SetActive(false);
                    Answer2.SetActive(false);
                    trueans = 0;
                    Round = 1;
                    clip = Resources.Load<AudioClip>("Audios/Host小綠很氣");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    clip = Resources.Load<AudioClip>("Audios/Host把牌亂丟");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                    Answer1.SetActive(true);
                    clip = Resources.Load<AudioClip>("Audios/Host還是深呼吸呢");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                    TeacherA.Play("teacher1");
                    Answer2.SetActive(true);
                    qstart = 1;
                    ChooseActionRT = 1;
                    yield return new WaitUntil(() => trueans == 1);
                    qstart = 0;
                    Answer1.SetActive(false);
                    Answer2.SetActive(false);
                    trueans = 0;
                }
                if (i == 1) //第二輪
                {
                    Test_EnemyEntity.cardturn = 1;
                    Test_EnemyEntity.Card03table.transform.Rotate(180, 0, 180);
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/NPC_小紅沒翻");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Enemy02A.Play("d02");
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy02A.Play("dstop");
                    clip = Resources.Load<AudioClip>("Audios/NPC_小紅看窗戶");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Enemy03A.Play("c02");
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy03A.Play("cstop");
                    clip = Resources.Load<AudioClip>("Audios/Host小紅分心");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.c1 = 1;
                    CoinorDia.c2 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/NPC_小紅對不起");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Enemy03A.Play("cshy");
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy03A.Play("cstop");
                    clip = Resources.Load<AudioClip>("Audios/Host小紅寶石2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.d3 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/NPC_沒關係");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Enemy01GA.Play("a02");
                    yield return new WaitForSeconds(clip.length + 1);
                    Enemy01GA.Play("astop");
                    clip = Resources.Load<AudioClip>("Audios/Host小紅補翻");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    Enemy03A.Play("c11");
                    yield return new WaitForSeconds(2);
                    Test_EnemyEntity.Card03table.transform.Rotate(180, 0, 180);
                    clip = Resources.Load<AudioClip>("Audios/Host大家都翻");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    clip = Resources.Load<AudioClip>("Audios/NPC_開心");
                    Enemy01GA.Play("ashow");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Test_EnemyEntity.Card01table.SetActive(false);
                    Handcard01 = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy01Card[Test_EnemyEntity.currentcard] - 1) * 2].gameObject, Test_EnemyEntity.LeftHand01.transform.position, Quaternion.Euler(0, 0, 90), Test_EnemyEntity.LeftHand01.transform);
                    yield return new WaitForSeconds(3);
                    Test_EnemyEntity.Card01table.SetActive(true);
                    Destroy(Handcard01);
                    yield return new WaitForSeconds(clip.length - 1);
                    Enemy01GA.Play("astop");
                    clip = Resources.Load<AudioClip>("Audios/Host小綠寶石");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    CoinorDia.d1 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/Host說小綠大");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.c1 = 1;
                    yield return new WaitForSeconds(3);
                }
                if (i == 2) //第三輪
                {
                    Test_EnemyEntity.cardturn = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/Host挖三人一起");
                    TeacherA.Play("teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.c1 = 1;
                    CoinorDia.c2 = 1;
                    CoinorDia.c3 = 1;
                    yield return new WaitForSeconds(3);
                    clip = Resources.Load<AudioClip>("Audios/Host說我最大");
                    TeacherA.Play("teacher2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    clip = Resources.Load<AudioClip>("Audios/NPC_開心3");
                    Enemy02A.Play("dshow");
                    GameAudioController.Instance.PlayOneShot(clip);
                    Test_EnemyEntity.Card02table.SetActive(false);
                    Handcard02 = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy02Card[Test_EnemyEntity.currentcard] - 1) * 2].gameObject, Test_EnemyEntity.LeftHand02.transform.position, Quaternion.Euler(0, -90, -270), Test_EnemyEntity.LeftHand02.transform);
                    yield return new WaitForSeconds(3);
                    Test_EnemyEntity.Card02table.SetActive(true);
                    Destroy(Handcard02);
                    yield return new WaitForSeconds(clip.length - 1);
                    Enemy02A.Play("dstop");
                    clip = Resources.Load<AudioClip>("Audios/Host小花寶石");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    CoinorDia.d2 = 1;
                    yield return new WaitForSeconds(2);
                    clip = Resources.Load<AudioClip>("Audios/Host提問");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    Round = 2;
                    clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                    Answer2.SetActive(true);
                    clip = Resources.Load<AudioClip>("Audios/Host還是生氣呢");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length);
                    TeacherA.Play("teacher1");
                    Answer1.SetActive(true);
                    qstart = 1;
                    ChooseEmotionRT = 1;
                    yield return new WaitUntil(() => trueans == 1);
                    qstart = 0;
                    Answer1.SetActive(false);
                    Answer2.SetActive(false);
                    trueans = 0;
                    clip = Resources.Load<AudioClip>("Audios/Host說小花大");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    CoinorDia.c2 = 1;
                    yield return new WaitForSeconds(3);
                }
                clip = Resources.Load<AudioClip>("Audios/Host比完數字");
                GameAudioController.Instance.PlayOneShot(clip);
                /*if(i == 0)*/ TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");    
                Debug.Log("棄牌");
                Enemy01GA.Play("a12");
                Enemy02A.Play("d12");
                Enemy03A.Play("c12");
                Test_EnemyEntity.cardontable = 0;
                Test_EnemyEntity.cardontablen = 0;
                yield return new WaitForSeconds(1);
                Test_EnemyEntity.cardab = 1;
                yield return new WaitForSeconds(1);
                Test_EnemyEntity.currentcard += 1;
                Test_PlayerEntity.currentcard += 1;
                clip = Resources.Load<AudioClip>("Audios/Host回合結束");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                yield return new WaitForSeconds(3);
                transferdata = true;
                yield return new WaitForSeconds(1);
            }
            OC.SetActive(false);
            Card.SetActive(true);
            clip = Resources.Load<AudioClip>("Audios/NPC_好了");
            GameAudioController.Instance.PlayOneShot(clip);
            Enemy02A.Play("dhappy");
            Enemy03A.Play("cstop");
            Enemy01GA.Play("astop");
            yield return new WaitForSeconds(clip.length + 1);
            Enemy02A.Play("dstop");
            clip = Resources.Load<AudioClip>("Audios/Host很棒");
            GameAudioController.Instance.PlayOneShot(clip);
            TeacherA.Play("teacher2");
            yield return new WaitForSeconds(clip.length + 1);
            TeacherA.Play("teacher1");
            Test_CoinTask.coin01 = Test_CoinTask.coin02 = Test_CoinTask.coin03 =  Test_CoinTask.diamond01 = Test_CoinTask.diamond02 = Test_CoinTask.diamond03 = 1;
            Test_EnemyEntity.nocard = 1;
            yield return new WaitForSeconds(3);
            clip = Resources.Load<AudioClip>("Audios/Host小綠洗牌");
            GameAudioController.Instance.PlayOneShot(clip);
            TeacherA.Play("teacher2");
            yield return new WaitForSeconds(clip.length + 1);
            TeacherA.Play("teacher1");
            for (int k = 0; k < 1; k++) //遊玩流程，共五輪
            {
                j = 0;
                Test_EnemyEntity.nocard = 1;
                Card.SetActive(true);
                yield return new WaitForSeconds(3);
                Debug.Log("發牌");
                Enemy01.SetActive(false);
                Enemy01G.SetActive(true);
                Enemy01GA.Play("a07g");
                yield return new WaitForSeconds(40);
                clip = Resources.Load<AudioClip>("Audios/Host發完牌");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                clip = Resources.Load<AudioClip>("Audios/Host碰牌");
                GameAudioController.Instance.PlayOneShot(clip);
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                Test_PlayerEntity.wash = 1;
                PickRT = 1; //拿牌反應時間開始計時
                yield return new WaitUntil(() => Test_PlayerEntity.bewashed == 1);
                PickRT = 0;
                Test_PlayerEntity.nocard = 1;
                Test_PlayerEntity.start = 1;
                Card.SetActive(false);
                for (int start = 0; start < 5; start++)
                {
                    Enemy01C[start].SetActive(true);
                }
                for (int start = 0; start < 5; start++)
                {
                    Enemy02C[start].SetActive(true);
                }
                for (int start = 0; start < 5; start++)
                {
                    Enemy03C[start].SetActive(true);
                }
                Enemy01.SetActive(true);
                Enemy01G.SetActive(false);
                Enemy02.SetActive(false);
                Enemy02Arrange.SetActive(true);
                Test_EnemyEntity.RightHand01 = GameObject.Find("enemy01hand");
                Test_EnemyEntity.LeftHand02 = GameObject.Find("enemy02handL");
                Test_EnemyEntity.Card01 = GameObject.Instantiate(MainScneRes.Card[0].gameObject, Test_EnemyEntity.RightHand01.transform.position, Quaternion.Euler(-90, -90, 0), Test_EnemyEntity.RightHand01.transform);
                Test_PlayerEntity.bewashed = 0;
                Enemy01A.Play("a07");
                Enemy02AA.Play("d07");
                Enemy03A.Play("c07");
                //Debug.Log("整理牌");
                clip = Resources.Load<AudioClip>("Audios/Host太棒了");
                GameAudioController.Instance.PlayOneShot(clip);
                TeacherA.Play("teacher2");
                yield return new WaitForSeconds(clip.length + 1);
                TeacherA.Play("teacher1");
                yield return new WaitForSeconds(3);               
                Enemy02.SetActive(true);
                Enemy02Arrange.SetActive(false);
                Enemy01A.Play("a08");
                Enemy02A.Play("d08");
                Enemy03A.Play("c08");
                for (int start = 0; start < 5; start++)
                {
                    Enemy01C[start].SetActive(false);
                }
                for (int start = 0; start < 5; start++)
                {
                    Enemy02C[start].SetActive(false);
                }
                for (int start = 0; start < 5; start++)
                {
                    Enemy03C[start].SetActive(false);
                }
                //Debug.Log("左手拿牌");
                Test_EnemyEntity.gamestart = 1;
                Test_EnemyEntity.cardnum =5;
                yield return new WaitForSeconds(1);
                for (j = 0; j < 5; j++)
                {
                    Enemy01A.Play("a09");
                    Enemy02A.Play("d09");
                    Enemy03A.Play("c09");
                    yield return new WaitForSeconds(1);
                    Test_EnemyEntity.cardtoplay = 1;
                    Test_EnemyEntity.cardnum -= 1;
                    if(j == 4) Test_EnemyEntity.gamestart = 0;
                    //Debug.Log("等待右手拿牌");
                    yield return new WaitUntil(() => Test_PlayerEntity.preparetoout == 1);
                    //Debug.Log("右手持牌");                   
                    clip = Resources.Load<AudioClip>("Audios/Host出牌");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    clip = Resources.Load<AudioClip>("Audios/Host碰桌子");                  
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    Test_PlayerEntity.canout = 1;
                    Enemy01A.Play("a10");
                    Enemy02A.Play("d10");
                    Enemy03A.Play("c10");
                    yield return new WaitForSeconds(1);
                    Test_EnemyEntity.cardtoplay = 0;
                    Test_EnemyEntity.cardontable = 1;
                    waitforout = 1; //出牌提醒開始計時
                    PlayRT = 1; //出牌反應時間開始計時
                    yield return new WaitUntil(() => Test_PlayerEntity.preparetojud == 1);
                    PlayRT = 0;
                    waitforout = 0;
                    clip = Resources.Load<AudioClip>("Audios/Host真厲害");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    //Debug.Log("出牌");
                    yield return new WaitForSeconds(clip.length + 1);
                    if (j == 0) clip = Resources.Load<AudioClip>("Audios/Host準備翻牌");
                    if (j == 1) clip = Resources.Load<AudioClip>("Audios/Host準備翻牌2");
                    if (j >= 2) clip = Resources.Load<AudioClip>("Audios/Host準備翻牌3");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    Green.SetActive(true);
                    if (j < 2)
                        {
                            clip = Resources.Load<AudioClip>("Audios/Host翻牌");
                            GameAudioController.Instance.PlayOneShot(clip);
                            yield return new WaitForSeconds(clip.length + 1);
                        }
                    clip = Resources.Load<AudioClip>("Audios/Host注意開始數");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    startcardturn = 1; //早翻牌判定開始計時
                    Test_PlayerEntity.canjud = 1;
                    FlipRT = 1; //翻牌反應時間開始計時
                    yield return new WaitForSeconds(1);
                    clip = Resources.Load<AudioClip>("Audios/NPC_紅1");
                    GameAudioController.Instance.PlayOneShot(clip);
                    clip = Resources.Load<AudioClip>("Audios/NPC_綠1");
                    GameAudioController.Instance.PlayOneShot(clip);
                    clip = Resources.Load<AudioClip>("Audios/NPC_花1");
                    GameAudioController.Instance.PlayOneShot(clip);
                    GameObject.Find("Command").GetComponent<Text>().text = "1";
                    yield return new WaitForSeconds(1);
                    clip = Resources.Load<AudioClip>("Audios/NPC_紅2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    clip = Resources.Load<AudioClip>("Audios/NPC_綠2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    clip = Resources.Load<AudioClip>("Audios/NPC_花2");
                    GameAudioController.Instance.PlayOneShot(clip);
                    GameObject.Find("Command").GetComponent<Text>().text = "2";
                    yield return new WaitForSeconds(1);
                    clip = Resources.Load<AudioClip>("Audios/NPC_紅3");
                    GameAudioController.Instance.PlayOneShot(clip);
                    clip = Resources.Load<AudioClip>("Audios/NPC_綠3");
                    GameAudioController.Instance.PlayOneShot(clip);
                    clip = Resources.Load<AudioClip>("Audios/NPC_花3");
                    GameAudioController.Instance.PlayOneShot(clip);
                    GameObject.Find("Command").GetComponent<Text>().text = "3";
                    count3 = 1;
                    startcardturn = 0;       //早翻牌判定結束    
                    if (earlycardturn == 0)
                    {
                        waitforjudge = 1; //翻牌提醒開始計時
                        startcardturn2 = 1; //晚翻牌判定開始計時
                    }
                    Enemy01A.Play("a11");
                    Enemy02A.Play("d11");
                    Enemy03A.Play("c11");
                    Test_EnemyEntity.cardturn = 1;
                    if (earlycardturn != 0) FlipRT = 0;
                    if (earlycardturn == 0)
                    {
                        yield return new WaitUntil(() => startcardturn2 == 0);
                        FlipRT = 0;
                    }


                    //早翻or晚翻
                    if (earlycardturn == 0 && latecardturn == 0)
                    {
                        if (acccardturn == 1)
                        {
                            Test_DataCenter.Flip_State[j + 3] = "Immediately";
                            acccardturn = 0;
                            clip = Resources.Load<AudioClip>("Audios/Host挖你好厲害");
                            GameAudioController.Instance.PlayOneShot(clip);
                            TeacherA.Play("teacher2");
                            yield return new WaitForSeconds(clip.length + 1);
                            TeacherA.Play("teacher1");
                            CoinorDia.cP = 1;
                            yield return new WaitForSeconds(3);
                            CoinorDia.c1 = 1;
                            CoinorDia.c2 = 1;
                            CoinorDia.c3 = 1;
                            yield return new WaitForSeconds(3);
                        }
                        else
                        {
                            clip = Resources.Load<AudioClip>("Audios/Host學會翻牌");
                            GameAudioController.Instance.PlayOneShot(clip);
                            TeacherA.Play("teacher2");
                            yield return new WaitForSeconds(clip.length + 1);
                            TeacherA.Play("teacher1");
                        }
                    }
                    if (earlycardturn == 1)
                    {
                        Test_DataCenter.Flip_State[j + 3] = "Early";
                        earlycardturn = 0;
                        clip = Resources.Load<AudioClip>("Audios/NPC_花你太早");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                        clip = Resources.Load<AudioClip>("Audios/Host你太早翻牌囉");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        CoinorDia.c1 = 1;
                        CoinorDia.c2 = 1;
                        CoinorDia.c3 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/Host你說對不起");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        SaySorryRT = 1; //道歉反應時間開始計時
                        yield return new WaitUntil(() => apologize == 1);
                        SaySorryRT = 0;
                        apologize = 0;
                        clip = Resources.Load<AudioClip>("Audios/Host你寶石");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.dP = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/NPC_花數123");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                    }                  
                    if (latecardturn == 1)
                    {
                        Test_DataCenter.Flip_State[j + 3] = "Late";
                        latecardturn = 0;
                        clip = Resources.Load<AudioClip>("Audios/Host太晚翻牌囉");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);                        
                        TeacherA.Play("teacher1");
                        CoinorDia.c1 = 1;
                        CoinorDia.c2 = 1;
                        CoinorDia.c3 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/NPC_花你太晚");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                        clip = Resources.Load<AudioClip>("Audios/Host你說對不起");
                        TeacherA.Play("teacher2");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        SaySorryRT = 1;
                        yield return new WaitUntil(() => apologize == 1);
                        SaySorryRT = 0;
                        apologize = 0;
                        clip = Resources.Load<AudioClip>("Audios/Host你寶石");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.dP = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/NPC_花沒關係");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                    }
                    Test_CardTurnTask.time = 0;
                    Test_CardTurnTask.time2 = 0;

                    yield return new WaitForSeconds(1.5f);
                    //judge
                    clip = Resources.Load<AudioClip>("Audios/Host說我最大");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);

                    //誰最大
                    if (j == 0)
                        {
                        TeacherA.Play("teacher1");
                        clip = Resources.Load<AudioClip>("Audios/NPC_開心");
                        Enemy03A.Play("cshow");
                        GameAudioController.Instance.PlayOneShot(clip);
                        Test_EnemyEntity.Card03table.SetActive(false);
                        Handcard03 = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy03Card[Test_EnemyEntity.currentcard] - 1) * 2].gameObject, Test_EnemyEntity.LeftHand03.transform.position, Quaternion.Euler(0, 90, 90), Test_EnemyEntity.LeftHand03.transform);
                        yield return new WaitForSeconds(3);
                        Test_EnemyEntity.Card03table.SetActive(true);
                        Destroy(Handcard03);
                        yield return new WaitForSeconds(clip.length - 1);
                        Enemy03A.Play("cstop");
                        clip = Resources.Load<AudioClip>("Audios/Host小紅寶石");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        CoinorDia.d3 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/Host說小紅大");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.c3 = 1;
                        yield return new WaitForSeconds(3);
                    }
                    if (j == 1)
                        {
                        clip = Resources.Load<AudioClip>("Audios/Host你最大");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");

                        waitforspeak = 1; //展示以及翻牌提醒開始計時
                        ShowRT = 1; //展示牌反應時間開始計時
                        SayBigRT = 1; //說我最大反應時間開始計時
                        yield return new WaitUntil(() => (Test_PlayerEntity.rightcard==1 && Test_PlayerEntity.righttable == 1) );
                        ShowRT = 0;
                        showtouch = 1; 
                        Test_PlayerEntity.Cardptable.SetActive(false);
                        //牌上手
                        Handcard = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.PlayerCard[Test_PlayerEntity.currentcard] - 1) * 2].gameObject, Test_PlayerEntity.RightHandp.transform.position, Quaternion.Euler(0, 0, 0), Test_PlayerEntity.RightHandp.transform);
                        Handcard.transform.localScale = new Vector3(7, 7, 7);
                        yield return new WaitUntil(() => (Test_PlayerEntity.righttable == 0 && waitforspeak == 2 ));
                        SayBigRT = 0;
                        //手上牌消失
                        Handcard.SetActive(false);
                        showtouch = 0;
                        waitforspeak = 0;
                        Test_PlayerEntity.Cardptable.SetActive(true);

                        clip = Resources.Load<AudioClip>("Audios/Host你學會了好棒");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.dP = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/Host恭喜你贏了");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.cP = 1;
                        yield return new WaitForSeconds(3);

                    }
                    if (j == 2)
                        {
                        TeacherA.Play("teacher1");
                        clip = Resources.Load<AudioClip>("Audios/NPC_開心3");
                        Enemy02A.Play("dshow");
                        GameAudioController.Instance.PlayOneShot(clip);
                        Test_EnemyEntity.Card02table.SetActive(false);
                        Handcard02 = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy02Card[Test_EnemyEntity.currentcard] - 1) * 2].gameObject, Test_EnemyEntity.LeftHand02.transform.position, Quaternion.Euler(0, -90, -270), Test_EnemyEntity.LeftHand02.transform);
                        yield return new WaitForSeconds(3);
                        Test_EnemyEntity.Card02table.SetActive(true);
                        Destroy(Handcard02);
                        yield return new WaitForSeconds(clip.length - 1);
                        Enemy02A.Play("dstop");
                        clip = Resources.Load<AudioClip>("Audios/Host小花寶石");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        CoinorDia.d2 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/Host說小花大");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.c2 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/NPC_小花運氣變好");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                    }
                    if (j == 3)
                        {
                        TeacherA.Play("teacher1");
                        clip = Resources.Load<AudioClip>("Audios/NPC_開心2");
                        Enemy01A.Play("ashow");
                        GameAudioController.Instance.PlayOneShot(clip);
                        Test_EnemyEntity.Card01table.SetActive(false);
                        Handcard01 = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy01Card[Test_EnemyEntity.currentcard] - 1) * 2].gameObject, Test_EnemyEntity.LeftHand01.transform.position, Quaternion.Euler(0, 0, 90), Test_EnemyEntity.LeftHand01.transform);
                        yield return new WaitForSeconds(3);
                        Test_EnemyEntity.Card01table.SetActive(true);
                        Destroy(Handcard01);
                        yield return new WaitForSeconds(clip.length - 1);
                        Enemy01A.Play("astop");
                        clip = Resources.Load<AudioClip>("Audios/Host小綠寶石");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        CoinorDia.d1 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/Host說小綠大");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.c1 = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/NPC_小綠運氣變好");
                        Enemy01A.Play("a02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy01A.Play("astop");
                    }
                    if (j == 4)
                        {
                        clip = Resources.Load<AudioClip>("Audios/Host你最大");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");

                        waitforspeak = 1;
                        ShowRT = 1; //同第二輪
                        SayBigRT = 1; //同第二輪
                        yield return new WaitUntil(() => (Test_PlayerEntity.rightcard == 1 && Test_PlayerEntity.righttable == 1));
                        ShowRT = 0;
                        showtouch = 1;
                        Test_PlayerEntity.Cardptable.SetActive(false);
                        //牌上手
                        Handcard = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.PlayerCard[Test_PlayerEntity.currentcard] - 1) * 2].gameObject, Test_PlayerEntity.RightHandp.transform.position, Quaternion.Euler(0, 0, 0), Test_PlayerEntity.RightHandp.transform);
                        Handcard.transform.localScale = new Vector3(7, 7, 7);
                        yield return new WaitUntil(() => (Test_PlayerEntity.righttable == 0 && waitforspeak == 2));
                        SayBigRT = 0;
                        //手上牌消失
                        Handcard.SetActive(false);
                        showtouch = 0;
                        waitforspeak = 0;
                        Test_PlayerEntity.Cardptable.SetActive(true);

                        clip = Resources.Load<AudioClip>("Audios/Host你學會了好棒");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.dP = 1;
                        yield return new WaitForSeconds(3);
                        clip = Resources.Load<AudioClip>("Audios/Host恭喜你贏了");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        TeacherA.Play("teacher1");
                        CoinorDia.cP = 1;
                        yield return new WaitForSeconds(3);

                    }


                    //情緒問題
                    if (j == 0)
                        {
                        clip = Resources.Load<AudioClip>("Audios/NPC_小花想贏");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                        clip = Resources.Load<AudioClip>("Audios/Host提問");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        Round = 3;
                        clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer1.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host是生氣呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer2.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host有點小失望");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        TeacherA.Play("teacher1");
                        Answer3.SetActive(true);
                        qstart = 1;
                        ChooseEmotionRT = 1; //情緒問題反應時間開始計時
                        yield return new WaitUntil(() => trueans == 1);
                        qstart = 0;
                        Answer1.SetActive(false);
                        Answer2.SetActive(false);
                        Answer3.SetActive(false);
                        trueans = 0;
                    }
                    if (j == 1)
                        {
                        clip = Resources.Load<AudioClip>("Audios/NPC_小花運氣不好");
                        Enemy02A.Play("d02");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy02A.Play("dstop");
                        clip = Resources.Load<AudioClip>("Audios/Host提問");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        Round = 4;
                        clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer1.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host是生氣呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer2.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host有點小失望");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        TeacherA.Play("teacher1");
                        Answer3.SetActive(true);
                        qstart = 1;
                        ChooseEmotionRT = 1; //情緒問題反應時間開始計時
                        yield return new WaitUntil(() => trueans == 1);
                        qstart = 0;
                        Answer1.SetActive(false);
                        Answer2.SetActive(false);
                        Answer3.SetActive(false); 
                        trueans = 0;
                        clip = Resources.Load<AudioClip>("Audios/Host運氣好不好");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);                       
                    }
                    if (j == 2)
                        {
                        clip = Resources.Load<AudioClip>("Audios/NPC_小綠最小");
                        Enemy01A.Play("aangry");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length + 1);
                        Enemy01A.Play("astop");
                        clip = Resources.Load<AudioClip>("Audios/Host提問");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        Round = 5;
                        clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer1.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host是生氣呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer2.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host有點小失望");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        TeacherA.Play("teacher1");
                        Answer3.SetActive(true);
                        qstart = 1;
                        ChooseEmotionRT = 1; //情緒問題反應時間開始計時
                        yield return new WaitUntil(() => trueans == 1);
                        qstart = 0;
                        Answer1.SetActive(false);
                        Answer2.SetActive(false);
                        Answer3.SetActive(false);
                        trueans = 0;
                    }
                    if (j == 3)
                        {
                        clip = Resources.Load<AudioClip>("Audios/Host你的心情");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        Round = 6;
                        clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer1.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host是生氣呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer2.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host有點小失望");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        TeacherA.Play("teacher1");
                        Answer3.SetActive(true);
                        qstart = 1;
                        ChooseEmotionRT = 1; //情緒問題反應時間開始計時
                        yield return new WaitUntil(() => trueans == 1);
                        qstart = 0;
                        Answer1.SetActive(false);
                        Answer2.SetActive(false);
                        Answer3.SetActive(false);
                        trueans = 0;
                    }
                    if (j == 4)
                        {
                        clip = Resources.Load<AudioClip>("Audios/Host你的心情2");
                        GameAudioController.Instance.PlayOneShot(clip);
                        TeacherA.Play("teacher2");
                        yield return new WaitForSeconds(clip.length + 1);
                        Round = 7;
                        clip = Resources.Load<AudioClip>("Audios/Host是開心呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer1.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host是生氣呢");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        Answer2.SetActive(true);
                        clip = Resources.Load<AudioClip>("Audios/Host有點小失望");
                        GameAudioController.Instance.PlayOneShot(clip);
                        yield return new WaitForSeconds(clip.length);
                        TeacherA.Play("teacher1");
                        Answer3.SetActive(true);
                        qstart = 1;
                        ChooseEmotionRT = 1; //情緒問題反應時間開始計時
                        yield return new WaitUntil(() => trueans == 1);
                        qstart = 0;
                        Answer1.SetActive(false);
                        Answer2.SetActive(false);
                        Answer3.SetActive(false);
                        trueans = 0;
                    }
                    clip = Resources.Load<AudioClip>("Audios/Host比完數字");
                    GameAudioController.Instance.PlayOneShot(clip);
                    if(j!=1) TeacherA.Play("teacher2");
                    yield return new WaitForSeconds(clip.length + 1);
                    Red.SetActive(true);
                    clip = Resources.Load<AudioClip>("Audios/Host手碰桌子");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    Test_PlayerEntity.canaba = 1;
                    yield return new WaitForSeconds(1);
                    Enemy01A.Play("a12");
                    Enemy02A.Play("d12");
                    Enemy03A.Play("c12");
                    yield return new WaitForSeconds(0.5f);
                    Test_EnemyEntity.cardontable = 0;
                    Test_EnemyEntity.cardontablen = 0;
                    Test_EnemyEntity.cardab = 1;
                    waitforaba = 1; //棄牌提醒開始計時
                    DiscardRT = 1; //棄牌反應時間開始計時
                    yield return new WaitUntil(() => Test_PlayerEntity.preparetoget == 1);
                    DiscardRT = 0;
                    waitforaba = 0;
                    Red.SetActive(false);
                    //Debug.Log("棄牌");
                    clip = Resources.Load<AudioClip>("Audios/Host你好棒");
                    GameAudioController.Instance.PlayOneShot(clip);
                    TeacherA.Play("teacher2");                    
                    yield return new WaitForSeconds(clip.length + 1);
                    Test_EnemyEntity.currentcard += 1;

                    if (j == 0) clip = Resources.Load<AudioClip>("Audios/Host一起第一回合");
                    if (j == 1) clip = Resources.Load<AudioClip>("Audios/Host一起第二回合");
                    if (j == 2) clip = Resources.Load<AudioClip>("Audios/Host一起第三回合");
                    if (j == 3) clip = Resources.Load<AudioClip>("Audios/Host一起第四回合");
                    if (j == 4) clip = Resources.Load<AudioClip>("Audios/Host一起第五回合");
                    GameAudioController.Instance.PlayOneShot(clip);
                    yield return new WaitForSeconds(clip.length + 1);
                    TeacherA.Play("teacher1");
                    yield return new WaitForSeconds(3);
                    Debug.Log("完成"+(j+1)+"輪");
                    transferdata = true;
                    yield return new WaitForSeconds(1);
                }
                //Debug.Log("沒牌了");
                Test_PlayerEntity.start = 0;
                Test_EnemyEntity.gamestart = 0;
                Test_PlayerEntity.cardinhand = 0;
                Test_PlayerEntity.cardonleft = 0;
            }   
        }

        public override IEnumerator TaskStop()
        {
            transferdata = true;
            if (true)
            {
                for (int k = 3; k < 8; k++)
                {

                    Test_DataCenter.Play_MeanRT += Test_DataCenter.Play_RT[k];
                    if (Test_DataCenter.Play_RT[k] < 3) Test_DataCenter.Play_Acc += 1;

                    Test_DataCenter.Flip_MeanRT += Test_DataCenter.Flip_RT[k];
                    if (Test_DataCenter.Flip_RT[k] < 5) Test_DataCenter.Flip_Acc += 1;

                    if (k == 4 || k == 7)
                    {
                        Test_DataCenter.SayBig_MeanRT += Test_DataCenter.SayBig_RT[k];
                        if (Test_DataCenter.SayBig_RT[k] < 3) Test_DataCenter.SayBig_Acc += 1;

                        Test_DataCenter.Show_MeanRT += Test_DataCenter.Show_RT[k];
                        if (Test_DataCenter.Show_RT[k] < 3) Test_DataCenter.Show_Acc += 1;
                    }

                    if (Test_DataCenter.SaySorry_RT[k] != -1)
                    {
                        Test_DataCenter.SaySorry_MeanRT += Test_DataCenter.SaySorry_RT[k];
                        Test_DataCenter.SaySorry_Acc += 1;
                    }

                    Test_DataCenter.Discard_MeanRT += Test_DataCenter.Discard_RT[k];
                    if (Test_DataCenter.Discard_RT[k] < 3) Test_DataCenter.Discard_Acc += 1;
                }
                for (int k = 0; k < 8; k++)
                {
                    if (k != 1)
                    {
                        Test_DataCenter.ChooseEmotion_MeanRT += Test_DataCenter.ChooseEmotion_RT[k];
                        Test_DataCenter.ChooseEmotion_Acc += Test_DataCenter.ChooseEmotion_AccList[k];
                    }
                }
                if (Test_DataCenter.SaySorry_Acc == 0) Test_DataCenter.SaySorry_Acc = 1;
                Debug.Log("Calculate Finish");
                calresult = true;
            }
            yield return new WaitUntil(() => calresult == true);
            transferresult = true;
            yield return new WaitForSeconds(1);
            transferresult = true;
            yield return new WaitForSeconds(5);
            GameSceneManager.Instance.Change2MainUI();
            yield return null;
        }

 
        public void Zero()
        {


        }
        IEnumerator BreathCtrlBalloon(GameObject balloon)
        {
            string breathStr;
            float breathVal;
            double threshold = 0.0f;

            float a = Time.time;

            // 當深呼吸秒數未達
            while (!_isBreathFinish && !_isRebreathButtonClick)
            {
                // 更新呼吸綁帶數值 給breathStr
                breathStr = sensorObject.GetComponent<SensorController>().getBreathStr();
                breathVal = float.Parse(breathStr, CultureInfo.InvariantCulture.NumberFormat);
                Debug.Log("breathVal:" + breathVal);

                // 印出門檻值
                threshold = sensorObject.GetComponent<SensorController>().getThreshold();
                Debug.Log("threshold:" + threshold);

                //超過門檻值且達到呼吸秒數，用 balloonStatus = T / F，在 balloon 的 Entity 控制 Scale 放大或縮小
                if (breathVal > threshold)
                {
                    if (!GameBalloonEntity.balloonStatus)
                    {
                        // 把5秒計時器中止
                        GameEventCenter.DispatchEvent("Text5sec_isEnabled", false);
                        GameEventCenter.DispatchEvent("Timer5secReset");

                        // 開breathTimer
                        GameEventCenter.DispatchEvent("BreathText_isEnabled", true);

                        // 根據氣球大小設定開始的秒數
                        GameEventCenter.DispatchEvent("getBalloonScale");
                        GameBalloonEntity.balloonStatus = true;
                    }
                }
                else
                {
                    // 關breathTimer(不足指定秒數)
                    if (GameBalloonEntity.balloonStatus)
                    {
                        // 進過if 再進else
                        // 除非出立後直接放棄超過5秒，否則不能立馬重新計時
                        GameEventCenter.DispatchEvent("BreathText_isEnabled", false);
                        GameEventCenter.DispatchEvent("Text5sec_isEnabled", true);
                    }
                    GameBalloonEntity.balloonStatus = false;
                }
                balloon.GetComponent<GameBalloonEntity>().CtrlBalloonScale();

                yield return new WaitForFixedUpdate();
            }

            //關 breathTimer(滿足指定秒數)
            GameEventCenter.DispatchEvent("BreathText_isEnabled", false);
            GameEventCenter.DispatchEvent("BreathTimerReset");

            //關 5秒計時
            GameEventCenter.DispatchEvent("Text5sec_isEnabled", false);
            GameEventCenter.DispatchEvent("Timer5secReset");
        }
    }
}
