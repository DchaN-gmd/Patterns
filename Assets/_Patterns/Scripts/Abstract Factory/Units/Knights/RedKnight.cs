using UnityEngine;

namespace AbstractFactory
{
    public class RedKnight : Knight
    {
        protected override void Attack()
        {
            Debug.Log("Red Attack");
        }
    }
}
