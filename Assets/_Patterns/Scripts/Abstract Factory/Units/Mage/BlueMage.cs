using UnityEngine;

namespace AbstractFactory
{
    public class BlueMage : Mage
    {
        protected override void Cast()
        {
            Debug.Log("Blue cast");
        }
    }
}