using UnityEngine;

namespace AbstractFactory
{
    public class BlueArcher : Archer
    {
        [SerializeField] private float _freezePower;

        public void Init(float freezePower, float shootRange)
        {
            base.Init(shootRange);
            _freezePower = freezePower;
        }

        protected override void Shoot()
        {
            Debug.Log("Freeze shoot");
        }
    }
}
