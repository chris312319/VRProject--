﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rebreathbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Click()
    {
        TestGameFrame.Test_EnemyTask._isRebreathButtonClick = true;
    }
}
