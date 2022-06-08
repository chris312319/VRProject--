using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGameFrame
{
    public class Test_CardEntity : GameEntityBase
    {
        public float speed = 175f;
        private float timer;
        public Test_MainScneRes MainScneRes { get; set; }

        public GameObject Player { get; set; }

        public override void EntityDispose()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "LeftHand")
            {
  
            }
            if (other.tag == "RightHand")
            {

            }
        }

        private void Update()
        {
            
        }
    }
}
