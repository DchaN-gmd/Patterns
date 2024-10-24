using UnityEngine;

namespace AbstractFactory
{
    public class RedArcher : Archer
    {
        [SerializeField] private float _fireArrowDamage;

        public void Init(float fireArrowDamage, float shootRange)
        {
            base.Init(shootRange);
            _fireArrowDamage = fireArrowDamage;
        }

        protected override void Shoot()
        {
            Debug.Log("Fire shoot");
        }
    }
}
