using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGameFrame
{
    public class Test_EnemyEntity : GameEntityBase
    {
        public Test_MainScneRes MainScneRes { get; set; }
        
        static public int gamestart = 0;
        static public int cardnum = 3;
        static public int cardtoplay = 0;
        static public int currentcard = 0;
        static public int cardontable = 0;
        static public int cardontablen = 0;
        static public int cardturn = 0;
        static public int cardab = 0;
        static public int nocard = 0;

        public bool reload = false;

        public GameObject Player { get; set; }
        static public GameObject RightHand01;
        static public GameObject RightHand02;
        static public GameObject RightHand03;
        static public GameObject LeftHand01;
        static public GameObject LeftHand02;
        static public GameObject LeftHand03;
        public GameObject table;
        public GameObject table01;
        public GameObject table02;
        public GameObject table03;
        static public GameObject Card01 = null;
        static public GameObject Card02 = null;
        static public GameObject Card03 = null;
        public GameObject Card01L = null;
        public GameObject Card02L = null;
        public GameObject Card03L = null;
        static public GameObject Card01table ;
        static public GameObject Card02table ;
        static public GameObject Card03table ;
        public GameObject[] CardAb ;
        public GameObject OC;

        public void Start()
        {
            MainScneRes = GameEntityManager.Instance.GetCurrentSceneRes<Test_MainScneRes>();
            OC = GameObject.Find("OC");
            table = GameObject.Find("tablemid");
            table01 = GameObject.Find("table01");
            table02 = GameObject.Find("table02");
            table03 = GameObject.Find("table03"); 
            RightHand01 = GameObject.Find("enemy01hand");
            RightHand02 = GameObject.Find("enemy02hand");
            RightHand03 = GameObject.Find("enemy03hand");
            LeftHand01 = GameObject.Find("enemy01handL");
            LeftHand02 = GameObject.Find("enemy02handL");
            LeftHand03 = GameObject.Find("enemy03handL");
            if (Card01 == null) Card01 = GameObject.Instantiate(MainScneRes.Card[0].gameObject, RightHand01.transform.position, Quaternion.Euler(-90, -90, 0), RightHand01.transform);
            if (Card02 == null) Card02 = GameObject.Instantiate(MainScneRes.Card[0].gameObject, RightHand02.transform.position, Quaternion.Euler(0, -90, -90), RightHand02.transform);
            if (Card03 == null) Card03 = GameObject.Instantiate(MainScneRes.Card[0].gameObject, RightHand03.transform.position, Quaternion.Euler(0, 168, 0), RightHand03.transform);
            if (Card01L == null) Card01L = GameObject.Instantiate(MainScneRes.Card[0].gameObject, LeftHand01.transform.position, Quaternion.Euler(90, 0, 0), LeftHand01.transform);
            if (Card02L == null) Card02L = GameObject.Instantiate(MainScneRes.Card[0].gameObject, LeftHand02.transform.position, Quaternion.Euler(90, 0, 0), LeftHand02.transform);
            if (Card03L == null) Card03L = GameObject.Instantiate(MainScneRes.Card[0].gameObject, LeftHand03.transform.position, Quaternion.Euler(90, 0, 0), LeftHand03.transform);
            Card01L.SetActive(false);
            Card02L.SetActive(false);
            Card03L.SetActive(false);
        }
        public override void EntityDispose()
        {

        }

        void Update()
        {
            StartCoroutine(update());
        }

        IEnumerator update()
        {
            if (gamestart == 1)
            {          
                Card01.SetActive(true);
                Card02.SetActive(true);
                Card03.SetActive(true);
            }
            if(cardtoplay == 1)
            {
                Card01L.SetActive(true);
                Card02L.SetActive(true);
                Card03L.SetActive(true);
            }
            if(cardtoplay == 0)
            {
                Card01L.SetActive(false);
                Card02L.SetActive(false);
                Card03L.SetActive(false);
            }
            if(gamestart == 0)
            {
                Card01.SetActive(false);
                Card02.SetActive(false);
                Card03.SetActive(false);
            }
            if(cardontable == 1 && cardontablen == 0)
            {
                cardontablen = 1;
                Card01table = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy01Card[currentcard]-1)*2].gameObject, table01.transform.position, Quaternion.Euler(90, 0, 180), table01.transform);
                Card02table = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy02Card[currentcard]-1)*2].gameObject, table02.transform.position, Quaternion.Euler(90, 90, 0), table02.transform);
                Card03table = GameObject.Instantiate(MainScneRes.Card[(Test_WaveConfig.Enemy03Card[currentcard]-1)*2].gameObject, table03.transform.position, Quaternion.Euler(90, -90, 0), table03.transform);
            }
            if(cardturn == 1 && cardontablen == 1)
            {
                    cardturn = 0;
                    Card01table.transform.Rotate(180, 0, 180);
                    Card02table.transform.Rotate(180, 0, 180);
                    Card03table.transform.Rotate(180, 0, 180);
            }
            if(cardontable == 0 && cardab == 1)
            {
                cardab = 0;            
                nocard = 0;
                Card01table.transform.parent = table.transform;
                Card02table.transform.parent = table.transform;
                Card03table.transform.parent = table.transform;
                Card01table.transform.position = new Vector3(table.transform.position.x + Random.Range(-0.2f, 0.2f), table.transform.position.y + Random.Range(-0.0012f, 0.0012f), table.transform.position.z + Random.Range(-0.12f, 0.12f));
                Card01table.transform.rotation = Quaternion.Euler(-90, 0, Random.Range(-180, 180));
                Card02table.transform.position = new Vector3(table.transform.position.x + Random.Range(-0.2f, 0.2f), table.transform.position.y + Random.Range(-0.0012f, 0.0012f), table.transform.position.z + Random.Range(-0.12f, 0.12f));
                Card02table.transform.rotation = Quaternion.Euler(-90, 90, Random.Range(-180, 180));
                Card03table.transform.position = new Vector3(table.transform.position.x + Random.Range(-0.2f, 0.2f), table.transform.position.y + Random.Range(-0.0012f, 0.0012f), table.transform.position.z + Random.Range(-0.12f, 0.12f));
                Card03table.transform.rotation = Quaternion.Euler(-90, -90, Random.Range(-180, 180));
            }
            if(nocard == 1)
            {
                yield return new WaitForSeconds(3);
                table = GameObject.Find("tablemid");
                CardAb = GameObject.FindGameObjectsWithTag("Card");
                for (int i = 0; i < CardAb.Length; i++)
                {
                    Destroy(CardAb[i]);
                }
                nocard = 0;
            }
        }

    }
}
