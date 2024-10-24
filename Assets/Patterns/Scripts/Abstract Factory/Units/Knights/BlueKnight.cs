using UnityEngine;

namespace AbstractFactory
{
    public class BlueKnight : Knight
    {
        protected override void Attack()
        {
            Debug.Log("Blue attack");
        }
    }
}