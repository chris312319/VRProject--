using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_GameData : MonoBehaviour
{
    static public int[] takecard = new int[10];
    static public int[] outcard = new int[10];
    static public int[] turncard = new int[10];
    static public int[] abacard = new int[10];
    static public int[] saybig = new int[10];
    static public int[] showcard = new int[10];
    static public int[] question = new int[10];
    static public float[] timearray = new float[10];
    static public int[] chooseemotion = new int[10];
    static public int[] chooseaction = new int[10];




    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            takecard[i] = -1;
            outcard[i] = 0;
            turncard[i] = 0;
            abacard[i] = 0;
            saybig[i] = 0;
            question[i] = 0;
            showcard[i] = 0;
            timearray[i] = -1;
            chooseemotion[i] = -1;
            chooseaction[i] = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
