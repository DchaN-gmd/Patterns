using UnityEngine;

namespace AbstractFactory
{
    public class RedMage : Mage
    {
        protected override void Cast()
        {
            Debug.Log("Red cast");
        }
    }
}