using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_PlayerConfig 
{

 
    public int[] PlayerCard {get; set; }

    public Test_PlayerConfig()
    {
        PlayerCard = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; 
    }
}
