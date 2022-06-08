using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGameFrame
{
    public class Test_WaveConfig
    {
        static public int[] PlayerCard { get; set; }
        static public int[] Enemy01Card { get; set; }
        static public int[] Enemy02Card { get; set; }
        static public int[] Enemy03Card { get; set; }

        public int GameWave { get; set; }

        public int GameRound { get; set; }

        public int IntervalTime { get; set; }

        public Test_WaveConfig()
        {
            PlayerCard  = new int[] { 5,6,7, 7, 8, 5, 3, 10, 6, 7,  8, 9, 10 };
            Enemy01Card = new int[] { 1,9,4, 4, 4, 2, 8, 9, 7, 8,  9, 10, 1 }; //綠
            Enemy02Card = new int[] { 5,2,10,2, 3, 10, 5, 8, 8, 9, 10, 1, 2 }; //花
            Enemy03Card = new int[] { 8,5,7, 9, 6, 7, 6, 2, 9,10,  1, 2, 3}; //紅
            GameWave = 2;
            GameRound = 5;
            IntervalTime = 3;
        }
        
    }
}
