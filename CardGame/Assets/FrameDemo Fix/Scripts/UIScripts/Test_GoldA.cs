using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GoldA : MonoBehaviour
{
    public GameObject[] P = new GameObject[12];
    public GameObject[] E1 = new GameObject[12];
    public GameObject[] E2 = new GameObject[12];
    public GameObject[] E3 = new GameObject[12];
    public GameObject[] X = new GameObject[12];
    public GameObject[] PDiamond = new GameObject[12];
    public GameObject[] E1Diamond = new GameObject[12];
    public GameObject[] E2Diamond = new GameObject[12];
    public GameObject[] E3Diamond = new GameObject[12];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i < 11; i++)
        {
            P[i] = GameObject.Find("PG" + i);
            E1[i] = GameObject.Find("E1G" + i);
            E2[i] = GameObject.Find("E2G" + i);
            E3[i] = GameObject.Find("E3G" + i);
        }
        for(int i = 1; i < 6; i++)
        {
            PDiamond[i] = GameObject.Find("PDia" + i);
            E1Diamond[i] = GameObject.Find("E1Dia" + i);
            E2Diamond[i] = GameObject.Find("E2Dia" + i);
            E3Diamond[i] = GameObject.Find("E3Dia" + i);
        }
        for (int i = 1; i < 11; i++)
        {
            P[i].SetActive(false);
            E1[i].SetActive(false);
            E2[i].SetActive(false);
            E3[i].SetActive(false);
        } 
        for(int i = 1; i < 6; i++)
        {
            PDiamond[i].SetActive(false);
            E1Diamond[i].SetActive(false);
            E2Diamond[i].SetActive(false);
            E3Diamond[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 1; i < 11; i++)
        {
            if (TestGameFrame.Test_CoinTask.coinP > i)  P[i].SetActive(true);
            else P[i].SetActive(false);
            if (TestGameFrame.Test_CoinTask.coin01 > i) E1[i].SetActive(true);
            else E1[i].SetActive(false);
            if (TestGameFrame.Test_CoinTask.coin02 > i) E2[i].SetActive(true);
            else E2[i].SetActive(false);
            if (TestGameFrame.Test_CoinTask.coin03 > i) E3[i].SetActive(true);
            else E3[i].SetActive(false);
        }
        for(int i = 1; i < 6; i++)
        {
            if (TestGameFrame.Test_CoinTask.diamondP > i) PDiamond[i].SetActive(true);
            else PDiamond[i].SetActive(false);
            if (TestGameFrame.Test_CoinTask.diamond01 > i) E1Diamond[i].SetActive(true);
            else E1Diamond[i].SetActive(false);
            if (TestGameFrame.Test_CoinTask.diamond02 > i) E2Diamond[i].SetActive(true);
            else E2Diamond[i].SetActive(false);
            if (TestGameFrame.Test_CoinTask.diamond03 > i) E3Diamond[i].SetActive(true);
            else E3Diamond[i].SetActive(false);
        }
    }
}
