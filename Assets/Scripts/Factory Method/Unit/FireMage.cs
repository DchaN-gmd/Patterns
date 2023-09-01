using UnityEngine;

namespace Factory
{
    public class FireMage : Mage
    {
        private float _firePower;

        public void Init(float firePower, float castRange)
        {
            base.Init(castRange);
            _firePower = firePower;
        }

        public override void Cast()
        {
            Debug.Log($"Fire cast with {_firePower} power");
        }
    }
}