using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace AbstractFactory
{
    public abstract class Archer : Unit
    {
        [SerializeField] protected float ShootRange;

        public void Init(float shootRange)
        {
            if (shootRange < 0) throw new Exception("Shoot range can't be less then 0");

            ShootRange = shootRange;
        }

        private void Start()
        {
            Shoot();
        }

        protected abstract void Shoot();
    }
}
