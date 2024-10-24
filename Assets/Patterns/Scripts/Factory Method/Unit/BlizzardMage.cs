using UnityEngine;

namespace Factory
{
    public class BlizzardMage : Mage
    {
        private float _blizzardPower;

        public void Init(float blizzardPower, float castRange)
        {
            base.Init(castRange);
            _blizzardPower = blizzardPower;
        }

        public override void Cast()
        {
            Debug.Log($"Blizzard cast with {_blizzardPower} power");
        }
    }
}