using UnityEngine;

namespace Assets._Patterns.Scripts.Strategy
{
    public class Run : IMove
    {
        private float _speed;

        public Run(float speed)
        {
            _speed = speed;
        }

        public void Move()
        {
            Debug.Log($"Move with {_speed} speed");
        }
    }
}