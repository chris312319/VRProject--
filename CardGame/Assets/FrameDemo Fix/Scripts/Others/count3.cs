using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class count3 : MonoBehaviour
{
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TestGameFrame.Test_EnemyTask.count3 == 1)
        {
            timer += Time.deltaTime;
            if (timer > 1)
            {
                GameObject.Find("Command").GetComponent<Text>().text = "";
                TestGameFrame.Test_EnemyTask.count3 = 0;
            }
        }
        else timer = 0;
    }
}
