using UnityEngine;

namespace Assets._Patterns.Scripts.Strategy
{
    public class Steal : IMove
    {
        private float _speed;

        public Steal(float speed)
        {
            _speed = speed;
        }

        public void Move()
        {
            Debug.Log("Steal move");
        }
    }
}
