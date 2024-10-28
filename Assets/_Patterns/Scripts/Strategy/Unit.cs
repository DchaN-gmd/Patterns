using UnityEngine;

namespace Assets._Patterns.Scripts.Strategy
{
    public class Unit : MonoBehaviour
    {
        public void Move(IMove move)
        {
            move.Move();
        }
    }
}
