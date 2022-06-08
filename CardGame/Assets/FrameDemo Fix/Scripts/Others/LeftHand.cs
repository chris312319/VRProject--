using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGameFrame
{
    public class LeftHand : GameEntityBase
    {
        public override void EntityDispose()
        {

        }

        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Table")
            {
                Test_PlayerEntity.lefttable = 1;
                Debug.Log("Lefttable");
            }
            if (other.tag == "Playercard")
            {
                Test_PlayerEntity.leftcard = 1;
                Debug.Log("Leftcard");
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Table")
            {
                Test_PlayerEntity.lefttable = 0;
            }
            if (other.tag == "Card")
            {
                Test_PlayerEntity.leftcard = 0;
            }

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
