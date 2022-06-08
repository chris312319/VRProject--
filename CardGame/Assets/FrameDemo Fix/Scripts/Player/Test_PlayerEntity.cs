using RootMotion.FinalIK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestGameFrame
{
    public class Test_PlayerEntity : GameEntityBase
    {
        public Action<GameEntityBase> Action;

        public VRIKInput vRIKInput;

        public GameObject vrCamera;
        public Test_MainScneRes MainScneRes { get; set; }

        public GameObject gun;
        static public int preparetostart = 0;
        static public int voice = 0;
        static public int play = 0;
        static public int wash = 0;
        static public int bewashed = 0;
        static public int cardinhand = 0;
        static public int preparetoout = 0;
        static public int preparetojud = 0;
        static public int preparetoaba = 0;
        static public int preparetoget = 1;
        static public int nocard = 1;

        static public int currentcard = 0;
        static public int cardonleft = 0;
        static public int cardonright = 0;
        static public int cardontable = 0;
        static public int cardjud = 0;

        static public int lefttable = 0;
        static public int leftright = 0;
        static public int righttable = 0;
        static public int rightcard = 0;
        static public int leftcard = 0;

        static public int start = 0;
        static public int canout = 0;
        static public int canjud = 0;
        static public int canaba = 0;

        public float timer = 0;

        static public GameObject RightHandp;
        public GameObject LeftHandp;
        public GameObject table;
        public GameObject tablep;
        public GameObject Cardp;
        public GameObject CardpL;
        static public GameObject Cardptable;
        public GameObject[] CardAb;
        GameObject Camera;

        float time = 0;


        public void Init(GameObject vrCamera)
        {
            vRIKInput = new VRIKInput();
            StartCoroutine(vRIKInput.VRIKStart(vrCamera, gameObject));
            Camera = GameObject.Find("MainSceneUI/Panel");
            Camera.GetComponent<Canvas>().worldCamera = GameObject.Find("Camera").GetComponent<Camera>();
        }
        public override void EntityDispose()
        {

        }
        public void Start()
        {
            Init(vrCamera);
            MainScneRes = GameEntityManager.Instance.GetCurrentSceneRes<Test_MainScneRes>();
            tablep = GameObject.Find("tablep");
            table = GameObject.Find("tablemid");
            RightHandp = GameObject.Find("playerhand");
            LeftHandp = GameObject.Find("playerhandL");
        }
        private void Update()
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            if (preparetostart == 1 && keyword.voice == 1)
            {
                play = 1;
            }
            else if (preparetostart == 1 && Input.GetKeyDown(KeyCode.Space))
            {
                play = 1;
            }
            if (wash == 1 && (Input.GetKeyDown(KeyCode.A) || (righttable == 1 && rightcard == 1)))
            {
                bewashed = 1;
                wash = 0;
            }
            if (start == 1 && nocard == 1 /*&& (Input.GetKeyDown(KeyCode.Q) || (lefttable == 1 && leftcard  == 1) || (righttable == 1 && rightcard == 1))*/)
            {
                nocard = 0;
                cardinhand = 1;
                start = 0;
            }
            if (cardinhand == 1 && preparetoget == 1)
            {
                preparetoget = 0;
                preparetoout = 1;
            }
            if (canout == 1 && preparetoout == 1 && (Input.GetKeyDown(KeyCode.E) || righttable == 1))
            {
                preparetoout = 0;
                preparetojud = 1;
                righttable = 0;
                canout = 0;
            }
            if (canjud == 1 && preparetojud == 1 && /* (righttable == 1 && rightcard == 1)*/Test_CardTurnTask.cardturn == 1 )
            {             
                    Test_CardTurnTask.cardturn = 0;
                    preparetojud = 0;
                    preparetoaba = 1;
                    righttable = 0;
                    rightcard = 0;
                    canjud = 0;
                    time = 0;             
            }            
            if (Test_EnemyTask.waitforaba == 1 && canaba == 1 && preparetoaba == 1 && (Input.GetKeyDown(KeyCode.T) || ( righttable == 1 && rightcard == 1 )))
            {               
                preparetoaba = 0;
                preparetoget = 1;
                righttable = 0;
                rightcard = 0;
                canaba = 0;
            }



            if(start == 0 && nocard == 0 && cardinhand == 1 && play == 1 && cardonleft == 0)
            {

            }
            if(preparetoout == 1  && cardonright == 0)
            {
                Destroy(CardpL);
                if (currentcard != 7 && currentcard != 12)
                {
                    CardpL = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.PlayerCard[currentcard + 1] - 1) * 2].gameObject, LeftHandp.transform.position, Quaternion.Euler(0, 180, 0), LeftHandp.transform);
                    CardpL.transform.localScale = new Vector3(7, 7, 7);
                }
                Cardp = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.PlayerCard[currentcard] - 1) * 2].gameObject, RightHandp.transform.position, Quaternion.Euler(0, 180, 0), RightHandp.transform);
                Cardp.transform.localScale = new Vector3(7, 7, 7);
                cardonright = 1;
            }
            if(preparetojud == 1 && cardonright == 1 && cardontable == 0)
            {
                Destroy(Cardp);
                Cardptable = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.PlayerCard[currentcard] - 1) * 2].gameObject, tablep.transform.position, Quaternion.Euler(90, 0, 0), tablep.transform);
                cardonright = 0;
                cardontable = 1;
            }
            if(preparetoaba == 1 && cardontable == 1 && cardjud == 0)
            {
                Cardptable.transform.Rotate(180, 0, 180);
                cardjud = 1;
            }
            if(preparetoget == 1 && cardjud == 1 && cardontable == 1)
            {
                Cardptable.transform.position = table.transform.position;
                cardontable = 0;
                cardjud = 0;
                currentcard += 1;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                if (rightcard != 1)
                {
                   rightcard = 1;
                    Debug.Log("rightcard");
                }
                else if (rightcard == 1)
                {
                    rightcard = 0;
                    Debug.Log("rightcardx");
                }
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (righttable != 1)
                {
                    righttable = 1;
                    Debug.Log("righttable");
                }
                else if (righttable == 1)
                {
                    righttable = 0;
                    Debug.Log("righttablex");
                }
            }
        }
        IEnumerator pause()
        {
            yield return new WaitForSeconds(3);
        }
    }
}
