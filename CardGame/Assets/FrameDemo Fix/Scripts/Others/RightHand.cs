using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestGameFrame
{
    public class RightHand : GameEntityBase
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
            if (other.tag == "Table")
            {
                Test_PlayerEntity.righttable = 1;
                //Debug.Log("Righttable");
            }
            if (other.tag == "LeftHand")
            {
                Test_PlayerEntity.leftright = 1;
                //Debug.Log("LeftRight");
            }
            if ((other.tag == "Card")|| (other.tag == "Playercard"))
            {
                Test_PlayerEntity.rightcard = 1;
                //Debug.Log("Rightcard");
            }

        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Table")
            {
                Test_PlayerEntity.righttable = 0;
            }
            if (other.tag == "LeftHand")
            {
                Test_PlayerEntity.leftright = 0;
            }
            if (other.tag == "Card")
            {
                Test_PlayerEntity.rightcard = 0;
            }

        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
